using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public class AbstractXmlNodeParser : IXmlNodeParser
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AbstractXmlNodeParser));

        protected Dictionary<String, XmlDocumentTag> _tagsMap;
        protected Dictionary<String, XmlAttributeTag> _attributesMap;

        private Dictionary<String, IList> _elementsList;

        protected object _data;

        public AbstractXmlNodeParser() {
            _tagsMap = null;
            _attributesMap = null;
            _data = null;
            _elementsList = null;
        }

        public virtual bool parseData(XmlNode node) {
            bool success = true;
            
            if (node == null) {
                Logger.Error(this.GetType() + ":  Cannot parse element because root node is null");
                return false;
            }

            success = this.parseTags(node) && parseAttributes(node);
            success = this.setRemainingValuesInElementList();
            return success;
        }

        public virtual object getExtractedData() {
            return _data;
        }

        private bool parseTags(XmlNode node) {
            bool success = true;
            XmlDocumentTag tag;

            if (_tagsMap == null || node.ChildNodes == null) {
                return success;
            }
            
            foreach (XmlNode child in node.ChildNodes) {
                _tagsMap.TryGetValue(this.getXPathForNode(child), out tag);
                if (tag == null) {
                    Logger.Warn(this.GetType() + ": Unknown tag " + this.getXPathForNode(child) + " found");
                    continue;
                } else {
                    if (!this.handleValue(child, tag)) {
                        Logger.Error(this.GetType() + ": Unable to parse or set value for " + tag.PropertyName + ". Skipping element");
                    }
                } 
            }
            return success;
        }

        private bool handleValue(XmlNode node, XmlDocumentTag tag) {
            bool success = true;
            IList values = null;
            Type type = null; ;
            object extractedData;

            type = this.getPropertyType(tag.PropertyName);

            if (type != null && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>)) {
                if (_elementsList == null) {
                    _elementsList = new Dictionary<String, IList>();
                }
                _elementsList.TryGetValue(tag.PropertyName, out values);
                if (values == null) {
                    values = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(type.GetGenericArguments()[0]));
                    _elementsList[tag.PropertyName] = values;
                }
            }
            
            if (tag.Parser == null) {
                success = this.setDataPropertyValue(tag.PropertyName, node.InnerText);
            } else {
                success = tag.Parser.parseData(node);
                if (!success) {
                    return success;
                }
                extractedData = tag.Parser.getExtractedData();
                if (values != null) {
                    if (extractedData != null && extractedData.GetType().IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        _elementsList[tag.PropertyName] = (IList) extractedData;
                    } else {
                        values.Add(extractedData);
                    }
                } else {
                    success = this.setDataPropertyValue(tag.PropertyName, extractedData);
                }
            }
            return success;
        }

        private bool parseAttributes(XmlNode node) {
            bool success = true;
            XmlAttributeTag attributeTag;

            if (_attributesMap == null) {
                return success;
            }
            XmlAttributeCollection attributes = node.Attributes;
            if (attributes == null) {
                return success;
            }

            foreach (XmlAttribute attribute in attributes) {
                _attributesMap.TryGetValue(this.getXPathForNode(node) + ':' + attribute.Name, out attributeTag);
                if (attributeTag == null) {
                    Logger.Warn(this.GetType() + ": Unknown attribute found: " + this.getXPathForNode(node) + ':' + attribute.Name);
                    continue;
                }
                if (!this.setDataPropertyValue(attributeTag.PropertyName, attribute.InnerText)) {
                    Logger.Error(this.GetType() + ": Unable to set value for " + attributeTag.PropertyName + ". Skipping element.");                
                }
            }
            return success;
        }

        protected bool setDataPropertyValue(String propertyName, object value) {
            if (propertyName == null || propertyName.Length == 0) {
                return true;
            }

            PropertyInfo info = _data.GetType().GetProperty(propertyName);
            if (info == null) {
                Logger.Error(this.GetType() + ": Unable to get property info " + propertyName);
                return false;
            }
            try {
                if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                    info.SetValue(_data, Convert.ChangeType(value, info.PropertyType.GetGenericArguments()[0]), null);
                } else if (value is IConvertible) {
                    info.SetValue(_data, Convert.ChangeType(value, info.PropertyType), null);
                } else {
                    info.SetValue(_data, value, null);
                }
            } catch (Exception ex) {
                Logger.Error(this.GetType() + ": Unable to set value for property " + propertyName + " because: " + ex.Message);
                return false;
            }
            return true;
        }

        private bool setRemainingValuesInElementList() {
            bool success = true;

            if (_elementsList != null) {
                foreach (KeyValuePair<String, IList> entry in _elementsList) {
                    success = this.setDataPropertyValue(entry.Key, entry.Value);
                    if (!success) {
                        break;
                    }
                }
            }
            return success;
        }

        private Type getPropertyType(String propertyName) {
            PropertyInfo info = _data.GetType().GetProperty(propertyName);
            if (info == null) {
                Logger.Error(this.GetType() + ": Unable to get property info " + propertyName);
                return null;
            }
            return info.PropertyType;
        }

        protected String getXPathForNode(XmlNode node) {
            if (node == null || node.NodeType == XmlNodeType.Document) {
                return "";
            }
            return getXPathForNode(node.ParentNode) + "/" + node.Name;
        }
    }
}
