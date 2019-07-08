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
    class RssItemControllerTest
    {
        [Test]
        public void controlRssItemControllerTest()
        {
            RssItemController controller = new RssItemController();
            RssItem validRssItem = new RssItem();
            RssItem wrongRssItem = new RssItem();

            validRssItem.Title = "This is a title";
            validRssItem.Link = "This is a path";
            validRssItem.Description = "This is a description";
            validRssItem.Author = "This is an author";
            validRssItem.Comments = "This is a comment";
            validRssItem.Guid = "This is a guid";
            validRssItem.RssChannel = new RssChannel { IdEntity = 42 };

            Assert.IsTrue(controller.controlData(validRssItem));

            wrongRssItem.Title = "This is a title";
            wrongRssItem.Link = "This is a path";
            wrongRssItem.Description = "This is a description";
            wrongRssItem.Author = "This is an author";
            wrongRssItem.Comments = "This is a comment";
            wrongRssItem.Guid = "This is a guid";
            validRssItem.RssChannel = new RssChannel { IdEntity = 42 };

            #region wrong title test

            wrongRssItem.Title = "This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Title = "";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Title = null;
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Title = "This is a title";

            #endregion

            #region wrong link test

            wrongRssItem.Link = "http://fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Link = "";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Link = null;
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Link = "http://fakedomain.com";

            #endregion

            #region wrong description test

            wrongRssItem.Description = "This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Description = "";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Description = null;
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Description = "This is a description";

            #endregion

            #region wrong author test

            wrongRssItem.Author = "This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author This in an invalid author ";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Author = "This is an author";

            #endregion

            #region wrong comment test

            wrongRssItem.Comments = "This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment This in an invalid comment ";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Comments = "This is a comment";

            #endregion

            #region wrong guid test

            wrongRssItem.Guid = "This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid This in an invalid guid ";
            Assert.IsFalse(controller.controlData(wrongRssItem));

            wrongRssItem.Guid = "This is a guid";

            #endregion
        }
    }
}
