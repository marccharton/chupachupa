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
    class CloudControllerTest
    {
        [Test]
        public void controlCloudControllerTest() {
            CloudController controller = new CloudController();
            Cloud validCloud = new Cloud();
            Cloud wrongCloud = new Cloud();

            validCloud.Domain = "http://fakedomain.com";
            validCloud.Port = 22;
            validCloud.Path = "This is a path";
            validCloud.RegisterProcedure = "This is a procedure";
            validCloud.Protocol = "This is a protocol";

            Assert.IsTrue(controller.controlData(validCloud));

            wrongCloud.Domain = "http://fakedomain.com";
            wrongCloud.Port = 22;
            wrongCloud.Path = "This is a path";
            wrongCloud.RegisterProcedure = "This is a procedure";
            wrongCloud.Protocol = "This is a protocol";

            #region wrong domain test
            
            wrongCloud.Domain = "http://fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu.fakedomain.com.higher.than.limit.eu";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.Domain = "";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.Domain = null;
            Assert.IsFalse(controller.controlData(wrongCloud));
            
            wrongCloud.Domain = "http://fakedomain.com";

            #endregion

            #region wrong port test

            wrongCloud.Port = 65537;
            Assert.IsFalse(controller.controlData(wrongCloud));
            
            wrongCloud.Port = -65537;
            Assert.IsFalse(controller.controlData(wrongCloud));
            
            wrongCloud.Port = 22;
            
            #endregion

            #region wrong path test

            wrongCloud.Path = "This is an invalid path This is an invalid path This is an invalid path This is an invalid path This is an invalid pathThis is an invalid path This is an invalid path This is an invalid pathThis is an invalid pathThis is an invalid pathThis is an invalid path This is an invalid path This is an invalid path";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.Path = "";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.Path = null;
            Assert.IsFalse(controller.controlData(wrongCloud));
 
            wrongCloud.Path = "This is a path";
 
            #endregion

            #region wrong register procedure test

            wrongCloud.RegisterProcedure = "This is an invalid  procedure This is an invalid  procedure This is an invalid  procedure This is an invalid  procedureThis is an invalid  procedure This is an invalid  procedureThis is an invalid  procedureThis is an invalid  procedureThis is an invalid  procedureThis is an invalid  procedurevThis is an invalid  procedure This is an invalid  procedure";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.RegisterProcedure = "";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.RegisterProcedure = null;
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.RegisterProcedure = "This is a procedure";

            #endregion

            #region wrong protocol

            wrongCloud.Protocol = "This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol This is an invalid protocol ";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.Protocol = "";
            Assert.IsFalse(controller.controlData(wrongCloud));

            wrongCloud.Protocol = null;
            Assert.IsFalse(controller.controlData(wrongCloud));

            #endregion
        }
    }
}
