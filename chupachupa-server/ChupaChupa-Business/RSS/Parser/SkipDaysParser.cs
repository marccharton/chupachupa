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
    class SkipDaysParser : AbstractXmlNodeParser
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SkipDaysParser));

        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string SKIP_DAYS_NODE_NAME = "skipDays";

        public SkipDaysParser() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + SKIP_DAYS_NODE_NAME + '/';


            _tagsMap = new Dictionary<string, XmlDocumentTag>();

            _tagsMap[prefix + "day"] = new XmlDocumentTag("Day", "day", XmlDocumentTag.TAG_STATE.OPTIONNAL);
        }

        public override bool parseData(XmlNode node) {
            bool success = true;

            if (node == null) {
                Logger.Error("Cannot parse elements because root node is null");
                return false;
            }

            success = this.parseTags(node);

            return success;
        }

        private bool parseTags(XmlNode node) {
            bool success = true;
            XmlDocumentTag tag;
            List<SkipDays> skipDaysList = new List<SkipDays>();;

            if (_tagsMap == null || node.ChildNodes == null) {
                return success;
            }

            foreach (XmlNode child in node.ChildNodes) {
                _tagsMap.TryGetValue(this.getXPathForNode(child), out tag);
                if (tag == null) {
                    Logger.Error("Unknown tag " + this.getXPathForNode(child) + " found");
                    return false;
                }
                SkipDays day = new SkipDays();
                success = this.setSkipDayPropertyValue(day, tag.PropertyName, child.InnerText);
                if (!success) {
                    break;
                }
                skipDaysList.Add(day);
            }
            if (success) { 
                _data = skipDaysList;
            }
            return success;
        }

        private bool setSkipDayPropertyValue(SkipDays skipDay, String propertyName, object value) {
            if (propertyName == null || propertyName.Length == 0) {
                return true;
            }
            PropertyInfo info = skipDay.GetType().GetProperty(propertyName);
            if (info == null) {
                Logger.Error("Unable to get property info " + propertyName);
                return false;
            }
            try {
                info.SetValue(skipDay, Convert.ChangeType(value, info.PropertyType), null);
            } catch (Exception ex) {
                Logger.Error("Unable to set value for property " + propertyName + " because: " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
