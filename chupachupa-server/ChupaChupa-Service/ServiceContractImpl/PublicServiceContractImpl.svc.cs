using ChupaChupa.Service.ServiceContract;
using ChupaChupa.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChupaChupa.Service.ServiceContractImpl
{
    public class PublicServiceContractImpl : IPublicServiceContract
    {
        public PublicServiceContractImpl() {
        }

        public void createAccount(String login, String password) {
            new UserService().createAccountService(login, password);
        }
    }
}
