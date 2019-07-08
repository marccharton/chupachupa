using ChupaChupa.Business.Database.Session;
using ChupaChupa.Entities;
using log4net;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Database.DAO
{
    public class RssChannelDAO : AbstractDAO<RssChannel>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RssChannelDAO));

        public RssChannelDAO() : base() { }

        public override IList<RssChannel> findAll()
        {
            return base.findAll();
        }
        public override RssChannel findById(Int64 id)
        {
            return base.findById(id);
        }
        public override bool delete(RssChannel obj)
        {
            return base.delete(obj);
        }
        public override bool saveOrUpdate(RssChannel obj)
        {
            return base.saveOrUpdate(obj);
        }

        public RssChannel findByRssLink(string rssLink) {
            RssChannel ret = null;

            using (var session = HibernateSession.getInstance().getSession()) {
                if (session != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            ret = session
                                .CreateCriteria(typeof(RssChannel))
                                .Add(Restrictions.Eq("RssLink", rssLink))
                                .UniqueResult<RssChannel>();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Logger.Error("Unable to query table " + typeof(RssChannel).Name + " because of: " + ex.Message);
                            ret = null;
                        }
                    }
                }
            }
            return ret;
        }
    }
}
