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
    public class LiveUrlGeneratorTests
    {

        [TestMethod()]
        public void LiveUrlGeneratorReturnsCorrectBaseUrl()
        {
            var liveUrlGenerator = new LiveUrlGenerator();
            Assert.AreEqual(liveUrlGenerator.GetBaseUrl("CDN"), "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl");
        }

    }
}
