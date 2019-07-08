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
    class SourceControllerTest
    {
        [Test]
        public void controlSourceControllerTest()
        {
            SourceController controller = new SourceController();
            Source validSource = new Source();
            Source wrongSource = new Source();

            validSource.Url = "http://fakedomain.com";
            Assert.IsTrue(controller.controlData(validSource));

            #region wrong url test

            wrongSource.Url = "http://fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.fakedomain.com.over.limit.";
            Assert.IsFalse(controller.controlData(wrongSource));

            wrongSource.Url = "";
            Assert.IsFalse(controller.controlData(wrongSource));

            wrongSource.Url = null;
            Assert.IsFalse(controller.controlData(wrongSource));

            #endregion

        }
    }
}
