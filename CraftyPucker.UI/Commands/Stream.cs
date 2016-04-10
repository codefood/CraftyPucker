using CraftyPucker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CraftyPucker.UI.Commands
{
    public class Stream : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            try
            {
                var mediaFeed = parameter as MediaFeed;
                if (mediaFeed == null)
                    throw new ArgumentException("mediaFeed");
                if (!mediaFeed.Available)
                    throw new NullReferenceException(string.Format("MediaFeed {0} is not available", mediaFeed.MediaFeedType));


                mediaFeed.Stream();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
