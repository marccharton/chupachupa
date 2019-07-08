using System;
using System.Collections.Generic;
using System.Text;

namespace ChupaChupa_Model.Entities
{
    public class Category : IEntity
    {
        #region Properties

        public virtual Int64                IdEntity { get; set; }
        public virtual String               Name { get; set; }
        public virtual IList<RssChannel>    RssChannels { get; set; }
        public virtual User                 User { get; set; }

        #endregion 

        
        #region Constructor

        public Category() { }

        #endregion


        #region Methods

        public virtual bool addRssChannel(RssChannel RssChannel)
        {
            if (this.RssChannels == null)
                this.RssChannels = new List<RssChannel>();
            this.RssChannels.Add(RssChannel);
            return true;
        }

        public virtual bool setRssChannelList(IList<RssChannel> RssChannels)
        {
            this.RssChannels = RssChannels;
            return true;
        }

        public virtual bool update(Category obj)
        {
            this.Name = obj.Name;
            this.RssChannels = obj.RssChannels;
            this.User = obj.User;
            return true;
        }

        #endregion


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("Name: ").Append(Name).Append('\n');

            if (RssChannels != null) {
                foreach (RssChannel channel in RssChannels) {
                    sb.Append(channel);
                }
            }
            
            return sb.ToString();
        }

    }
}
