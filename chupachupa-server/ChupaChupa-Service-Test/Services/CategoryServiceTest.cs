using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ChupaChupa.Service.Test.Services
{
    [TestFixture]
    class CategoryServiceTest
    {
        [Test]
        public void DropCategoryValidTest()
        {
            ChupaChupaService.ServiceContractClient client = new ChupaChupaService.ServiceContractClient();

            client.ClientCredentials.UserName.UserName = "test-user@epitech.eu";
            client.ClientCredentials.UserName.Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b";

            client.authenticate("test-user@epitech.eu", "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b");

            //client.dropCategory();
        }
        
    }
}
