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
    class CategoryTest
    {
        [Test]
        public void AddRssChannel()
        {
            var category = new Category();
            var rssChannel = new RssChannel();
            category.addRssChannel(rssChannel);
            
            Assert.IsNotNull(category.RssChannels);
            Assert.AreEqual(category.RssChannels.Count, 1);
        }

        [Test]
        public void SetRssChannelList()
        {
            IList<RssChannel> channels = new List<RssChannel>();
            channels.Add(new RssChannel());
            channels.Add(new RssChannel());
            channels.Add(new RssChannel());

            var category = new Category();
            category.setRssChannelList(channels);

            Assert.IsNotNull(category.RssChannels);
            Assert.AreEqual(category.RssChannels.Count, 3);
        }

        [Test]
        public void Update()
        {
            var cat1 = new Category(){Name = "myCat", User = new User()};
            var cat2 = new Category();

            cat2.update(cat1);

            Assert.IsNotNull(cat2);
            Assert.AreNotSame(cat1, cat2);
            Assert.AreEqual(cat1.Name, cat2.Name);
            Assert.AreEqual(cat1.User, cat2.User);
        }

    }
}
