using ChupaChupa.Business.Controller;
using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.Services
{
    class UserService : AbstractService
    {
        public void createAccountService(string login, string password) {
            Tool.ToolBox.controlStringNotEmptyWithFaultException(login, Resources.CreateAccountEmptyCredentials);
            Tool.ToolBox.controlStringNotEmptyWithFaultException(password, Resources.CreateAccountEmptyCredentials);

            if (_userDao.findByLoginAndPassword(login, password) != null) {
                throw new FaultException(Resources.CreateAccountAlreadyExisting);
            }

            _user = new User();
            _user.LoginMail = login;
            _user.Password = password;

            UserController controller = new UserController();
            if (!controller.controlData(_user)) {
                throw new FaultException(Resources.CreateAccountInvalidProperties);
            }

            this.saveUserOrRaiseFaultException(Resources.CreateAccountDatabaseError);
        }

        public void changePassword(Int64 userId, string password) {
            Tool.ToolBox.controlStringNotEmptyWithFaultException(password, Resources.ChangePasswordEmptyCredential);

            this.findUserOrRaiseFaultException(userId, Resources.ChangePasswordUserUnknown);

            if (password.CompareTo(_user.Password) != 0) {
                _user.Password = password;
            }

            UserController controller = new UserController();
            if (!controller.controlData(_user)) {
                throw new FaultException(Resources.ChangePasswordInvalidProperty);
            }

            this.saveUserOrRaiseFaultException(Resources.ChangePasswordUserUnknown);
        }
    }
}
