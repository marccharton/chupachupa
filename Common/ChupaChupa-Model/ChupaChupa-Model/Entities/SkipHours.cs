using System;
using System.Text;

namespace ChupaChupa_Model.Entities
{
    public class SkipHours : IEntity
    {
        #region Properties 

        public virtual Int64 IdEntity { get; set; }
        public virtual Int16 Hour { get; set; }

        #endregion


        #region Constructor

        public SkipHours() { }

        #endregion


        #region Methods

        public virtual bool update(SkipHours obj)
        {
            this.Hour = obj.Hour;
            return true;
        }
        
        #endregion


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SKIPHOURS.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("SKIPHOURS.Hour: ").Append(Hour).Append('\n');

            return sb.ToString();
        }


    }
}
