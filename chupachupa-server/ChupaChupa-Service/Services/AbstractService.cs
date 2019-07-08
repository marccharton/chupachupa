using ChupaChupa.Business.Database.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace ChupaChupa.Service.Services
{
    public class AbstractService
    {
        protected UserDAO _userDao;
        protected Entities.User _user;

        public AbstractService() {
            _userDao = new UserDAO();
            _user = null;
        }

        public void findUserOrRaiseFaultException(Int64 userId, string errorMessage) {
            _user = _userDao.findById(userId);
            if (_user == null) {
                throw new FaultException(errorMessage);
            }
        }

        public void saveUserOrRaiseFaultException(string errorMessage) {
            if (_user != null) { 
                if (!_userDao.saveOrUpdate(_user)) {
                    throw new FaultException(errorMessage);
                }
            }
        } 
    }
}