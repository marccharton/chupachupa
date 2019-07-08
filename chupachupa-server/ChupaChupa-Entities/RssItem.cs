using System;
using System.Collections.Generic;
using System.Text;

namespace ChupaChupa.Entities
{
    public class RssItem : IEntity
    {
        #region Properties

        public virtual Int64 IdEntity { get; set; }
        public virtual String Title { get; set; }
        public virtual String Link { get; set; }
        public virtual String Description { get; set; }
        public virtual String Author { get; set; }
        public virtual String Comments { get; set; }
        public virtual String Guid { get; set; }
        public virtual DateTime? PubDate { get; set; }

        public virtual Enclosure Enclosure { get; set; }
        public virtual Source Source { get; set; }

        public virtual IList<RssCategory> RssCategory { get; set; }
        
        public virtual RssChannel RssChannel { get; set; }

        #endregion

        #region Constructor

        public RssItem() { }

        #endregion

        #region Methods

        public virtual bool addRssCategory(RssCategory rssCategory)
        {
            if (RssCategory == null)
                RssCategory = new List<RssCategory>();
            RssCategory.Add(rssCategory);
            return true;
        }

        public virtual bool setRssCategoryList(IList<RssCategory> RssCategory)
        {
            this.RssCategory = RssCategory;
            return true;
        }

        public virtual bool update(RssItem obj)
        {
            this.Title = obj.Title;
            this.Link = obj.Link;
            this.Description = obj.Description;
            this.Author = obj.Author;
            this.Comments = obj.Comments;
            this.Guid = obj.Guid;
            this.PubDate = obj.PubDate;
            this.Enclosure = obj.Enclosure;
            this.Source = obj.Source;
            this.RssCategory = obj.RssCategory;
            this.RssChannel = obj.RssChannel;
            return true;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("RSSITEM.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("RSSITEM.Title: ").Append(Title).Append('\n');
            sb.Append("RSSITEM.Link: ").Append(Link).Append('\n');
            sb.Append("RSSITEM.Description: ").Append(Description).Append('\n');
            sb.Append("RSSITEM.Author: ").Append(Author).Append('\n');
            sb.Append("RSSITEM.Comments: ").Append(Comments).Append('\n');
            sb.Append("RSSITEM.Enclosure: ").Append(Enclosure).Append('\n');
            sb.Append("RSSITEM.Guid: ").Append(Guid).Append('\n');
            sb.Append("RSSITEM.PubDate: ").Append(PubDate).Append('\n');
            sb.Append("RSSITEM.Source: ").Append(Source).Append('\n');

            if (RssCategory != null) { 
                foreach (RssCategory category in RssCategory) {
                    sb.Append(category);
                }
            }

            return sb.ToString();

        }

    }
}
