using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa.Entities;
using NUnit.Framework;

namespace ChupaChupa.Entities.Test.Database.Entities
{
    [TestFixture]
    class RssItemTest
    {

        [Test]
        public void AddRssCategory()
        {
            var rssItem = new RssItem();
            var rssCategory = new RssCategory();
            rssItem.addRssCategory(rssCategory);

            Assert.IsNotNull(rssItem.RssCategory);
            Assert.AreEqual(rssItem.RssCategory.Count, 1);
        }

        [Test]
        public void SetRssCategoryList()
        {
            IList<RssCategory> RssCategoryList = new List<RssCategory>();
            RssCategoryList.Add(new RssCategory());
            RssCategoryList.Add(new RssCategory());
            RssCategoryList.Add(new RssCategory());

            var rssItem = new RssItem();
            rssItem.setRssCategoryList(RssCategoryList);

            Assert.IsNotNull(rssItem.RssCategory);
            Assert.AreEqual(rssItem.RssCategory.Count, 3);
        }

        [Test]
        public void Update()
        {
            var cat1 = new RssItem()
            {
                Title = "ouech tonton",
                Guid = "sdcsdc",
                Author = "ME",
                Description = "super youhou"
            };
            var cat2 = new RssItem();

            cat2.update(cat1);

            Assert.IsNotNull(cat2);
            Assert.AreNotSame(cat1, cat2);
            Assert.AreEqual(cat1.Title, cat2.Title);
            Assert.AreEqual(cat1.Guid, cat2.Guid);
            Assert.AreEqual(cat1.Author, cat2.Author);
            Assert.AreEqual(cat1.Description, cat2.Description);
        }

    }
}
