using System;
using System.Text;

namespace ChupaChupa.Entities
{
    public class Cloud : IEntity
    {
        #region Properties
        
        public virtual Int64 IdEntity { get; set; }
        public virtual String Domain { get; set; }
        public virtual Int32 Port { get; set; }
        public virtual String Path { get; set; }
        public virtual String RegisterProcedure { get; set; }
        public virtual String Protocol { get; set; }

        #endregion

        #region Constructor

        public Cloud() { }

        #endregion

        #region Methods

        public virtual bool update(Cloud obj)
        {
            if (obj == null) {
                return false;
            }
            
            this.Domain = obj.Domain;
            this.Port = obj.Port;
            this.Path = obj.Path;
            this.RegisterProcedure = obj.RegisterProcedure;
            this.Protocol = obj.Protocol;
            return true;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLOUD.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("CLOUD.Domain: ").Append(Domain).Append('\n');
            sb.Append("CLOUD.Port: ").Append(Port).Append('\n');
            sb.Append("CLOUD.Path: ").Append(Path).Append('\n');
            sb.Append("CLOUD.RegisterProcedure: ").Append(RegisterProcedure).Append('\n');
            sb.Append("CLOUD.Protocol: ").Append(Protocol).Append('\n');

            return sb.ToString();
        }

    }
}
