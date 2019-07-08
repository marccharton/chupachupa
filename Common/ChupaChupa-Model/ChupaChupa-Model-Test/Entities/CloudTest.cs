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
    class CloudTest
    {
        [Test]
        public void Update()
        {
            var cloud1 = new Cloud()
            {
                Domain = "dcsc",
                Port = 4747,
                Path = "dc",
                Protocol = "dc",
                RegisterProcedure = "dc"
            };

            var cloud2 = new Cloud();
            cloud2.update(cloud1);

            Assert.IsNotNull(cloud2);
            Assert.AreNotSame(cloud1, cloud2);
            Assert.AreEqual(cloud1.Domain, cloud2.Domain);
            Assert.AreEqual(cloud1.Port, cloud2.Port);
            Assert.AreEqual(cloud1.Path, cloud2.Path);
            Assert.AreEqual(cloud1.Protocol, cloud2.Protocol);
            Assert.AreEqual(cloud1.RegisterProcedure, cloud2.RegisterProcedure);
        }
    }
}
