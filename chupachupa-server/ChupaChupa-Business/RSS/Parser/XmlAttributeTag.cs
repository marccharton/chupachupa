using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.RSS.Parser
{
    public class XmlAttributeTag
    {
        public enum ATTRIBUTE_STATE {
            OPTIONNAL,
            REQUIRED
        };

        public enum ATTRIBUTE_CONTENT {
            TEXT,
            TEXT_LIST
        }

        public String PropertyName { get; set; }
        public String AttributeName { get; set; }
        public ATTRIBUTE_CONTENT AttributeType { get; set; }
        public ATTRIBUTE_STATE AttributeState { get; set; }
        

        public XmlAttributeTag(String propertyName, String attributeName) {
            PropertyName = propertyName;
            AttributeName = attributeName;
            AttributeState = ATTRIBUTE_STATE.OPTIONNAL;
            AttributeType = ATTRIBUTE_CONTENT.TEXT;
        }
        public XmlAttributeTag(String propertyName, String attributeName, ATTRIBUTE_STATE attributeState) {
            PropertyName = propertyName;
            AttributeName = attributeName;
            AttributeState = attributeState;
            AttributeType = ATTRIBUTE_CONTENT.TEXT;
        }

        public XmlAttributeTag(String propertyName, String attributeName, ATTRIBUTE_CONTENT attributeType) {
            PropertyName = propertyName;
            AttributeName = attributeName;
            AttributeState = ATTRIBUTE_STATE.OPTIONNAL;
            AttributeType = attributeType;
        }

        public XmlAttributeTag(String propertyName, String attributeName, ATTRIBUTE_STATE attributeState, ATTRIBUTE_CONTENT attributeType) {
            PropertyName = propertyName;
            AttributeName = attributeName;
            AttributeState = attributeState;
            AttributeType = attributeType;
        }
    }
}
