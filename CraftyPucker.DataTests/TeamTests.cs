using Microsoft.VisualStudio.TestTools.UnitTesting;
using CraftyPucker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Tests
{
    [TestClass()]
    public class TeamTests
    {
        [TestMethod()]
        public void IsBestTeamEverTest()
        {
            var team = new Team();
            team.Abbreviation = "DET";
            Assert.IsTrue(team.IsBestTeamEver());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var team = new Team();
            team.Abbreviation = "DET";
            team.Name = "Detroit Red Wings";
            Assert.IsNotNull(team.ToString());
        }
    }
}