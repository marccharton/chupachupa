using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class RssChannel
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String RssLink { get; set; }
        
        [DataMember]
        public virtual String Title { get; set; }
        
        [DataMember]
        public virtual String Link { get; set; }
        
        [DataMember]
        public virtual String Description { get; set; }

        [DataMember]
        public virtual String Language { get; set; }
        
        [DataMember]
        public virtual String Copyright { get; set; }
        
        [DataMember]
        public virtual String ManagingEditor { get; set; }
        
        [DataMember]
        public virtual String WebMaster { get; set; }

        [DataMember]
        public virtual DateTime? PubDate { get; set; }
        
        [DataMember]
        public virtual DateTime? LastBuildDate { get; set; }

        [DataMember]
        public virtual String Generator { get; set; }
        
        [DataMember]
        public virtual String Docs { get; set; }
        
        [DataMember]
        public virtual Int32 Ttl { get; set; }
        
        [DataMember]
        public virtual String Rating { get; set; }


        [DataMember]
        public virtual Cloud Cloud { get; set; }
        
        [DataMember]
        public virtual Image Image { get; set; }
        
        [DataMember]
        public virtual TextInput TextInput { get; set; }

        [DataMember]
        public virtual IList<RssCategory> RssCategory { get; set; }
        
        [DataMember]
        public virtual Int64 RssItems { get; set; }
        
        [DataMember]
        public virtual IList<SkipDays> SkipDays { get; set; }
        
        [DataMember]
        public virtual IList<SkipHours> SkipHours { get; set; }
    }
}
