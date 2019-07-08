using System;
using System.Runtime.Serialization;
using System.Text;

namespace ChupaChupa.Service.Message
{
    [DataContract]
    public class TextInput
    {
        [DataMember]
        public virtual Int64        IdEntity { get; set; }

        [DataMember]
        public virtual String Title { get; set; }

        [DataMember]
        public virtual String Description { get; set; }

        [DataMember]
        public virtual String Name { get; set; }

        [DataMember]
        public virtual String Link { get; set; }
    }
}
