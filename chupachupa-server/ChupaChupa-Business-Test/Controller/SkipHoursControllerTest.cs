using ChupaChupa.Business.Controller;
using ChupaChupa.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Test.Controller
{
    [TestFixture]
    class SkipHoursControllerTest
    {
        [Test]
        public void controlSkipHoursControllerTest()
        {
            SkipHoursController controller = new SkipHoursController();
            SkipHours validSkipHour = new SkipHours();
            SkipHours wrongSkipHour = new SkipHours();

            validSkipHour.Hour = 22;
            Assert.IsTrue(controller.controlData(validSkipHour));

            wrongSkipHour.Hour = 42;
            Assert.IsFalse(controller.controlData(wrongSkipHour));

            wrongSkipHour.Hour = -22;
            Assert.IsFalse(controller.controlData(wrongSkipHour));

            wrongSkipHour.Hour = 128;
            Assert.IsFalse(controller.controlData(wrongSkipHour));

            wrongSkipHour.Hour = 24;
            Assert.IsFalse(controller.controlData(wrongSkipHour));
        }
    }
}
