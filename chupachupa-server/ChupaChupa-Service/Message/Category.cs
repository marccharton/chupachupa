using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String Name { get; set; }

        [DataMember]
        public virtual Int64 RssChannels { get; set; }
    }
}
