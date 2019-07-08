using System;
using System.Text;

namespace ChupaChupa_Model.Entities
{
    public class Enclosure : IEntity
    {
        #region Properties

        public virtual Int64 IdEntity { get; set; }
        public virtual String Url { get; set; }
        public virtual Int64 Length { get; set; }
        public virtual String Type { get; set; }

        #endregion


        #region Constructor

        public Enclosure() { }

        #endregion


        #region Methods

        public virtual bool update(Enclosure obj)
        {
            this.Url = obj.Url;
            this.Length = obj.Length;
            this.Type = obj.Type;
            return true;
        }

        #endregion



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("ENCLOSURE.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("ENCLOSURE.Url: ").Append(Url).Append('\n');
            sb.Append("ENCLOSURE.Length: ").Append(Length).Append('\n');
            sb.Append("ENCLOSURE.Type: ").Append(Type).Append('\n');

            return sb.ToString();
        }


    }
}
