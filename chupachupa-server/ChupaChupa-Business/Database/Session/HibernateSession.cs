using log4net;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Database.Session
{
    public class HibernateSession
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HibernateSession));

        // Singleton Pattern
        private static HibernateSession s_hibernateSession = null;

        public static HibernateSession getInstance() {
            if (s_hibernateSession == null) {
                s_hibernateSession = new HibernateSession();
            }
            return s_hibernateSession;
        }

        // Class methods and attributes
        private ISessionFactory _sessionFactory;

        public HibernateSession() {
            _sessionFactory = null;
        }

        public bool openSession() {
            try
            {
                _sessionFactory = new Configuration().Configure().BuildSessionFactory();
            }
            catch (Exception ex) 
            {
                Logger.Error("Unable to open session with NHibernate: " + ex.Message);
                _sessionFactory = null;
                return false;
            }
            return true;
        }

        public void closeSession() {
            if (_sessionFactory != null) {
                _sessionFactory.Close();
                _sessionFactory = null;
            }
        }

        public ISession getSession() {
            if (_sessionFactory == null) {
                if (!this.openSession()) {
                    return null;
                }
            }
            return _sessionFactory.OpenSession();
        }
    }
}
