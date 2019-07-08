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
    class EnclosureTest
    {
        [Test]
        public void Update()
        {
            var enclosure1 = new Enclosure()
            {
                Length = 10,
                Url = "www.myenclosure.com",
                Type = "Typedemonenclosure"
            };

            var enclosure2 = new Enclosure();
            enclosure2.update(enclosure1);

            Assert.IsNotNull(enclosure2);
            Assert.AreNotSame(enclosure1, enclosure2);
            Assert.AreEqual(enclosure1.Length, enclosure2.Length);
            Assert.AreEqual(enclosure1.Url, enclosure2.Url);
            Assert.AreEqual(enclosure1.Type, enclosure2.Type);
        }
    }
}
