using BaystateHealth.Business.Services.WaitTimes.Rss;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaystateHealth.Business.Services.WaitTimes.Test
{
    [TestClass]
    public class WaitTimesProviderTest
    {
        private IWaitTimeProvider _provider;
        private readonly string VALIDKEY;
        private readonly string INVALIDKEY;

        public WaitTimesProviderTest()
        {
            // Normally handled via dependecy injection
            //_provider = new Mock.MockWaitTimeProvider();
            _provider = new RssWaitTimeProvider();
            VALIDKEY = "1";
            INVALIDKEY = "999";
        }

        [TestMethod]
        public void Get_Single_Valid_Key()
        {
            WaitTime waitTime = _provider.GetWaitTime(VALIDKEY);

            Assert.IsNotNull(waitTime);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Get_Single_Invalid_Key()
        {
            WaitTime waitTime = _provider.GetWaitTime(INVALIDKEY);
        }

        [TestMethod]
        public void Get_All()
        {
            IEnumerable<WaitTime> waitTimes = _provider.GetWaitTimes();

            Assert.IsTrue(waitTimes.Any());
        }
    }
}
