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
    class RssChannelControllerTest
    {
        [Test]
        public void controlRssChannelControllerTest()
        {
            RssChannelController controller = new RssChannelController();
            RssChannel validRssChannel = new RssChannel();
            RssChannel wrongRssChannel = new RssChannel();

            validRssChannel.RssLink = "http://fakedomain.com";
            validRssChannel.Title = "This is a title";
            validRssChannel.Link = "This is a path";
            validRssChannel.Description = "This is a description";
            validRssChannel.Language = "This is a language";
            validRssChannel.Copyright = "This is a copyright";
            validRssChannel.ManagingEditor = "This is a managing editor";
            validRssChannel.WebMaster = "This is a webmaster";
            validRssChannel.Generator = "This is a generator";
            validRssChannel.Docs = "This is a doc";
            validRssChannel.Ttl = 42;
            validRssChannel.Rating = "This is a rating";

            Assert.IsTrue(controller.controlData(validRssChannel));

            wrongRssChannel.RssLink = "http://fakedomain.com";
            wrongRssChannel.Title = "This is a title";
            wrongRssChannel.Link = "http://fakedomain.com";
            wrongRssChannel.Description = "This is a description";
            wrongRssChannel.Language = "This is a language";
            wrongRssChannel.Copyright = "This is a copyright";
            wrongRssChannel.ManagingEditor = "This is a managing editor";
            wrongRssChannel.WebMaster = "This is a webmaster";
            wrongRssChannel.Generator = "This is a generator";
            wrongRssChannel.Docs = "This is a doc";
            wrongRssChannel.Ttl = 42;
            wrongRssChannel.Rating = "This is a rating";

            #region wrong rss link test

            wrongRssChannel.RssLink = "http://fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.RssLink = "";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.RssLink = null;
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.RssLink = "http://fakedomain.com";
            
            #endregion

            #region wrong title test

            wrongRssChannel.Title = "This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title This in an invalid title";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Title = "";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Title = null;
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Title = "This is a title";

            #endregion

            #region wrong link test

            wrongRssChannel.Link = "http://fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu.fakedomain.com.overlimit.eu";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Link = "";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Link = null;
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Link = "http://fakedomain.com";

            #endregion

            #region wrong description test

            wrongRssChannel.Description = "This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description This in an invalid description";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Description = "";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Description = null;
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Description = "This is a description";

            #endregion

            #region wrong language test

            wrongRssChannel.Language = "This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language This in an invalid language ";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Language = "This is a language";

            #endregion

            #region wrong copyright test

            wrongRssChannel.Copyright = "This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright This in an invalid copyright ";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Copyright = "This is a copyright";

            #endregion

            #region wrong managing editor test

            wrongRssChannel.ManagingEditor = "This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor This in an invalid managing editor ";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.ManagingEditor = "This is a managing editor";

            #endregion

            #region wrong web master test

            wrongRssChannel.WebMaster = "This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster This in an invalid webmaster ";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.WebMaster = "This is a webmaster";

            #endregion

            #region wrong generator test

            wrongRssChannel.Generator = "This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator This in an invalid generator ";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Generator = "This is a generator";

            #endregion

            #region wrong docs test

            wrongRssChannel.Docs = "This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc This in an invalid doc ";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Docs = "This is a doc";

            #endregion

            #region wrong ttl test

            wrongRssChannel.Ttl = -22;
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Ttl = 42;

            #endregion

            #region wrong rating test

            wrongRssChannel.Rating = "This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating This in an invalid rating ";
            Assert.IsFalse(controller.controlData(wrongRssChannel));

            wrongRssChannel.Rating = "This is a rating";

            #endregion
        }
    }
}
