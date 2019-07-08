using ChupaChupa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public class EnclosureParser : AbstractXmlNodeParser
    {
        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string ITEM_NODE_NAME = "item";
        private const string ENCLOSURE_NODE_NAME = "enclosure";

        public EnclosureParser() : base() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + ITEM_NODE_NAME + '/' + ENCLOSURE_NODE_NAME + ':';

            _attributesMap = new Dictionary<string, XmlAttributeTag>();

            _attributesMap[prefix + "url"] = new XmlAttributeTag("Url", "url", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
            _attributesMap[prefix + "length"] = new XmlAttributeTag("Length", "length", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
            _attributesMap[prefix + "type"] = new XmlAttributeTag("Type", "type", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
        }

        public override bool parseData(XmlNode node) {
            _data = new Enclosure();
            return base.parseData(node);
        }


    }
}
