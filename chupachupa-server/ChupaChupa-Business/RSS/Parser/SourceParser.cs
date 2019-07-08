using ChupaChupa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public class SourceParser : AbstractXmlNodeParser
    {
        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string ITEM_NODE_NAME = "item";
        private const string SOURCE_NODE_NAME = "source";

        public SourceParser() : base() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + ITEM_NODE_NAME + '/' + SOURCE_NODE_NAME;

            _attributesMap = new Dictionary<string, XmlAttributeTag>();
            _attributesMap[prefix + ":url"] = new XmlAttributeTag("Url", "url", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
        }

        public override bool parseData(XmlNode node) {
            _data = new Source();
            return base.parseData(node);
        }

    }
}
