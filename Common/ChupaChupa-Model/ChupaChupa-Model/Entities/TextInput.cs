using System;
using System.Text;

namespace ChupaChupa_Model.Entities
{
    public class TextInput : IEntity
    {
        #region Properties

        public virtual Int64        IdEntity { get; set; }
        public virtual String       Title { get; set; }
        public virtual String       Description { get; set; }
        public virtual String       Name { get; set; }
        public virtual String       Link { get; set; }
        public virtual RssChannel   RssChannel { get; set; }

        #endregion


        #region Constructor

        public TextInput() { }

        #endregion


        #region Methods

        public virtual bool update(TextInput obj)
        {
            if (obj == null) {
                return false;
            }

            this.Title = obj.Title;
            this.Description = obj.Description;
            this.Name = obj.Name;
            this.Link = obj.Link;
            this.RssChannel = obj.RssChannel;
            return true;
        }

        #endregion


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("TEXTINPUT.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("TEXTINPUT.Title: ").Append(Title).Append('\n');
            sb.Append("TEXTINPUT.Description: ").Append(Description).Append('\n');
            sb.Append("TEXTINPUT.Name: ").Append(Name).Append('\n');
            sb.Append("TEXTINPUT.Link: ").Append(Link).Append('\n');

            return sb.ToString();
        }

    }
}
