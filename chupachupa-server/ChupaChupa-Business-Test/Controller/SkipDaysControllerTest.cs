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
    class SkipDaysControllerTest
    {
        [Test]
        public void controlSkipDaysControllerTest()
        {
            SkipDaysController controller = new SkipDaysController();
            SkipDays validSkipDay = new SkipDays();
            SkipDays wrongSkipDay = new SkipDays();

            validSkipDay.Day = "Wednesday";
            Assert.IsTrue(controller.controlData(validSkipDay));

            wrongSkipDay.Day = "Lundi";
            Assert.IsFalse(controller.controlData(wrongSkipDay));

            wrongSkipDay.Day = "Mercredi";
            Assert.IsFalse(controller.controlData(wrongSkipDay));

            wrongSkipDay.Day = "Vendredi";
            Assert.IsFalse(controller.controlData(wrongSkipDay));

            wrongSkipDay.Day = "Dimanche";
            Assert.IsFalse(controller.controlData(wrongSkipDay));

            wrongSkipDay.Day = "Montag";
            Assert.IsFalse(controller.controlData(wrongSkipDay));
        }
    }
}
