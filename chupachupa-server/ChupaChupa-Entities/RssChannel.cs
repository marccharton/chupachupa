using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChupaChupa.Entities
{
    public class RssChannel : IEntity
    {
        #region Properties

        public virtual Int64 IdEntity { get; set; }
        public virtual String RssLink { get; set; }
        public virtual String Title { get; set; }
        public virtual String Link { get; set; }
        public virtual String Description { get; set; }

        public virtual String Language { get; set; }
        public virtual String Copyright { get; set; }
        public virtual String ManagingEditor { get; set; }
        public virtual String WebMaster { get; set; }
        public virtual DateTime? PubDate { get; set; }
        public virtual DateTime? LastBuildDate { get; set; }
        public virtual String Generator { get; set; }
        public virtual String Docs { get; set; }
        public virtual Int32 Ttl { get; set; }
        public virtual String Rating { get; set; }

        public virtual Cloud Cloud { get; set; }
        public virtual Image Image { get; set; }
        public virtual TextInput TextInput { get; set; }

        public virtual IList<RssCategory> RssCategory { get; set; }
        public virtual IList<RssItem> RssItems { get; set; }
        public virtual IList<SkipDays> SkipDays { get; set; }
        public virtual IList<SkipHours> SkipHours { get; set; }

        #endregion

        #region Constructor

        public RssChannel() { }

        #endregion

        #region Methods

        public virtual bool addRssItem(RssItem rssItem)
        {
            if (RssItems == null)
                RssItems = new List<RssItem>();
            rssItem.RssChannel = this;
            RssItems.Add(rssItem);
            return true;
        }

        public virtual bool addRssCategory(RssCategory rssCategory)
        {
            if (RssCategory == null)
                RssCategory = new List<RssCategory>();
            RssCategory.Add(rssCategory);
            return true;
        }

        public virtual bool addSkipDays(SkipDays skipDay)
        {
            if (SkipDays == null)
                SkipDays = new List<SkipDays>();
            SkipDays.Add(skipDay);
            return true;
        }

        public virtual bool addSkipHours(SkipHours skipHour)
        {
            if (SkipHours == null)
                SkipHours = new List<SkipHours>();
            SkipHours.Add(skipHour);
            return true;
        }


        public virtual bool setRssCategoryList(IList<RssCategory> RssCategory)
        {
            this.RssCategory = RssCategory;
            return true;
        }

        public virtual bool setRssItemList(IList<RssItem> RssItem)
        {
            this.RssItems = RssItem;
            return true;
        }

        public virtual bool setSkipDaysList(IList<SkipDays> SkipDays)
        {
            this.SkipDays = SkipDays;
            return true;
        }

        public virtual bool setSkipHoursList(IList<SkipHours> SkipHours)
        {
            this.SkipHours = SkipHours;
            return true;
        }


        public virtual void update(RssChannel obj)
        {
            if (obj == null) {
                return;
            }

            this.RssLink = obj.RssLink;
            this.Title = obj.Title;
            this.Link = obj.Link;
            this.Description = obj.Description;
            this.Language = obj.Language;
            this.Copyright = obj.Copyright;
            this.ManagingEditor = obj.ManagingEditor;
            this.WebMaster = obj.WebMaster;
            this.PubDate = obj.PubDate;
            this.LastBuildDate = obj.LastBuildDate;
            this.Generator = obj.Generator;
            this.Docs = obj.Docs;
            this.Ttl = obj.Ttl;
            this.Rating = obj.Rating;

            this.Cloud = obj.Cloud;
            this.Image = obj.Image;
            this.TextInput = obj.TextInput;
            this.SkipDays = obj.SkipDays;
            this.SkipHours = obj.SkipHours;

            if (this.RssItems == null && obj.RssItems != null) {
                this.RssItems = obj.RssItems;
                foreach (RssItem item in this.RssItems) {
                    item.RssChannel = this;
                }
            } else if (this.RssItems != null && obj.RssItems != null) {
                foreach (RssItem item in obj.RssItems) { 
                    if (item == null || item.Link == null) {
                        continue;
                    }
                    try {
                        RssItem tmp = this.RssItems.SingleOrDefault(i => item.Link.CompareTo(i.Link) == 0);
                        if (tmp == null) {
                            this.RssItems.Add(item);
                            item.RssChannel = this;
                        } else {
                            tmp.update(item);
                            tmp.RssChannel = this;
                        }
                    } catch (Exception ex) {
                    }
                }
            }
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("RSSCHANNEL.IdEntity: ").Append(IdEntity).Append('\n');
            sb.Append("RSSCHANNEL.RssLink: ").Append(RssLink).Append('\n');
            sb.Append("RSSCHANNEL.Title: ").Append(Title).Append('\n');
            sb.Append("RSSCHANNEL.Link: ").Append(Link).Append('\n');
            sb.Append("RSSCHANNEL.Description: ").Append(Description).Append('\n');

            sb.Append("RSSCHANNEL.Language: ").Append(Language).Append('\n');
            sb.Append("RSSCHANNEL.Copyright: ").Append(Copyright).Append('\n');
            sb.Append("RSSCHANNEL.ManagingEditor: ").Append(ManagingEditor).Append('\n');
            sb.Append("RSSCHANNEL.WebMaster: ").Append(WebMaster).Append('\n');
            sb.Append("RSSCHANNEL.PubDate: ").Append(PubDate).Append('\n');
            sb.Append("RSSCHANNEL.LastBuildDate: ").Append(LastBuildDate).Append('\n');
            sb.Append("RSSCHANNEL.Generator: ").Append(Generator).Append('\n');
            sb.Append("RSSCHANNEL.Docs: ").Append(Docs).Append('\n');
            sb.Append("RSSCHANNEL.Ttl: ").Append(Ttl).Append('\n');
            sb.Append("RSSCHANNEL.Rating: ").Append(Rating).Append('\n');
            sb.Append("*******************************************************************\n");
            sb.Append("RSSCHANNEL.Image: ").Append(Image).Append('\n');
            sb.Append("*******************************************************************\n");
            sb.Append("RSSCHANNEL.TextInput: ").Append(TextInput).Append('\n');
            sb.Append("*******************************************************************\n");
            sb.Append("RSSCHANNEL.Cloud: ").Append(Cloud).Append('\n');
            sb.Append("*******************************************************************\n");
            
            sb.Append("##################################################################\n");
            sb.Append("RSSCHANNEL.RssCategory: \n");
            if (RssCategory != null)
            {
                foreach (RssCategory category in RssCategory) {
                    sb.Append(category).Append('\n');
                }
            }

            sb.Append("##################################################################\n");
            sb.Append("RSSCHANNEL.SkipDays: \n");
            if (SkipDays != null)
            {
                foreach (SkipDays day in SkipDays) {
                    sb.Append(day).Append('\n');
                }
            }

            sb.Append("##################################################################\n");
            sb.Append("RSSCHANNEL.SkipHours: \n");
            if (SkipHours != null)
            {
                foreach (SkipHours hour in SkipHours)
                {
                    sb.Append(hour).Append('\n');
                }
            }
            sb.Append("##################################################################\n");
            sb.Append("RSSCHANNEL.RssItems: \n");
            if (RssItems != null) {
                foreach (RssItem item in RssItems) {
                    sb.Append(item).Append('\n');
                }
            }
            sb.Append("##################################################################\n");

            return sb.ToString();
        }


    }
}
