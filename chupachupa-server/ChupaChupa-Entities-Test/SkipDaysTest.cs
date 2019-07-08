using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa.Entities;
using NUnit.Framework;

namespace ChupaChupa.Entities.Test.Database.Entities
{
    [TestFixture]
    class SkipDaysTest
    {
        [Test]
        public void Update()
        {
            var skipDays1 = new SkipDays()
            {
                Day = "Tuesday"
            };

            var skipDays2 = new SkipDays();
            skipDays2.update(skipDays1);

            Assert.IsNotNull(skipDays2);
            Assert.AreNotSame(skipDays1, skipDays2);
            Assert.AreEqual(skipDays1.Day, skipDays2.Day);
        }
    }
}
