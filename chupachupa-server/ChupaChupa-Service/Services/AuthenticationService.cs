using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.Services
{
    class AuthenticationService
    {
        public Int64 authenticate(string login, string password) {
            UserDAO dao = new UserDAO();
            User user = dao.findByLoginAndPassword(login, password);

            if (user == null) {
                return -1;
            }
            return user.IdEntity;
        }
    }
}
