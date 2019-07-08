using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class User
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String LoginMail { get; set; }
        
        [DataMember]
        public virtual String Password { get; set; }
        
        [DataMember]
        public virtual String OAuthToken { get; set; }
        
        [DataMember]
        public virtual IList<Category> Categories { get; set; }
        
        [DataMember]
        public virtual IList<RssChannel> RssChannel { get; set; }
        
        [DataMember]
        public virtual IList<RssItem> RssItemsRead { get; set; }
    }
}
