using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace ChupaChupa.Service.ServiceContract
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IPublicServiceContract
    {
        [OperationContract(IsOneWay = false)]
        void createAccount(string login, string password);
    }
}