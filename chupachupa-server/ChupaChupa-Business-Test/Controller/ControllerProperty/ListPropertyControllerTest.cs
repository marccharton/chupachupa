using ChupaChupa.Business.Test.Controller.ControllerProperty;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    [TestFixture]
    public class ListPropertyControllerTest
    {
        [Test]
        public void controlListPropertyTest() {
            #region null value

            ListPropertyController controllerNullValue = new ListPropertyController("TestProperty");
            List<String> listString = new List<string>();

            Assert.IsTrue(controllerNullValue.controlProperty(null));


            controllerNullValue.CanBeNull = false;
            Assert.IsFalse(controllerNullValue.controlProperty(null));

            // Not a list!
            Assert.IsFalse(controllerNullValue.controlProperty("This is a test"));
            
            listString.Add(null);
            listString.Add(null);
            listString.Add(null);
            Assert.IsTrue(controllerNullValue.controlProperty(listString));

            #endregion

            #region controller list with controller

            ListPropertyController controllerWithController = new ListPropertyController("TestProperty");
            List<FakeObject> listFakeObj = null;
            FakeObjectController fakeController = new FakeObjectController();

            Assert.IsTrue(controllerWithController.controlProperty(listFakeObj));

            listFakeObj = new List<FakeObject>();
            Assert.IsTrue(controllerWithController.controlProperty(listFakeObj));

            listFakeObj.Add(new FakeObject());
            listFakeObj.Add(new FakeObject());
            listFakeObj.Add(new FakeObject());
            Assert.IsTrue(controllerWithController.controlProperty(listFakeObj));

            controllerWithController.Controller = fakeController;
            Assert.IsFalse(controllerWithController.controlProperty(listFakeObj));

            listFakeObj.Clear();
            listFakeObj.Add(new FakeObject() { stringValue = "First", intValue = 42 });
            listFakeObj.Add(new FakeObject() { stringValue = "Second", intValue = 12 });
            Assert.IsTrue(controllerWithController.controlProperty(listFakeObj));

            listFakeObj.Clear();
            listFakeObj.Add(new FakeObject() { stringValue = "First", intValue = 42 });
            listFakeObj.Add(new FakeObject() { stringValue = "Second", intValue = -12 });
            Assert.IsFalse(controllerWithController.controlProperty(listFakeObj));

            listFakeObj.Clear();
            listFakeObj.Add(new FakeObject() { stringValue = "", intValue = 42 });
            listFakeObj.Add(new FakeObject() { stringValue = "Second", intValue = 22 });
            Assert.IsFalse(controllerWithController.controlProperty(listFakeObj));

            #endregion
        }
    }
}
