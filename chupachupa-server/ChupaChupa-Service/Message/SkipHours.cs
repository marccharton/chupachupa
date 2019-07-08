using System;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class SkipHours
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual Int16 Hour { get; set; }
    }
}
