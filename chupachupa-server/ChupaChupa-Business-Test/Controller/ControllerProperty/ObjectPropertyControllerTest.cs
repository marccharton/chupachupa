using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using ChupaChupa.Business.Test.Controller.ControllerProperty;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    [TestFixture]
    class ObjectPropertyControllerTest
    {
        [Test]
        public void controlObjectPropertyTest()
        {
            #region null value

            ObjectPropertyController controllerNullValue = new ObjectPropertyController("TestProperty");

            Assert.IsTrue(controllerNullValue.controlProperty(null));
            Assert.IsTrue(controllerNullValue.controlProperty("This is a test"));

            controllerNullValue.CanBeNull = false;
            Assert.IsFalse(controllerNullValue.controlProperty(null));
            Assert.IsTrue(controllerNullValue.controlProperty("This is another test"));

            #endregion

            #region with controller

            ObjectPropertyController controllerWithController = new ObjectPropertyController("TestProperty");
            FakeObject fakeObj = new FakeObject();
            FakeObjectController fakeController = new FakeObjectController();

            Assert.IsTrue(controllerWithController.controlProperty(fakeObj));

            controllerWithController.Controller = fakeController;
            Assert.IsTrue(controllerWithController.controlProperty(null));

            controllerWithController.CanBeNull = false;
            Assert.IsFalse(controllerWithController.controlProperty(null));

            Assert.IsFalse(controllerWithController.controlProperty(fakeObj));

            fakeObj.intValue = 12;
            Assert.IsFalse(controllerWithController.controlProperty(fakeObj));

            fakeObj.stringValue = "toto";
            Assert.IsTrue(controllerWithController.controlProperty(fakeObj));

            fakeObj.intValue = -12;
            Assert.IsFalse(controllerWithController.controlProperty(fakeObj));

            #endregion
        }
    }
}
