using ChupaChupa.Entities;
using log4net;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using ChupaChupa.Business.Database.Session;

namespace ChupaChupa.Business.Database.DAO
{
    public class CategoryDAO : AbstractDAO<Category>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CategoryDAO));

        public CategoryDAO() : base() { }

        public override IList<Category> findAll()
        {
            return base.findAll();
        }

        public override Category findById(Int64 id)
        {
            return base.findById(id);
        }
        public override bool delete(Category obj)
        {
            return base.delete(obj);
        }

        public override bool saveOrUpdate(Category obj)
        {
            return base.saveOrUpdate(obj);
        }

        public Category findByName(string name) {
            Category ret = null;

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null) {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            ret = session
                                .CreateCriteria(typeof(Category))
                                .Add(Restrictions.Eq("Name", name))
                                .UniqueResult<Category>();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Unable to query table " + typeof(Category).Name + " because: " + ex.Message);
                            ret = null;
                        }
                    }
                }
            }
            return ret;
        }

        public Category findByUserAndName(User usr, string name)
        {
            Category ret = null;

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null) {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            ret = session
                                .CreateCriteria(typeof(Category))
                                .Add(Restrictions.Eq("User", usr))
                                .UniqueResult<Category>();

                            //query = _session.CreateQuery(@"select e from " + typeof(Category).Name + " e where e.Name = :Name");
                            //query.SetString("Name", name);
                            //ret = query.UniqueResult<Category>();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Unable to query table " + typeof(Category).Name + " because: " + ex.Message);
                            ret = null;
                        }
                    }
                }
            }
            return ret;
        }

    }
}
