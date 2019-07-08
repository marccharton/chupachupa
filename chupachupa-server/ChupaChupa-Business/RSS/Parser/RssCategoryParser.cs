using ChupaChupa.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public class RssCategoryParser : AbstractXmlNodeParser {

        private static readonly ILog Logger = LogManager.GetLogger(typeof(RssCategoryParser));

        public RssCategoryParser() : base() { 
        }
        
        public override bool parseData(XmlNode node) {
            bool success = true;
            
            _data = new RssCategory();
            if (node == null) {
                Logger.Error("Unable to parse category node because it is null");
                return false;
            }
            success = this.setDataPropertyValue("Name", node.InnerText) && base.parseData(node);
            if (success) {
                success = mapRssCategoryAsList();
            }
            return success;
        }

        private bool mapRssCategoryAsList() {
            RssCategory current = _data as RssCategory;
            List<RssCategory> values = new List<RssCategory>();
            String tmp;
            String[] tab;

            _data = values;

            if (current == null) {
                Logger.Error("Error while mapping rss categories");
                return false;
            }
            
            tmp = current.Name;
            tab = tmp.Split('/');
            if (tab == null || tab.Length == 0 || current.Name.Length == 0) {
                return true;
            }
            foreach (String value in tab) {
                values.Add(new RssCategory() { Name = value, Domain = current.Domain });
            }
            return true;
        }
     }
}
