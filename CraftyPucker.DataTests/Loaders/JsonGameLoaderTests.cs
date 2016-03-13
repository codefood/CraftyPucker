using Microsoft.VisualStudio.TestTools.UnitTesting;
using CraftyPucker.Data.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Loaders.Tests
{
    [TestClass()]
    public class JsonGameLoaderTests
    {
        public string ReadTestJson()
        {
            return System.IO.File.ReadAllText("test.json");
        }


        [TestMethod()]
        public void LoadTest()
        {
            var data = ReadTestJson();
            var gameLoader = new JsonGameLoader();

            var games = gameLoader.Load(data);

            Assert.IsTrue(games.Any());
            //TODO: tests lol

        }
    }
}