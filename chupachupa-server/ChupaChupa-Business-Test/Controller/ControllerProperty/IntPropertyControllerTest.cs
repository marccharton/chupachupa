using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    [TestFixture]
    class IntPropertyControllerTest
    {

        [SetUp]
        public void SetupContext() {
        }

        [Test]
        public void controlIntPropertyTest() {

            #region Global test

            IntPropertyController controllerFirst = new IntPropertyController("TestProperty");
            List<long> possibleValues = new List<long>();

            Assert.IsTrue(controllerFirst.controlProperty(22));

            controllerFirst.PossibleValues = possibleValues;
            Assert.IsTrue(controllerFirst.controlProperty(22));

            possibleValues.Add(22);
            Assert.IsTrue(controllerFirst.controlProperty(22));

            controllerFirst.PossibleValues = null;
            Assert.IsTrue(controllerFirst.controlProperty(22));

            controllerFirst.MaxValue = 12;
            Assert.IsFalse(controllerFirst.controlProperty(22));

            controllerFirst.MaxValue = 42;
            Assert.IsTrue(controllerFirst.controlProperty(22));

            controllerFirst.MinValue = 23;
            Assert.IsFalse(controllerFirst.controlProperty(22));

            controllerFirst.MinValue = 19;
            Assert.IsTrue(controllerFirst.controlProperty(22));

            #endregion

            #region Possible values

            IntPropertyController controllerSecond = new IntPropertyController("TestProperty");
            possibleValues = new List<long>();

            possibleValues.Add(1);
            possibleValues.Add(2);
            possibleValues.Add(5);

            controllerSecond.PossibleValues = possibleValues;

            Assert.IsTrue(controllerSecond.controlProperty(1));
            Assert.IsTrue(controllerSecond.controlProperty(5));
            Assert.IsFalse(controllerSecond.controlProperty(7));

            possibleValues.Add(7);
            Assert.IsTrue(controllerSecond.controlProperty(7));
            
            #endregion

            #region Min and Max value

            IntPropertyController controllerThird = new IntPropertyController("TestProperty");

            controllerThird.MaxValue = 200;
            controllerThird.MinValue = -200;

            Assert.IsTrue(controllerThird.controlProperty(22));
            Assert.IsTrue(controllerThird.controlProperty(-200));
            Assert.IsTrue(controllerThird.controlProperty(200));
            Assert.IsFalse(controllerThird.controlProperty(400));
            Assert.IsFalse(controllerThird.controlProperty(-400));

            #endregion

        }
    }
}
