using System;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class Enclosure
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String Url { get; set; }
        
        [DataMember]
        public virtual Int64 Length { get; set; }
        
        [DataMember]
        public virtual String Type { get; set; }
    }
}
