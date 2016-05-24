using BaystateHealth.Business.Services.WaitTimes.Rss.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BaystateHealth.Business.Services.WaitTimes.Test.Rss
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void Get_Configuration()
        {
            ConfigurationSection configuration = ConfigurationSection.Create();

            Assert.IsTrue(configuration.Locations.Any());

            LocationElement locationElement = configuration.Locations.First();
            Assert.IsFalse(string.IsNullOrEmpty(locationElement.Key));
            Assert.IsFalse(string.IsNullOrEmpty(locationElement.Name));
            Assert.IsFalse(string.IsNullOrEmpty(locationElement.Description));
            Assert.IsFalse(string.IsNullOrEmpty(locationElement.Url));
        }
    }
}
