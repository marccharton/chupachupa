using ChupaChupa.Business.Database.DAO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.Validator
{
    class AuthenticationValidator : UserNamePasswordValidator
    {
        public override void Validate(string username, string password) {
            if (username == null || password == null) {
                throw new ArgumentNullException(Resources.InvalidNullCredentials);
            }

            UserDAO dao = new UserDAO();

            if (dao.findByLoginAndPassword(username, password) == null) {
                throw new FaultException(Resources.InvalidCredentials);
            }
        }
    }
}
