using System;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class Source
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String Url { get; set; }
    }
}
