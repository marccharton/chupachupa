using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.Test.ServiceContractImpl
{
    [TestFixture]
    class ServiceContractImplTest
    {
        #region test authenticate

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void authenticateNoCredentialsSpecifiedTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();
            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void authenticateNullCredentialsTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();

            client.ClientCredentials.UserName.UserName = null;
            client.ClientCredentials.UserName.Password = null;

            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void authenticateNullLoginCredentialsTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();

            client.ClientCredentials.UserName.UserName = null;
            client.ClientCredentials.UserName.Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b";

            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
        }

        [Test]
        [ExpectedException(typeof(MessageSecurityException))]
        public void authenticateNullPasswordCredentialsTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();

            client.ClientCredentials.UserName.UserName = "test-user@epitech.eu";
            client.ClientCredentials.UserName.Password = null;

            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
        }

        [Test]
        [ExpectedException(typeof(MessageSecurityException))]
        public void authenticateInvalidCredentialsTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();

            client.ClientCredentials.UserName.UserName = "invalid login";
            client.ClientCredentials.UserName.Password = "invalid password";

            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
        }

        [Test]
        public void authenticateValidCredentialsTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();

            client.ClientCredentials.UserName.UserName = "test-user@epitech.eu";
            client.ClientCredentials.UserName.Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b";

            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");

            client.disonnect();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void disconnectBeforeAuthenticateTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();

            client.ClientCredentials.UserName.UserName = "test-user@epitech.eu";
            client.ClientCredentials.UserName.Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b";

            client.disonnect();

            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
        }

        #endregion


    }
}
