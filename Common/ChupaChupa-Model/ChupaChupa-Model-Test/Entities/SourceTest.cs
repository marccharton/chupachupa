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
    class SourceTest
    {
        [Test]
        public void Update()
        {
            var source1 = new Source()
            {
                Url = "www.mysource.com"
            };

            var source2 = new Source();
            source2.update(source1);

            Assert.IsNotNull(source2);
            Assert.AreNotSame(source1, source2);
            Assert.AreEqual(source1.Url, source2.Url);
        }
    }
}
