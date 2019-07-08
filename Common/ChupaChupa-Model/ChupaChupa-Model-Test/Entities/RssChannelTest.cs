using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa_Model.Entities;
using NUnit.Framework;

namespace ChupaChupa_Server_Test.Database.Entities
{
    [TestFixture]
    class RssChannelTest
    {
        [Test]
        public void AddRssItem()
        {
            var rssChannel = new RssChannel();
            var rssItem = new RssItem();
            rssChannel.addRssItem(rssItem);

            Assert.IsNotNull(rssChannel.RssItems);
            Assert.AreEqual(rssChannel.RssItems.Count, 1);
        }

        [Test]
        public void SetRssItemList()
        {
            IList<RssItem> RssItemList = new List<RssItem>();
            RssItemList.Add(new RssItem());
            RssItemList.Add(new RssItem());
            RssItemList.Add(new RssItem());

            var rssChannel = new RssChannel();
            rssChannel.setRssItemList(RssItemList);

            Assert.IsNotNull(rssChannel.RssItems);
            Assert.AreEqual(rssChannel.RssItems.Count, 3);
        }

        [Test]
        public void AddRssCategory()
        {
            var rssChannel = new RssChannel();
            var rssCategory = new RssCategory();
            rssChannel.addRssCategory(rssCategory);

            Assert.IsNotNull(rssChannel.RssCategory);
            Assert.AreEqual(rssChannel.RssCategory.Count, 1);
        }

        [Test]
        public void SetRssCategoryList()
        {
            IList<RssCategory> RssCategoryList = new List<RssCategory>();
            RssCategoryList.Add(new RssCategory());
            RssCategoryList.Add(new RssCategory());
            RssCategoryList.Add(new RssCategory());

            var rssChannel = new RssChannel();
            rssChannel.setRssCategoryList(RssCategoryList);

            Assert.IsNotNull(rssChannel.RssCategory);
            Assert.AreEqual(rssChannel.RssCategory.Count, 3);
        }

        [Test]
        public void AddSkipDays()
        {
            var rssChannel = new RssChannel();
            var skipDays = new SkipDays();
            rssChannel.addSkipDays(skipDays);

            Assert.IsNotNull(rssChannel.SkipDays);
            Assert.AreEqual(rssChannel.SkipDays.Count, 1);
        }

        [Test]
        public void SetSkipDaysList()
        {
            IList<SkipDays> SkipDaysList = new List<SkipDays>();
            SkipDaysList.Add(new SkipDays());
            SkipDaysList.Add(new SkipDays());
            SkipDaysList.Add(new SkipDays());

            var rssChannel = new RssChannel();
            rssChannel.setSkipDaysList(SkipDaysList);

            Assert.IsNotNull(rssChannel.SkipDays);
            Assert.AreEqual(rssChannel.SkipDays.Count, 3);
        }

        [Test]
        public void AddSkipHours()
        {
            var rssChannel = new RssChannel();
            var skipHours = new SkipHours();
            rssChannel.addSkipHours(skipHours);

            Assert.IsNotNull(rssChannel.SkipHours);
            Assert.AreEqual(rssChannel.SkipHours.Count, 1);
        }

        [Test]
        public void SetSkipHoursList()
        {
            IList<SkipHours> SkipHoursList = new List<SkipHours>();
            SkipHoursList.Add(new SkipHours());
            SkipHoursList.Add(new SkipHours());
            SkipHoursList.Add(new SkipHours());

            var rssChannel = new RssChannel();
            rssChannel.setSkipHoursList(SkipHoursList);

            Assert.IsNotNull(rssChannel.SkipHours);
            Assert.AreEqual(rssChannel.SkipHours.Count, 3);
        }

        [Test]
        public void Update()
        {
            var dt = new DateTime(1999, 12, 06);
            var cloud = new Cloud() { Domain = "dcsc", Port = 4747, Path = "dc", Protocol = "dc", RegisterProcedure = "dc" };
            var textInput = new TextInput() { Description = "un text input super", Name = "mytextipnut2", Link = "www.textINput.com", Title = "MY TEXT INPUT" };
            var image = new Image() { Url = "www.monimage.fr", Title = "Monimage", Link = "www.monimage.com/monimage" };

            var rssChannel1 = new RssChannel()
            {
                RssLink = "www.monchanneldelamortquitue.com",
                Title = "Mon channel",
                Link = "www.myLink.com",
                LastBuildDate = dt,
                PubDate = dt,
                Description = "super link ce mylink !",
                Cloud = cloud,
                TextInput = textInput,
                Image = image
            };

            var rssChannel2 = new RssChannel();
            rssChannel2.update(rssChannel1);

            Assert.IsNotNull(rssChannel2);
            Assert.AreNotSame(rssChannel1, rssChannel2);
            Assert.AreEqual(rssChannel1.RssLink, rssChannel2.RssLink);
            Assert.AreEqual(rssChannel1.Title, rssChannel2.Title);
            Assert.AreEqual(rssChannel1.Link, rssChannel2.Link);
            Assert.AreEqual(rssChannel1.LastBuildDate, rssChannel2.LastBuildDate);
            Assert.AreEqual(rssChannel1.PubDate, rssChannel2.PubDate);
            Assert.AreEqual(rssChannel1.Description, rssChannel2.Description);
            Assert.AreEqual(rssChannel1.Cloud, rssChannel2.Cloud);
            Assert.AreEqual(rssChannel1.TextInput, rssChannel2.TextInput);
            Assert.AreEqual(rssChannel1.Image, rssChannel2.Image);
        }
    }
}
