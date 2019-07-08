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
    class RssCategoryControllerTest
    {
        [Test]
        public void controlRssCategoryControllerTest()
        {
            RssCategoryController controller = new RssCategoryController();
            RssCategory validRssCategory = new RssCategory();
            RssCategory wrongRssCategory = new RssCategory();

            validRssCategory.Name = "This is a valid name";
            validRssCategory.Domain = "http://fakedomain.com";
            Assert.IsTrue(controller.controlData(validRssCategory));

            wrongRssCategory.Name = "This is a valid name";
            wrongRssCategory.Domain = "http://fakedomain.com";

            #region wrong domain test

            wrongRssCategory.Domain = "http://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu";
            Assert.IsFalse(controller.controlData(wrongRssCategory));

            wrongRssCategory.Domain = "";
            Assert.IsFalse(controller.controlData(wrongRssCategory));

            wrongRssCategory.Domain = null;
            Assert.IsFalse(controller.controlData(wrongRssCategory));

            wrongRssCategory.Domain = "http://fakedomain.com";

            #endregion

            #region wrong name test

            wrongRssCategory.Name = "This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name This is an invalid name ";
            Assert.IsFalse(controller.controlData(wrongRssCategory));

            wrongRssCategory.Name = "";
            Assert.IsFalse(controller.controlData(wrongRssCategory));

            wrongRssCategory.Name = null;
            Assert.IsFalse(controller.controlData(wrongRssCategory));

            #endregion
        }
    }
}
