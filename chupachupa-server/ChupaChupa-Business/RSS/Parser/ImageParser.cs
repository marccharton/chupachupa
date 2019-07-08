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
    public class ImageParser : AbstractXmlNodeParser
    {
        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string IMAGE_NODE_NAME = "image";

        public ImageParser() : base() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + IMAGE_NODE_NAME + '/';
            
            _tagsMap = new Dictionary<string,XmlDocumentTag>();

            _tagsMap[prefix + "url"] = new XmlDocumentTag("Url", "url", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "title"] = new XmlDocumentTag("Title", "title", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "link"] = new XmlDocumentTag("Link", "link", XmlDocumentTag.TAG_STATE.REQUIRED);

            _tagsMap[prefix + "width"] = new XmlDocumentTag("Width", "width", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "height"] = new XmlDocumentTag("Height", "height", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "description"] = new XmlDocumentTag("Description", "description", XmlDocumentTag.TAG_STATE.OPTIONNAL);
        }

        public override bool parseData(XmlNode node) {
            _data = new Image();
            return base.parseData(node);
        }
    }
}
