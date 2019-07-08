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
    class SkipHoursParser : AbstractXmlNodeParser
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(SkipHoursParser));

        private const string ROOT_NODE_NAME = "rss";
        private const string CHANNEL_NODE_NAME = "channel";
        private const string SKIP_HOURS_NODE_NAME = "skipHours";

        public SkipHoursParser() {
            String prefix = '/' + ROOT_NODE_NAME + '/' + CHANNEL_NODE_NAME + '/' + SKIP_HOURS_NODE_NAME + '/';


            _tagsMap = new Dictionary<string, XmlDocumentTag>();

            _tagsMap[prefix + "hour"] = new XmlDocumentTag("Hour", "hour", XmlDocumentTag.TAG_STATE.OPTIONNAL);
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
            List<SkipHours> skipHoursList = new List<SkipHours>(); ;

            if (_tagsMap == null || node.ChildNodes == null) {
                return success;
            }

            foreach (XmlNode child in node.ChildNodes) {
                _tagsMap.TryGetValue(this.getXPathForNode(child), out tag);
                if (tag == null) {
                    Logger.Error("Unknown tag " + this.getXPathForNode(child) + " found");
                    return false;
                }
                SkipHours hour = new SkipHours();
                success = this.setSkipHourPropertyValue(hour, tag.PropertyName, child.InnerText);
                if (!success) {
                    break;
                }
                skipHoursList.Add(hour);
            }
            if (success) {
                _data = skipHoursList;
            }
            return success;
        }

        private bool setSkipHourPropertyValue(SkipHours skipHour, String propertyName, object value) {
            if (propertyName == null || propertyName.Length == 0) {
                return true;
            }
            PropertyInfo info = skipHour.GetType().GetProperty(propertyName);
            if (info == null) {
                Logger.Error("Unable to get property info " + propertyName);
                return false;
            }
            try {
                info.SetValue(skipHour, Convert.ChangeType(value, info.PropertyType), null);
            } catch (Exception ex) {
                Logger.Error("Unable to set value for property " + propertyName + " because: " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
