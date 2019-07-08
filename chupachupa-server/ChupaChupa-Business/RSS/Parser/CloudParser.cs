using ChupaChupa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public class CloudParser : AbstractXmlNodeParser
    {
        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string CLOUD_NODE_NAME = "cloud";

        public CloudParser() : base() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + CLOUD_NODE_NAME + ':';

            _attributesMap = new Dictionary<string, XmlAttributeTag>();

            _attributesMap[prefix + "domain"] = new XmlAttributeTag("Domain", "domain", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
            _attributesMap[prefix + "port"] = new XmlAttributeTag("Port", "port", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
            _attributesMap[prefix + "path"] = new XmlAttributeTag("Path", "path", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
            _attributesMap[prefix + "registerProcedure"] = new XmlAttributeTag("RegisterProcedure", "registerProcedure", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
            _attributesMap[prefix + "protocol"] = new XmlAttributeTag("Protocol", "protocol", XmlAttributeTag.ATTRIBUTE_STATE.REQUIRED);
        }

        public override bool parseData(XmlNode node) {
            _data = new Cloud();
            return base.parseData(node);
        }
    }
}
