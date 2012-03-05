using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cacheCopy;
using NUnit.Framework;
using NUnit.Mocks;
using Homegrown.Updater;

namespace cacheCopyTests
{
    [TestFixture]
    class UpdaterTest
    {

        private DynamicMock gui;
        private DynamicMock application;
        private Updater updater;


// Can't unit-test multi-threaded class
// and without threads it's a bit pointless 
// also can't break the class into smaller chunks with no multi-threading, 
// this will objects privacy 
// so sod this unit testing for multi-threaded class!!
		
		
/*
        [SetUp]
        public void Init()
        {
            // create mock objects
            gui = new DynamicMock(typeof(IMessagingGui));
            application = new DynamicMock(typeof(IApplicationUpdaterBridge));

            // create updater and give mock objects to the updater
            updater = new Updater((IMessagingGui)gui.MockInstance, (IApplicationUpdaterBridge)application.MockInstance);


            application.Expect("SetLastCheckedForUpdateDate");

            gui.Expect("setProgressLabel");
            gui.Expect("showMessageBox");

        }

        [Test]
        public void TestNoUpdatesAvailable()
        {
            // Pretend it is version 1000.0.0.0 we are working with. 
            // There is no way I make that many versions of the software, 
            // so we are running the latest version by default.
            
            application.ExpectAndReturn("GetLastCheckedForUpdateDate", DateTime.Now.AddDays(-50));
            application.ExpectAndReturn("GetApplicationVersion", new Version("1000.0.0.0"));

            updater.CheckUpdates();

            Assert.IsFalse(updater.isUpdateAvailable());

        }


        [Test]
        public void TestUpdateAvailable()
        {

            application.ExpectAndReturn("GetLastCheckedForUpdateDate", DateTime.Now.AddDays(-50));

            // pretend we are on very low version of the app
            application.ExpectAndReturn("GetApplicationVersion", new Version("0.1.0.0"));

            updater.CheckUpdates();


            Assert.IsTrue(updater.isUpdateAvailable());

        }
    }*/
}
