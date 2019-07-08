using System;
using System.Text;

namespace ChupaChupa.Entities
{
    public class Image : IEntity
    {
        #region Properties

        public virtual Int64 IdEntity { get; set; }
        public virtual String Url { get; set; }
        public virtual String Title { get; set; }
        public virtual String Link { get; set; }
        public virtual String Description { get; set; }
        public virtual Int32 Width { get; set; }
        public virtual Int32 Height { get; set; }

        #endregion

        #region Constructor

        public Image() { }

        #endregion

        #region Methods

        public virtual bool update(Image obj)
        {
            if (obj == null) {
                return false;
            }

            this.Url = obj.Url;
            this.Title = obj.Title;
            this.Link = obj.Link;
            this.Description = obj.Description;
            this.Width = obj.Width;
            this.Height = obj.Height;
            return true;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("IMAGE.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("IMAGE.Url: ").Append(Url).Append('\n');
            sb.Append("IMAGE.Title: ").Append(Title).Append('\n');
            sb.Append("IMAGE.Link: ").Append(Link).Append('\n');
            sb.Append("IMAGE.Description: ").Append(Description).Append('\n');
            sb.Append("IMAGE.Width: ").Append(Width).Append('\n');
            sb.Append("IMAGE.Height: ").Append(Height).Append('\n');

            return sb.ToString();
        }

    }
}
