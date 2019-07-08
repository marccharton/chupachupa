using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.RSS.Parser
{
    public class XmlDocumentTag
    {
        public enum TAG_STATE {
            OPTIONNAL,
            REQUIRED
        };

        public String TagPath { get; set; }
        public String PropertyName { get; set; }
        public TAG_STATE TagState { get; set; }
        public List<XmlAttributeTag> Attributes { get; private set; }
        // Only used with ROOT nodes
        public IXmlNodeParser Parser { get; set; }
        // Only used with NORMAL_LIST nodes

        public XmlDocumentTag(String propertyName, String tagPath) {
            PropertyName = propertyName;
            TagPath = tagPath;
            TagState = TAG_STATE.OPTIONNAL;
            Attributes = new List<XmlAttributeTag>();
            Parser = null;
        }

        public XmlDocumentTag(String propertyName, String tagPath, TAG_STATE tagState) {
            PropertyName = propertyName;
            TagPath = tagPath;
            TagState = tagState;
            Attributes = new List<XmlAttributeTag>();
            Parser = null;
        }

        public XmlDocumentTag(String propertyName, String tagPath, IXmlNodeParser parser, TAG_STATE tagState) {
            PropertyName = propertyName;
            TagPath = tagPath;
            TagState = tagState;
            Attributes = new List<XmlAttributeTag>();
            Parser = parser;
        }

        public XmlDocumentTag(String propertyName, String tagPath, List<XmlAttributeTag> attributes) {
            PropertyName = propertyName;
            TagPath = tagPath;
            TagState = TAG_STATE.OPTIONNAL;
            Parser = null;

            if (attributes == null) {
                Attributes = new List<XmlAttributeTag>();
            } else {
                Attributes = new List<XmlAttributeTag>(attributes);
            }
        }

        public XmlDocumentTag(String propertyName, String tagPath, List<XmlAttributeTag> attributes, TAG_STATE tagState) {
            PropertyName = propertyName;
            TagPath = tagPath;
            TagState = tagState;
            Parser = null;

            if (attributes == null) {
                Attributes = new List<XmlAttributeTag>();
            } else {
                Attributes = new List<XmlAttributeTag>(attributes);
            }
        }

        public XmlDocumentTag(String propertyName, String tagPath, IXmlNodeParser parser, List<XmlAttributeTag> attributes) {
            PropertyName = propertyName;
            TagPath = tagPath;
            TagState = TAG_STATE.OPTIONNAL;
            Parser = parser;

            if (attributes == null) {
                Attributes = new List<XmlAttributeTag>();
            } else {
                Attributes = new List<XmlAttributeTag>(attributes);
            }
        }

        public XmlDocumentTag(String propertyName, String tagPath, IXmlNodeParser parser, List<XmlAttributeTag> attributes, TAG_STATE tagState) {
            PropertyName = propertyName;
            TagPath = tagPath;
            TagState = tagState;
            Parser = parser;

            if (attributes == null) {
                Attributes = new List<XmlAttributeTag>();
            } else {
                Attributes = new List<XmlAttributeTag>(attributes);
            }
        }

    }
}
