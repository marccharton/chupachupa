using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class RssItem
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String Title { get; set; }
        
        [DataMember]
        public virtual String Link { get; set; }
        
        [DataMember]
        public virtual String Description { get; set; }
        
        [DataMember]
        public virtual String Author { get; set; }
        
        [DataMember]
        public virtual String Comments { get; set; }
        
        [DataMember]
        public virtual String Guid { get; set; }

        [DataMember]
        public virtual DateTime? PubDate { get; set; }

        [DataMember]
        public virtual Enclosure Enclosure { get; set; }

        [DataMember]
        public virtual Source Source { get; set; }

        [DataMember]
        public virtual IList<RssCategory> RssCategory { get; set; }

        [DataMember]
        public bool IsRead { get; set; }
    }
}
