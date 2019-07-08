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
    public class TextInputParser : AbstractXmlNodeParser
    {
        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string TEXT_INPUT_NODE_NAME = "textInput";

        public TextInputParser() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + TEXT_INPUT_NODE_NAME + '/';
            
            _tagsMap = new Dictionary<string, XmlDocumentTag>();

            _tagsMap[prefix + "title"] = new XmlDocumentTag("Title", "title", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "description"] = new XmlDocumentTag("Description", "description", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "name"] = new XmlDocumentTag("Name", "name", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "link"] = new XmlDocumentTag("Link", "link", XmlDocumentTag.TAG_STATE.REQUIRED);
        }

        public override bool parseData(XmlNode node) {
            _data = new TextInput();
            return base.parseData(node);
        }
    }
}
