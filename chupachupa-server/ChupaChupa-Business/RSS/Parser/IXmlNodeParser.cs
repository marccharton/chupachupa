using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChupaChupa.Business.RSS.Parser
{
    public interface IXmlNodeParser
    {
        bool parseData(XmlNode node);

        object getExtractedData();
    }
}
