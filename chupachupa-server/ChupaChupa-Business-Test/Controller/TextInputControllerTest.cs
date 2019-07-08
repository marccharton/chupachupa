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
    class TextInputControllerTest
    {
        [Test]
        public void controlTextInputControllerTest()
        {
            TextInputController controller = new TextInputController();
            TextInput validTextInput = new TextInput();
            TextInput wrongTextInput = new TextInput();

            validTextInput.Title = "This is a valid title";
            validTextInput.Description = "This is a valid description";
            validTextInput.Name = "This is a valid name";
            validTextInput.Link = "This is a valid link";
            Assert.IsTrue(controller.controlData(validTextInput));

            wrongTextInput.Title = "This is a valid title";
            wrongTextInput.Description = "This is a valid description";
            wrongTextInput.Name = "This is a valid name";
            wrongTextInput.Link = "This is a valid link";

            #region wrong title test

            wrongTextInput.Title = "This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title This is an invalid title ";
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Title = "";
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Title = null;
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Title = "This is a valid title";

            #endregion

            #region wrong description test

            wrongTextInput.Description = "This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description This is an invalid description ";
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Description = "";
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Description = null;
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Description = "This is a valid description";

            #endregion

            #region wrong name test

            wrongTextInput.Name = "This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name ";
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Name = "";
            Assert.IsFalse(controller.controlData(wrongTextInput));

            wrongTextInput.Name = null;
            Assert.IsFalse(controller.controlData(wrongTextInput));
            
            wrongTextInput.Name = "This is a valid name";

            #endregion

            #region wrong link test 

            wrongTextInput.Link = "This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link This is an invalid link ";
            Assert.IsFalse(controller.controlData(wrongTextInput));

            #endregion
        }   
    }
}
