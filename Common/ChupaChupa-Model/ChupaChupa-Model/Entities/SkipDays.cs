using System;
using System.Text;

namespace ChupaChupa_Model.Entities
{
    public class SkipDays : IEntity
    {
        #region Properties

        public virtual Int64 IdEntity { get; set; }
        public virtual String Day { get; set; }

        #endregion


        #region Constructor

        public SkipDays() { }

        #endregion


        #region Methods

        public virtual bool update(SkipDays obj)
        {
            this.Day = obj.Day;
            return true;
        }

        #endregion


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SKIPDAYS.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("SKIPDAYS.Day: ").Append(Day).Append('\n');

            return sb.ToString();
        }

    }
}
