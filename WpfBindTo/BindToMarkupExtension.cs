using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "WpfControls")]

namespace WpfControls
{
    public class BindToExtension : MarkupExtension { 
        private Binding _Binding;
        private string _Path;
        private string _MethodName;

        public BindToExtension() {
        }

        public BindToExtension(string psPath) {
            this._Path = psPath;
        }

        public void ProcessPath(IServiceProvider serviceProvider) {
            if(string.IsNullOrWhiteSpace(_Path)) {
                _Binding = new Binding();
                return;
            }

            var Parts = _Path.Split('.').Select(o => o.Trim()).ToArray();

            RelativeSource oRelativeSource = null;
            string sElementName = null;

            var PartIndex = 0;

            if(Parts[0].StartsWith("#")) {
                sElementName = Parts[0].Substring(1);
                PartIndex++;
            } else if (Parts[0].ToLower() == "ancestors" || Parts[0].ToLower() == "ancestor") {
                if(Parts.Length < 2) throw new Exception("Invalid path, expected exactly 2 identifiers ancestors.#Type#.[Path] (e.g. Ancestors.DataGrid, Ancestors.DataGrid.SelectedItem, Ancestors.DataGrid.SelectedItem.Text)");
                var sType = Parts[1];
                var oType = (Type)new System.Windows.Markup.TypeExtension(sType).ProvideValue(serviceProvider);
                if(oType == null) throw new Exception("Could not find type: " + sType);
                oRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, oType, 1);
                PartIndex += 2;
            } else if (Parts[0].ToLower() == "template" || Parts[0].ToLower() == "templateparent" || Parts[0].ToLower() == "templatedparent" || Parts[0].ToLower() == "templated") {
                oRelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent);
                PartIndex++;
            } else if (Parts[0].ToLower() == "thiswindow") {
                oRelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Window), 1);
                PartIndex++;
            } else if (Parts[0].ToLower() == "this") {
                oRelativeSource = new RelativeSource(RelativeSourceMode.Self);
                PartIndex++;
            }

            var PartsForPathString = Parts.Skip(PartIndex);
            IValueConverter ValueConverter = null;

            if (PartsForPathString.Any()) {
                var sLastPartForPathString = PartsForPathString.Last();

                if (sLastPartForPathString.EndsWith("()")) {
                    PartsForPathString = PartsForPathString.Take(PartsForPathString.Count() - 1);
                    _MethodName = sLastPartForPathString.Remove(sLastPartForPathString.Length - 2);
                    ValueConverter = new CallMethodValueConverter(_MethodName);
                }
            }

            var Path = string.Join(".", PartsForPathString.ToArray());

            if(string.IsNullOrWhiteSpace(Path)) {
                _Binding = new Binding();
            } else {
                _Binding = new Binding(Path);
            }

            if (sElementName != null) {
                _Binding.ElementName = sElementName;
            }

            if (oRelativeSource != null) {
                _Binding.RelativeSource = oRelativeSource;
            }

            if (ValueConverter != null) {
                _Binding.Converter = ValueConverter;
            }
        }

        public override object ProvideValue(IServiceProvider poServiceProvider) {
            if (!(poServiceProvider is IXamlTypeResolver)) return null; // NOTE, this is to prevent the design time editor from showing an error related to the user of TypeExtension in ProcessPath
            ProcessPath(poServiceProvider);
            return _Binding.ProvideValue(poServiceProvider);
        }

        private class CallMethodValueConverter : IValueConverter {
            private string msMethodName;

            public CallMethodValueConverter(string psMethodName) {
                msMethodName = psMethodName;
            }

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                if (value == null) return null;
                return new CallMethodCommand(value, msMethodName);
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException();
            }
        }

        private class CallMethodCommand : ICommand {
            private readonly object moObject;

            private readonly MethodInfo moMethodInfo;
            private readonly bool mbMethodAcceptsParameter;

            private readonly MethodInfo moCanMethodInfo;
            private readonly bool mbCanMethodAcceptsParameter;

            public CallMethodCommand(object poObject, string psMethodName) {
                moObject = poObject;

                moMethodInfo = moObject.GetType().GetMethod(psMethodName);

                var aParameters = moMethodInfo.GetParameters();
                if (aParameters.Length > 2) throw new Exception("You can only bind to a methods take take 0 or 1 parameters.");

                moCanMethodInfo = moObject.GetType().GetMethod("Can" + psMethodName);
                if (moCanMethodInfo != null) {
                    if (moCanMethodInfo.ReturnType != typeof(bool)) throw new Exception("'Can' method must return boolean.");

                    var aCanParameters = moMethodInfo.GetParameters();
                    if (aCanParameters.Length > 2) throw new Exception("You can only bind to a methods take take 0 or 1 parameters.");
                    mbCanMethodAcceptsParameter = aParameters.Any();
                }

                mbMethodAcceptsParameter = aParameters.Any();
            }

            public bool CanExecute(object parameter) {
                if (moCanMethodInfo == null) return true;

                var aParameters = !mbMethodAcceptsParameter ? null : new[] { parameter };
                return (bool)moCanMethodInfo.Invoke(moObject, aParameters);
            }

            #pragma warning disable 67 // CanExecuteChanged is not being used but is required by ICommand
            public event EventHandler CanExecuteChanged;
            #pragma warning restore 67 // CanExecuteChanged is not being used but is required by ICommand

            public void Execute(object parameter) {
                var aParameters = !mbMethodAcceptsParameter ? null : new [] { parameter };
                moMethodInfo.Invoke(moObject, aParameters);
            }
        }
    }
}
