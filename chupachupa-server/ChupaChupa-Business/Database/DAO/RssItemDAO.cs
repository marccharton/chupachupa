using ChupaChupa.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Database.DAO
{
    public class RssItemDAO : AbstractDAO<RssItem>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RssItemDAO));

        public RssItemDAO() : base() { }

        public override IList<RssItem> findAll()
        {
            return base.findAll();
        }

        public override RssItem findById(Int64 id)
        {
            return base.findById(id);
        }
        public override bool delete(RssItem obj)
        {
            return base.delete(obj);
        }

        public override bool saveOrUpdate(RssItem obj)
        {
            return base.saveOrUpdate(obj);
        }

    }
}
