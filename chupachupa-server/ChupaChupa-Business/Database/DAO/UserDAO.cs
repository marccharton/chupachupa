using ChupaChupa.Entities;
using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using ChupaChupa.Business.Database.Session;

namespace ChupaChupa.Business.Database.DAO
{
    public class UserDAO : AbstractDAO<User>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UserDAO));

        public UserDAO() : base()   { }

        public override IList<User> findAll()
        {
            return base.findAll();
        }
        public override User findById(Int64 id)
        {
            return base.findById(id);
        }
        public override bool delete(User obj)
        {
            return base.delete(obj);
        }

        public override bool saveOrUpdate(User obj)
        {
            return base.saveOrUpdate(obj);
        }

        public virtual User findByLoginAndPassword(string login, string password)
        {
            User ret = null;

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null) {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            ret = session
                                .CreateCriteria(typeof(User))
                                .Add(Restrictions.Eq("LoginMail", login))
                                .Add(Restrictions.Eq("Password", password))
                                .UniqueResult<User>();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Unable to query table " + typeof(User).Name + " because of: " + ex.Message);
                            ret = null;
                        }
                    }
                }
            }
            return ret;
        }

        public virtual User findByToken(string token)
        {
            User ret = null;
            IQuery query;

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            query = session.CreateQuery(@"select e from " + typeof(User).Name + " e where e.OAuthToken = :Token");
                            query.SetString("Token", token);
                            ret = query.UniqueResult<User>();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Unable to query table " + typeof(User).Name + " because of: " + ex.Message);
                            ret = null;
                        }
                    }
                }
            }
            return ret;
        }

    }
}
