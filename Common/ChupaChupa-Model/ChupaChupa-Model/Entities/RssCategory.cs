using System;
using System.Text;

namespace ChupaChupa_Model.Entities
{
    public class RssCategory : IEntity
    {
        #region Properties

        public virtual Int64 IdEntity { get; set; }
        public virtual String Name { get; set; }
        public virtual String Domain { get; set; }

        #endregion


        #region Constructor

        public RssCategory() { }

        #endregion


        #region Methods

        public virtual bool update(RssCategory obj)
        {
            this.Name = obj.Name;
            this.Domain = obj.Domain;
            return true;
        }

        #endregion


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("RSSCATEGORY.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("RSSCATEGORY.Name: ").Append(Name).Append('\n');
            sb.Append("RSSCATEGORY.Domain: ").Append(Domain).Append('\n');

            return sb.ToString();
        }

    }
}
