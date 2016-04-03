using Microsoft.VisualStudio.TestTools.UnitTesting;
using CraftyPucker.Data.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Sources.Tests
{
    [TestClass()]
    public class JsonSourceTests
    {
        [TestMethod()]
        public void GetDataTest()
        {
            var jsonSource = new JsonSource();
            var jsonData = jsonSource.GetData(DateTime.Now);
            Assert.IsNotNull(jsonData);
        }
    }
}