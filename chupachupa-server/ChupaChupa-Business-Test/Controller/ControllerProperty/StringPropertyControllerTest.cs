using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    [TestFixture]
    class StringPropertyControllerTest
    {

        [SetUp]
        public void SetupContext() {
        }

        [Test]
        public void controlStringPropertyTest()
        {
            #region null value

            StringPropertyController controllerNullValue = new StringPropertyController("TestProperty");

            Assert.IsTrue(controllerNullValue.controlProperty(null));
            Assert.IsTrue(controllerNullValue.controlProperty("This is a test"));

            controllerNullValue.CanBeNull = false;
            Assert.IsFalse(controllerNullValue.controlProperty(null));
            Assert.IsTrue(controllerNullValue.controlProperty("This is another test"));

            #endregion

            #region size

            StringPropertyController controllerSize = new StringPropertyController("TestProperty");

            Assert.IsTrue(controllerSize.controlProperty(""));

            controllerSize.MinSize = 0;
            Assert.IsTrue(controllerSize.controlProperty(""));

            controllerSize.MinSize = 1;
            Assert.IsFalse(controllerSize.controlProperty(""));

            controllerSize.MinSize = 0;
            controllerSize.MaxSize = -1;
            Assert.IsFalse(controllerSize.controlProperty(""));

            controllerSize.MinSize = 0;
            controllerSize.MaxSize = 1;
            Assert.IsTrue(controllerSize.controlProperty("A"));

            controllerSize.MinSize = 1;
            Assert.IsTrue(controllerSize.controlProperty("A"));

            controllerSize.MinSize = 2;
            controllerSize.MaxSize = 7;
            Assert.IsTrue(controllerSize.controlProperty("ABCDEF"));

            #endregion

            #region possible values

            StringPropertyController controllerPossibleValues = new StringPropertyController("TestProperty");
            List<string> possibleValues = new List<string>();

            Assert.IsTrue(controllerPossibleValues.controlProperty("This a first test"));

            controllerPossibleValues.PossibleValues = possibleValues;
            Assert.IsTrue(controllerPossibleValues.controlProperty("This a second test"));

            possibleValues.Add("Toto");
            Assert.IsFalse(controllerPossibleValues.controlProperty("This a third test"));
            Assert.IsFalse(controllerPossibleValues.controlProperty("toto"));
            Assert.IsTrue(controllerPossibleValues.controlProperty("Toto"));

            possibleValues.Add("Titi");
            possibleValues.Add("toto");
            possibleValues.Add("tutu");
            possibleValues.Add("tata");
            Assert.IsFalse(controllerPossibleValues.controlProperty("Tutu"));
            Assert.IsFalse(controllerPossibleValues.controlProperty("tete"));
            Assert.IsTrue(controllerPossibleValues.controlProperty("tata"));

            #endregion

            #region global

            StringPropertyController controllerGlobal = new StringPropertyController("TestProperty");

            Assert.IsTrue(controllerGlobal.controlProperty("AA"));

            controllerGlobal.MaxSize = 1;
            Assert.IsFalse(controllerGlobal.controlProperty("AA"));

            controllerGlobal.MinSize = 3;
            Assert.IsFalse(controllerGlobal.controlProperty("AA"));
            Assert.IsTrue(controllerGlobal.controlProperty(null));

            controllerGlobal.CanBeNull = false;
            Assert.IsFalse(controllerGlobal.controlProperty(null));

            possibleValues = new List<string>();
            possibleValues.Add("AA");
            possibleValues.Add("BB");
            possibleValues.Add("CC");
            possibleValues.Add("DD");
            controllerGlobal.PossibleValues = possibleValues;

            Assert.IsFalse(controllerGlobal.controlProperty("AA"));

            controllerGlobal.MinSize = 1;
            controllerGlobal.MaxSize = 10;
            Assert.IsTrue(controllerGlobal.controlProperty("DD"));
            Assert.IsFalse(controllerGlobal.controlProperty("EE"));
            Assert.IsFalse(controllerGlobal.controlProperty("This is a test"));
            Assert.IsFalse(controllerGlobal.controlProperty("Another test"));

            #endregion

        }
    }
}
