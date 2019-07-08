using ChupaChupa.Entities;
using ChupaChupa.Business.Database.Session;
using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Database.DAO
{
    public abstract class AbstractDAO<T> : IDAO<T> where T : class, IEntity, new()
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AbstractDAO<T>));

        public AbstractDAO() {
        }

        public virtual IList<T> findAll() {
            IList<T> ret = new List<T>();
 
            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null) { 
                    using (var transaction = session.BeginTransaction())
                    { 
                        try
                        {
                            ret = session.CreateQuery(@"select e from " + typeof(T).Name + " e").List<T>();
                            transaction.Commit();
                        }
                        catch (Exception ex) 
                        {
                            Logger.Error("Unable to query table " + typeof(T).Name + " because: " + ex.Message);
                            ret = new List<T>();
                        }
                    }
                }
            }
            return ret;
        }

        public virtual T        findById(Int64 id) {
            T ret = null;
            IQuery query;

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null) { 
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            query = session.CreateQuery(@"select e from " + typeof(T).Name + " e where e.IdEntity = :IdEntity");
                            query.SetInt64("IdEntity", id);
                            ret = query.UniqueResult<T>();
                            //ret = _session.Get<T>(id);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Unable to query table " + typeof(T).Name + " because: " + ex.Message);
                            ret = null;
                        }
                    }
                }
            }
            return ret;
        }
        
        public virtual bool     delete(T obj) {

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null) {
                    using (var transaction = session.BeginTransaction())
                    {
                        var queryString = string.Format("delete {0} where id = :id", typeof(T).Name);
                        session.CreateQuery(queryString)
                               .SetParameter("id", obj.IdEntity)
                               .ExecuteUpdate();
                        transaction.Commit();
                    }
                }
            }
            return true;
        }

        public virtual bool     saveOrUpdate(T obj) {

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null) {
                    using (var transaction = session.BeginTransaction()) {
                        try
                        {
                            session.SaveOrUpdate(obj);
                            transaction.Commit();
                        }
                        catch (NHibernate.Exceptions.GenericADOException ex)
                        {
                            Logger.Error("Unable to save or update object because: " + ex.Message);
                        }
                    
                    }
                }
            }
            return true;
        }        
    }
}
