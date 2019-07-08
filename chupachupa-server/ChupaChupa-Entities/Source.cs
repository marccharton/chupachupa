using System;
using System.Text;

namespace ChupaChupa.Entities
{
    public class Source : IEntity
    {
        #region Properties

        public virtual Int64 IdEntity { get; set; }
        public virtual String Url { get; set; }

        #endregion
        
        #region Constructor

        public Source() { }

        #endregion

        #region Methods

        public virtual bool update(Source obj)
        {
            this.Url = obj.Url;
            return true;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SOURCE.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("SOURCE.Url: ").Append(Url).Append('\n');

            return sb.ToString();
        }

    }
}
