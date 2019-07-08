using ChupaChupa.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public class RssChannelParser : AbstractXmlNodeParser
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RssChannelParser));

        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";

        public RssChannelParser() : base() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/';

            _tagsMap = new Dictionary<string,XmlDocumentTag>();

            _tagsMap[prefix + "title"] = new XmlDocumentTag("Title", "title", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "link"] = new XmlDocumentTag("Link", "link", XmlDocumentTag.TAG_STATE.REQUIRED);
            _tagsMap[prefix + "description"] = new XmlDocumentTag("Description", "description", XmlDocumentTag.TAG_STATE.REQUIRED);

            _tagsMap[prefix + "language"] = new XmlDocumentTag("Language", "language", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "copyright"] = new XmlDocumentTag("Copyright", "copyright", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "managingEditor"] = new XmlDocumentTag("ManagingEditor", "managingEditor", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "webMaster"] = new XmlDocumentTag("WebMaster", "webMaster", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "pubDate"] = new XmlDocumentTag("PubDate", "pubDate", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "lastBuildDate"] = new XmlDocumentTag("LastBuildDate", "lastBuildDate", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "generator"] = new XmlDocumentTag("Generator", "generator", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "docs"] = new XmlDocumentTag("Docs", "docs", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "ttl"] = new XmlDocumentTag("Ttl", "ttl", XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "rating"] = new XmlDocumentTag("Rating", "rating", XmlDocumentTag.TAG_STATE.OPTIONNAL);

            _tagsMap[prefix + "image"] = new XmlDocumentTag("Image", "image", new ImageParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "cloud"] = new XmlDocumentTag("Cloud", "cloud", new CloudParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "textInput"] = new XmlDocumentTag("TextInput", "textInput", new TextInputParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "category"] = new XmlDocumentTag("RssCategory", "category", new RssChannelCategoryParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "skipDays"] = new XmlDocumentTag("SkipDays", "skipDays", new SkipDaysParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "skipHours"] = new XmlDocumentTag("SkipHours", "skipHours", new SkipHoursParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);
            _tagsMap[prefix + "item"] = new XmlDocumentTag("RssItems", "item", new RssItemParser(), XmlDocumentTag.TAG_STATE.OPTIONNAL);

        }

        public override bool parseData(XmlNode node) {
            _data = new RssChannel();
            if (node == null) {
                Logger.Error("This is not a rss channel");
                return false;
            }
            return base.parseData(node);
        }
    }
}
