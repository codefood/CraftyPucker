using System;
using System.Text;
using System.Collections.Generic;
using CraftyPucker.Data.Tests;
using CraftyPucker.Data;
using CraftyPucker.Data.UrlGenerators;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CraftyPucker.Data.Tests.UrlGenerators
{
    [TestClass]
    public class VodUrlGeneratorTests
    {

        [TestMethod()]
        public void VodUrlGeneratorReturnsCorrectBaseUrl()
        {
            var vodUrlGenerator = new VodUrlGenerator();
            Assert.AreEqual(vodUrlGenerator.GetBaseUrl(), "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl");
        }

    }
}
