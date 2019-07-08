using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public class RssChannelCategoryParser : RssCategoryParser
    {
        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string CATEGORY_NODE_NAME = "category";

        public RssChannelCategoryParser() : base() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + CATEGORY_NODE_NAME;

            _attributesMap = new Dictionary<string, XmlAttributeTag>();
            _attributesMap[prefix + ":domain"] = new XmlAttributeTag("Domain", "domain", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
        }

        public override bool parseData(XmlNode node) {
            return base.parseData(node);
        }

    }
}
