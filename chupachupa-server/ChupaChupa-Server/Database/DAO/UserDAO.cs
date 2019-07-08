using ChupaChupa_Model.Entities;
using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;

namespace ChupaChupa_Server.Database.DAO
{
    public class UserDAO : AbstractDAO<User>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UserDAO));

        public UserDAO() : base()   { }

        public override IList<User> findAll()
        {
            return base.findAll();
        }
        public override User findById(int id)
        {
            return base.findById(id);
        }
        public override bool delete(User obj)
        {
            return base.delete(obj);
        }
        public override bool saveOrUpdate(User obj)
        {
            //var found = findByLoginAndPassword(obj.LoginMail, obj.Password);
            //if (found != null)
            //{
            //    obj.update(found);
            //    return base.saveOrUpdate(obj);
            //}
            //found = findByToken(obj.OAuthToken);
            //if (found != null)
            //{
            //    obj.IdEntity = found.IdEntity;
            //    return base.saveOrUpdate(obj);
            //}
            return base.saveOrUpdate(obj);
        }

        public virtual User findByLoginAndPassword(string login, string password)
        {
            User ret = null;
            IQuery query;

            if (_session != null)
            {
                using (_transaction = _session.BeginTransaction())
                {
                    try
                    {
                        ret = _session
                            .CreateCriteria(typeof(User))
                            .Add(Restrictions.Eq("LoginMail", login))
                            .Add(Restrictions.Eq("Password", password))
                            .UniqueResult<User>();

                        //query = _session.CreateQuery(@"select e from " + typeof(User).Name + " e where e.LoginMail = :Login and e.Password = :Password");
                        //query.SetString("Login", login);
                        //query.SetString("Password", password);
                        //ret = query.UniqueResult<User>();
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to query table " + typeof(User).Name + " because of: " + ex.Message);
                        ret = null;
                    }
                }
            }
            return ret;
        }

        public virtual User findByToken(string token)
        {
            User ret = null;
            IQuery query;

            if (_session != null)
            {
                using (_transaction = _session.BeginTransaction())
                {
                    try
                    {
                        ret = _session
                            .CreateCriteria(typeof(User))
                            .Add(Restrictions.Eq("OAuthToken", token))
                            .UniqueResult<User>();
                        //query = _session.CreateQuery(@"select e from " + typeof(User).Name + " e where e.OAuthToken = :Token");
                        //query.SetString("Token", token);
                        //ret = query.UniqueResult<User>();
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Unable to query table " + typeof(User).Name + " because of: " + ex.Message);
                        ret = null;
                    }
                }
            }
            return ret;
        }

    }
}
