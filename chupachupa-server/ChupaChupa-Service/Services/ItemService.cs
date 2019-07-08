using ChupaChupa.Business.Database.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace ChupaChupa.Service.Services
{
    public class ItemService : AbstractService
    {
        public IList<Message.RssItem> getRssItemsWithChannelId(Int64 userId, Int64 idChannel) {
            this.findUserOrRaiseFaultException(userId, Resources.GetRssItemChannelUnknownUser);
                        
            RssChannelDAO dao = new RssChannelDAO();
            Entities.RssChannel channel = dao.findById(idChannel);
            IList<Message.RssItem> ret = new List<Message.RssItem>();

            if (channel == null) {
                throw new FaultException(Resources.GetRssItemChannelNotExisting);
            }

            Tool.MessageMapper<Message.RssItem, Entities.RssItem> mapper = new Tool.MessageMapper<Message.RssItem, Entities.RssItem>();

            if (channel.RssItems != null) {
                foreach (Entities.RssItem item in channel.RssItems) {
                    Message.RssItem message = mapper.map(item);
                    this.mapIsReadedItem(message);
                    ret.Add(message);
                }
            }
            return ret;
        }

        public IList<Message.RssItem> getRssItemsWithCategoryId(Int64 userId, Int64 idCategory)  
        {
            IList<Message.RssItem> ret = new List<Message.RssItem>();

            this.findUserOrRaiseFaultException(userId, Resources.GetRssItemCategoryUnknownUser);

            if (_user.Categories == null) {
                throw new FaultException(Resources.GetRssItemCategoryNoCategory);
            }

            Entities.Category category = _user.Categories.FirstOrDefault(c => c.IdEntity == idCategory);
            if (category == null) {
                throw new FaultException(Resources.GetRssItemCategoryNotOwned);
            }

            Tool.MessageMapper<Message.RssItem, Entities.RssItem> mapper = new Tool.MessageMapper<Message.RssItem, Entities.RssItem>();

            if (category.RssChannels != null) {
                foreach (Entities.RssChannel channel in category.RssChannels) {
                    if (channel != null && channel.RssItems != null) {
                        foreach (Entities.RssItem item in channel.RssItems) {
                            Message.RssItem message = mapper.map(item);
                            this.mapIsReadedItem(message);
                            ret.Add(message);
                        }
                    }
                }
            }
            return ret;
        }

        public Message.RssItem getRssItemById(Int64 userId, Int64 idRssItem) {
            this.findUserOrRaiseFaultException(userId, Resources.GetRssItemUnknownUser);
                        
            RssItemDAO dao = new RssItemDAO();
            Entities.RssItem entity = dao.findById(idRssItem);

            if (entity == null) {
                throw new FaultException(Resources.GetRssItemNotExisting);
            }

            Tool.MessageMapper<Message.RssItem, Entities.RssItem> mapper = new Tool.MessageMapper<Message.RssItem, Entities.RssItem>();
            Message.RssItem message = mapper.map(entity);
            this.mapIsReadedItem(message);

            return message;
        }

        public void setItemAsRead(Int64 userId, Int64 idRssItem) {
            this.findUserOrRaiseFaultException(userId, Resources.SetItemReadUnknownUser);
            
            if (_user.RssItemsRead != null) {
                if (_user.RssItemsRead.FirstOrDefault(item => item.IdEntity == idRssItem) != null) {
                    return;
                }
            }

            RssItemDAO itemDao = new RssItemDAO();
            Entities.RssItem rssitem = itemDao.findById(idRssItem);

            if (rssitem == null) {
                throw new FaultException(Resources.SetItemReadNotExist);
            }

            if (_user.RssItemsRead == null) {
                _user.RssItemsRead = new List<Entities.RssItem>();
            }

            _user.RssItemsRead.Add(rssitem);
            this.saveUserOrRaiseFaultException(Resources.SetItemReadDatabaseError);
        }

        public void setItemAsUnread(Int64 userId, Int64 idRssItem)
        {
            this.findUserOrRaiseFaultException(userId, Resources.SetItemUnreadUnknownUser);

            if (_user.RssItemsRead == null) {
                throw new FaultException(Resources.SetItemUnreadNoItem);            
            }

            Entities.RssItem item = _user.RssItemsRead.FirstOrDefault(i => i.IdEntity == idRssItem);
            if (item == null) {
                return;
            }

            _user.RssItemsRead.Remove(item);
            this.saveUserOrRaiseFaultException(Resources.SetItemUnreadDatabaseError);
        }


        private void mapIsReadedItem(Message.RssItem item) {
            if (_user == null || item == null || _user.RssItemsRead == null) {
                return;
            }
            
            if (_user.RssItemsRead == null) {
                item.IsRead = false;
            }

            item.IsRead = _user.RssItemsRead.FirstOrDefault(i => i.IdEntity == item.IdEntity) == null ? false : true;
        } 
    }
}