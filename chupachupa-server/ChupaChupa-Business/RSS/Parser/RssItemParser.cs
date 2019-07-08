using ChupaChupa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    class RssItemParser : AbstractXmlNodeParser
    {
        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string ITEM_NODE_NAME = "item";

        public RssItemParser() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + ITEM_NODE_NAME + '/';

            _tagsMap = new Dictionary<string, XmlDocumentTag>();

            _tagsMap[prefix + "title"] = new XmlDocumentTag("Title", "title", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "link"] = new XmlDocumentTag("Link", "link", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "description"] = new XmlDocumentTag("Description", "description", XmlDocumentTag.TAG_STATE.REQUIRED);

            _tagsMap[prefix + "author"] = new XmlDocumentTag("Author", "author", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "comments"] = new XmlDocumentTag("Comments", "comments", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "guid"] = new XmlDocumentTag("Guid", "guid", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "pubDate"] = new XmlDocumentTag("PubDate", "pubDate", XmlDocumentTag.TAG_STATE.OPTIONNAL);

            _tagsMap[prefix + "category"] = new XmlDocumentTag("RssCategory", "category", new RssItemCategoryParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "enclosure"] = new XmlDocumentTag("Enclosure", "enclosure", new EnclosureParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "source"] = new XmlDocumentTag("Source", "source", new SourceParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
        }

        public override bool parseData(XmlNode node) {
            _data = new RssItem();
            return base.parseData(node);
        }
    }
}
