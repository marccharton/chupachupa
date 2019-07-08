using System;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class Image
    {
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String Url { get; set; }
        
        [DataMember]
        public virtual String Title { get; set; }
        
        [DataMember]
        public virtual String Link { get; set; }
        
        [DataMember]
        public virtual String Description { get; set; }
        
        [DataMember]
        public virtual Int32 Width { get; set; }
        
        [DataMember]
        public virtual Int32 Height { get; set; }
    }
}
