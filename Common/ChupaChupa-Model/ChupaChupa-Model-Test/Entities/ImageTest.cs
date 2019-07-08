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
    class ImageTest
    {
        [Test]
        public void Update()
        {
            var image1 = new Image()
            {
                Url = "www.monimage.fr",
                Title = "Monimage",
                Link = "www.monimage.com/monimage"
            };

            var image2 = new Image();
            image2.update(image1);

            Assert.IsNotNull(image2);
            Assert.AreNotSame(image1, image2);
            Assert.AreEqual(image1.Title, image2.Title);
            Assert.AreEqual(image1.Url, image2.Url);
            Assert.AreEqual(image1.Link, image2.Link);
        }
    }
}
