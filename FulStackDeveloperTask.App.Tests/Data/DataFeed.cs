using FulStackDeveloperTask.App.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FulStackDeveloperTask.App.Tests.Data
{
    [TestClass]
    public class DataFeed
    {
        [TestMethod]
        public void TestFeed() {
            DataFeeder f = new DataFeeder();
            f.FeedData();
        }
    }
}
