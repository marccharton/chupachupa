using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.Test.ServiceContractImpl
{
    [TestFixture]
    class PublicServiceContractImplTest
    {
        [Test]
        [ExpectedException(typeof(FaultException))]
        public void createAccountNullCredantialsTest() {
            PublicChupaChupaService.PublicServiceContractClient client = new PublicChupaChupaService.PublicServiceContractClient();
            client.createAccount(null, null);
        }

        [Test]
        [ExpectedException(typeof(FaultException))]
        public void createAccountEmptyCredantialsTest()
        {
            PublicChupaChupaService.PublicServiceContractClient client = new PublicChupaChupaService.PublicServiceContractClient();
            client.createAccount("", "");
        }

        [Test]
        [ExpectedException(typeof(FaultException))]
        public void createAccountEmptyLoginTest()
        {
            PublicChupaChupaService.PublicServiceContractClient client = new PublicChupaChupaService.PublicServiceContractClient();
            client.createAccount("", "this is a password");
        }

        [Test]
        [ExpectedException(typeof(FaultException))]
        public void createAccountEmptyPasswordTest()
        {
            PublicChupaChupaService.PublicServiceContractClient client = new PublicChupaChupaService.PublicServiceContractClient();
            client.createAccount("this is a login", "");
        }

        [Test]
        [ExpectedException(typeof(FaultException))]
        public void createAccountAlreadyExistTest()
        {
            PublicChupaChupaService.PublicServiceContractClient client = new PublicChupaChupaService.PublicServiceContractClient();
            client.createAccount("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
        }

        [Test]
        public void createAccountValidTest()
        {
            PublicChupaChupaService.PublicServiceContractClient client = new PublicChupaChupaService.PublicServiceContractClient();
            client.createAccount("test-user1@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");

            UserDAO dao = new UserDAO();
            User user = dao.findByLoginAndPassword("test-user1@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");
            if (user == null) {
                throw new ArgumentNullException("User was not created...");
            }
            if (!dao.delete(user)) {
                throw new FaultException("User was not deleted from database");            
            }
        }
    }
}
