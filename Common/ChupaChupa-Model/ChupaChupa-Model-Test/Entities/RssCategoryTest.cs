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
    class RssCategoryTest
    {
        [Test]
        public void Update()
        {
            var rssCategory1 = new RssCategory()
            {
                Domain = "categoryDomain",
                Name = "myCategory"
            };

            var rssCategory2 = new RssCategory();
            rssCategory2.update(rssCategory1);

            Assert.IsNotNull(rssCategory2);
            Assert.AreNotSame(rssCategory1, rssCategory2);
            Assert.AreEqual(rssCategory1.Domain, rssCategory2.Domain);
            Assert.AreEqual(rssCategory1.Name, rssCategory2.Name);
        }
    }
}
