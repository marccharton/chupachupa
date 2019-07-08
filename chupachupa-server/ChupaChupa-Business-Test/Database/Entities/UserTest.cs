using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa.Entities;
using NUnit.Framework;

namespace ChupaChupa.Business.Test.Database.Entities
{
    [TestFixture]
    class UserTest
    {
        [Test]
        public void AddCategory()
        {
            var user = new User();
            var category = new Category();
            user.addCategory(category);

            Assert.IsNotNull(user.Categories);
            Assert.AreEqual(user.Categories.Count, 1);
        }

        [Test]
        public void SetCategoryList()
        {
            IList<Category> CategoryList = new List<Category>();
            CategoryList.Add(new Category());
            CategoryList.Add(new Category());
            CategoryList.Add(new Category());

            var user = new User();
            user.setCategoryList(CategoryList);

            Assert.IsNotNull(user.Categories);
            Assert.AreEqual(user.Categories.Count, 3);
        }


        [Test]
        public void AddRssChannel()
        {
            var user = new User();
            var rssChannel = new RssChannel();
            user.addRssChannel(rssChannel);

            Assert.IsNotNull(user.RssChannel);
            Assert.AreEqual(user.RssChannel.Count, 1);
        }

        [Test]
        public void SetRssChannelList()
        {
            IList<RssChannel> RssChannelList = new List<RssChannel>();
            RssChannelList.Add(new RssChannel());
            RssChannelList.Add(new RssChannel());
            RssChannelList.Add(new RssChannel());

            var user = new User();
            user.setRssChannelList(RssChannelList);

            Assert.IsNotNull(user.RssChannel);
            Assert.AreEqual(user.RssChannel.Count, 3);
        }


        [Test]
        public void AddRssItem()
        {
            var user = new User();
            var rssItem = new RssItem();
            user.addRssItem(rssItem);

            Assert.IsNotNull(user.RssItemsRead);
            Assert.AreEqual(user.RssItemsRead.Count, 1);
        }

        [Test]
        public void SetRssItemList()
        {
            IList<RssItem> RssItemList = new List<RssItem>();
            RssItemList.Add(new RssItem());
            RssItemList.Add(new RssItem());
            RssItemList.Add(new RssItem());

            var user = new User();
            user.setRssItemList(RssItemList);

            Assert.IsNotNull(user.RssItemsRead);
            Assert.AreEqual(user.RssItemsRead.Count, 3);
        }


        [Test]
        public void Update()
        {
            var user1 = new User()
            {
                LoginMail = "JoeLeboGoss",
                Password = "PassDeTeubé",
                OAuthToken = "OuechJaiUnCompteFacebook"
            };

            var user2 = new User();
            user2.update(user1);

            Assert.IsNotNull(user2);
            Assert.AreNotSame(user1, user2);
            Assert.AreEqual(user1.LoginMail, user2.LoginMail);
            Assert.AreEqual(user1.Password, user2.Password);
            Assert.AreEqual(user1.OAuthToken, user2.OAuthToken);
        }
    }
}
