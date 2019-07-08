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
    class EnclosureControllerTest
    {
        [Test]
        public void controlEnclosureControllerTest()
        {
            EnclosureController controller = new EnclosureController();
            Enclosure validEnclosure = new Enclosure();
            Enclosure wrongEnclosure = new Enclosure();

            validEnclosure.Url = "http://fakedomain.com";
            validEnclosure.Length = 22;
            validEnclosure.Type = "This is a type";
            Assert.IsTrue(controller.controlData(validEnclosure));

            wrongEnclosure.Url = "http://fakedomain.com";
            wrongEnclosure.Length = 22;
            wrongEnclosure.Type = "This is a type";

            #region wrong url test

            wrongEnclosure.Url = "http://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.euhttp://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu";
            Assert.IsFalse(controller.controlData(wrongEnclosure));

            wrongEnclosure.Url = "";
            Assert.IsFalse(controller.controlData(wrongEnclosure));

            wrongEnclosure.Url = null;
            Assert.IsFalse(controller.controlData(wrongEnclosure));

            wrongEnclosure.Url = "http://fakedomain.com";

            #endregion

            #region wrong length test

            wrongEnclosure.Length = -150;
            Assert.IsFalse(controller.controlData(wrongEnclosure));

            wrongEnclosure.Length = 22;

            #endregion

            #region wrong type test

            wrongEnclosure.Type = "This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type This is an invalid type ";
            Assert.IsFalse(controller.controlData(wrongEnclosure));

            wrongEnclosure.Type = "";
            Assert.IsFalse(controller.controlData(wrongEnclosure));

            wrongEnclosure.Type = null;
            Assert.IsFalse(controller.controlData(wrongEnclosure));

            #endregion
        }
    }
}
