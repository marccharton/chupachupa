using System;
using System.Collections.Generic;
using System.Text;

namespace ChupaChupa.Entities
{
    public class User : IEntity
    {
        #region Properties
        public virtual Int64 IdEntity { get; set; }
        public virtual String LoginMail { get; set; }
        public virtual String Password { get; set; }
        public virtual String OAuthToken { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual IList<RssChannel> RssChannel { get; set; }
        public virtual IList<RssItem> RssItemsRead { get; set; }

        #endregion

        #region Constructor

        public User() { }

        #endregion

        #region Methods

        public virtual bool addCategory(Category Category)
        {
            if (this.Categories == null)
                this.Categories = new List<Category>();
            Category.User = this;
            this.Categories.Add (Category);
            return true;
        }

        public virtual bool addRssChannel(RssChannel RssChannel)
        {
            if (this.RssChannel == null)
                this.RssChannel = new List<RssChannel>();
            this.RssChannel.Add(RssChannel);
            return true;
        }

        public virtual bool addRssItem(RssItem RssItem)
        {
            if (this.RssItemsRead == null)
                this.RssItemsRead = new List<RssItem>();
            this.RssItemsRead.Add(RssItem);
            return true;
        }

        public virtual bool setCategoryList(IList<Category> categories)
        {
            this.Categories = categories;
            return true;
        }

        public virtual bool setRssChannelList(IList<RssChannel> rssChannel)
        {
            this.RssChannel = rssChannel;
            return true;
        }

        public virtual bool setRssItemList(IList<RssItem> RssItem)
        {
            this.RssItemsRead = RssItem;
            return true;
        }

        public virtual bool update(User obj)
        {
            this.LoginMail = obj.LoginMail;
            this.Password = obj.Password;
            this.OAuthToken = obj.OAuthToken;
            this.Categories = obj.Categories;
            this.RssChannel = obj.RssChannel;
            this.RssItemsRead = obj.RssItemsRead;
            return true;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("USER.IdEntity: '").Append(IdEntity).Append("'").Append("\n");
            sb.Append("USER.LoginMail: '").Append(LoginMail).Append("'").Append("\n");
            sb.Append("USER.Password: '").Append(Password).Append("'").Append("\n");
            sb.Append("USER.OAuthToken: '").Append(OAuthToken).Append("'").Append("\n");


            sb.Append("##################################################################\n");
            sb.Append("USER.Category: \n");
            if (Categories != null)
            {
                foreach (Category category in Categories)
                {
                    sb.Append(category);
                }
                sb.Append("\n");
            }

            sb.Append("##################################################################\n");
            sb.Append("USER.RssChannel: \n");
            if (RssChannel != null)
            {
                foreach (RssChannel Channel in RssChannel)
                {
                    sb.Append("channel : " + Channel.Title);
                }
                sb.Append("\n");
            }

            sb.Append("##################################################################\n");
            sb.Append("USER.RssItemsRead: \n");
            if (RssItemsRead != null)
            {
                foreach (RssItem rssItem in RssItemsRead)
                {
                    sb.Append("[" + rssItem.IdEntity + "]");
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }

    }
}
