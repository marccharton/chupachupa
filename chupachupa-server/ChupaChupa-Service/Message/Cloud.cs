using System;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class Cloud
    {        
        [DataMember]
        public virtual Int64 IdEntity { get; set; }

        [DataMember]
        public virtual String Domain { get; set; }
        
        [DataMember]
        public virtual Int32 Port { get; set; }
        
        [DataMember]
        public virtual String Path { get; set; }
        
        [DataMember]
        public virtual String RegisterProcedure { get; set; }
        
        [DataMember]
        public virtual String Protocol { get; set; }
    }
}
