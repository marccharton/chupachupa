using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa_WcfLibrary.ServiceContractsImpl
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        string authenticate(string login, string password);
    }
}