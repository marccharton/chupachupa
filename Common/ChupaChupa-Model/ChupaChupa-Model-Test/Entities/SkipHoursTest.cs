using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa_Model.Entities;
using NUnit.Framework;

namespace ChupaChupa_Server_Test.Database.Entities
{
    [TestFixture]
    class SkipHoursTest
    {
        [Test]
        public void Update()
        {
            var skipHours1 = new SkipHours()
            {
                Hour = 17
            };

            var skipHours2 = new SkipHours();
            skipHours2.update(skipHours1);

            Assert.IsNotNull(skipHours2);
            Assert.AreNotSame(skipHours1, skipHours2);
            Assert.AreEqual(skipHours1.Hour, skipHours2.Hour);
        }
    }
}
