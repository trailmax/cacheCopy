using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cacheCopy;
using NUnit.Framework;
using NUnit.Mocks;

namespace cacheCopyTests
{
    [TestFixture]
    class UpdaterTest
    {

        private DynamicMock gui;


        [Test]
        public void testUpdater()
        {
            
            Updater updater = new Updater(null);

        }
    }
}
