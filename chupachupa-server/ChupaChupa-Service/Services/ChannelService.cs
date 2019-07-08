using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Business.RSS.Constructor;
using ChupaChupa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.Services
{
    class ChannelService : AbstractService
    {
        public IList<Message.RssChannel> getRssChannels(Int64 userId) {
            IList<Message.RssChannel> channels = new List<Message.RssChannel>();

            this.findUserOrRaiseFaultException(userId, Resources.GetRssChannelUserUnknown);

            if (_user.Categories == null) {
                return channels;
            }

            Tool.MessageMapper<Message.RssChannel, Entities.RssChannel> mapper = new Tool.MessageMapper<Message.RssChannel, Entities.RssChannel>();

            foreach (Category category in _user.Categories) {
                if (category != null && category.RssChannels != null && category.RssChannels.Count > 0) {
                    foreach (RssChannel channel in category.RssChannels) { 
                        if (channel != null) {
                            channels.Add(mapper.map(channel));
                        }
                    }
                }
            }
            return channels;
        }

        public IList<Message.RssChannel> getRssChannelsInCategory(Int64 userId, Int64 categoryId) {
            IList<Message.RssChannel> channels = new List<Message.RssChannel>();

            this.findUserOrRaiseFaultException(userId, Resources.GetRssChannelUserUnknown);

            if (_user.Categories == null) {
                throw new FaultException(Resources.GetRssChannelCategoryNotOwned);
            }

            Category category = _user.Categories.FirstOrDefault(c => c.IdEntity == categoryId);

            if (category == null) {
                throw new FaultException(Resources.GetRssChannelCategoryNotOwned);
            }

            Tool.MessageMapper<Message.RssChannel, Entities.RssChannel> mapper = new Tool.MessageMapper<Message.RssChannel, Entities.RssChannel>();

            if (category.RssChannels != null) {
                foreach (RssChannel channel in category.RssChannels) {
                    channels.Add(mapper.map(channel));
                }
            }
            return channels;
        }

        public IList<Message.RssChannel> getRssChannelsInCategory(Int64 userId, string categoryName) {
            IList<Message.RssChannel> channels = new List<Message.RssChannel>();

            Tool.ToolBox.controlStringNotEmptyWithFaultException(categoryName, Resources.AddRssChannelEmptyCategory);
                        
            this.findUserOrRaiseFaultException(userId, Resources.GetRssChannelUserUnknown);

            if (_user.Categories == null) {
                throw new FaultException(Resources.GetRssChannelCategoryNotOwned);
            }

            Category category = _user.Categories.FirstOrDefault(c => categoryName.CompareTo(c.Name) == 0);

            if (category == null) {
                throw new FaultException(Resources.GetRssChannelCategoryNotOwned);
            }

            Tool.MessageMapper<Message.RssChannel, Entities.RssChannel> mapper = new Tool.MessageMapper<Message.RssChannel, Entities.RssChannel>();

            if (category.RssChannels != null) {
                foreach (RssChannel channel in category.RssChannels) {
                    channels.Add(mapper.map(channel));
                }
            }
            return channels;
        }

        public Message.RssChannel getChannelById(Int64 channelId) {
            RssChannelDAO dao = new RssChannelDAO();
            RssChannel channel;
            
            channel = dao.findById(channelId);

            if (channel == null) {
                throw new FaultException(Resources.GetRssChannelNotExisting);
            }

            Tool.MessageMapper<Message.RssChannel, Entities.RssChannel> mapper = new Tool.MessageMapper<Message.RssChannel, Entities.RssChannel>();

            return mapper.map(channel);
        }

        public Message.RssChannel addChannelToCategory(Int64 userId, string categoryName, string channelUrl)
        {
            IList<RssChannel> channels = new List<RssChannel>();

            Tool.ToolBox.controlStringNotEmptyWithFaultException(categoryName, Resources.AddRssChannelEmptyCategory);
            Tool.ToolBox.controlStringNotEmptyWithFaultException(channelUrl, Resources.AddRssChannelEmptyLink);

            this.findUserOrRaiseFaultException(userId, Resources.AddRssChannelUserUnknown);

            if (_user.Categories == null) {
                throw new FaultException(Resources.AddRssChannelCategoryNotOwned);
            }

            Category category = _user.Categories.FirstOrDefault(c => categoryName.CompareTo(c.Name) == 0);

            if (category == null) {
                throw new FaultException(Resources.AddRssChannelCategoryNotOwned);
            }

            foreach (Category c in _user.Categories) {
                if (c.RssChannels != null) {
                    if (c.RssChannels.FirstOrDefault(rss => channelUrl.CompareTo(rss.RssLink) == 0) != null) {
                        throw new FaultException(Resources.AddRssChannelAlreadyAddedCategory);
                    }
                }
            }

            RssChannelDAO channelDao = new RssChannelDAO();
            RssChannel channel = channelDao.findByRssLink(channelUrl);
            if (channel == null) {
                RssConstructor constructor = new RssConstructor();
                channel = constructor.addRssChannelToDatabase(channelUrl);
            }

            if (channel == null) {
                throw new FaultException(Resources.AddRssChannelInvalidChannel);
            }

            category.addRssChannel(channel);

            this.saveUserOrRaiseFaultException(Resources.AddRssChannelDatabaseError);

            Tool.MessageMapper<Message.RssChannel, Entities.RssChannel> mapper = new Tool.MessageMapper<Message.RssChannel, Entities.RssChannel>();
            return mapper.map(channel);
        }

        public Message.RssChannel addChannelToCategory(Int64 userId, Int64 categoryId, string channelUrl)
        {
            IList<RssChannel> channels = new List<RssChannel>();

            Tool.ToolBox.controlStringNotEmptyWithFaultException(channelUrl, Resources.AddRssChannelEmptyLink);

            this.findUserOrRaiseFaultException(userId, Resources.AddRssChannelUserUnknown);

            if (_user.Categories == null) {
                throw new FaultException(Resources.AddRssChannelCategoryNotOwned);
            }

            Category category = _user.Categories.FirstOrDefault(c => categoryId == c.IdEntity);

            if (category == null) {
                throw new FaultException(Resources.AddRssChannelCategoryNotOwned);
            }

            foreach (Category c in _user.Categories) {
                if (c.RssChannels != null) {
                    if (c.RssChannels.FirstOrDefault(rss => channelUrl.CompareTo(rss.RssLink) == 0) != null) {
                        throw new FaultException(Resources.AddRssChannelAlreadyAddedCategory);
                    }
                }
            }

            RssChannelDAO channelDao = new RssChannelDAO();
            RssChannel channel = channelDao.findByRssLink(channelUrl);
            if (channel == null) {
                RssConstructor constructor = new RssConstructor();
                channel = constructor.addRssChannelToDatabase(channelUrl);
            }

            if (channel == null) {
                throw new FaultException(Resources.AddRssChannelInvalidChannel);
            }

            category.addRssChannel(channel);
            this.saveUserOrRaiseFaultException(Resources.AddRssChannelDatabaseError);

            Tool.MessageMapper<Message.RssChannel, Entities.RssChannel> mapper = new Tool.MessageMapper<Message.RssChannel, Entities.RssChannel>();
            return mapper.map(channel);
        }

        public void moveChannel(Int64 userId, Int64 oldCategoryId, Int64 newCategoryId, Int64 channelId) {
            this.findUserOrRaiseFaultException(userId, Resources.MoveRssChannelUserUnknown);
            
            if (_user.Categories == null) {
                throw new FaultException(Resources.MoveRssChannelNoCategory);
            }

            Category oldCategory = _user.Categories.FirstOrDefault(c => c.IdEntity == oldCategoryId);
            Category newCategory = _user.Categories.FirstOrDefault(c => c.IdEntity == newCategoryId);

            if (oldCategory == null) {
                throw new FaultException(Resources.MoveRssChannelOldCategoryNotExist);
            }
            if (newCategory == null) {
                throw new FaultException(Resources.MoveRssChannelNewCategoryNotExist);
            }

            RssChannel channel = null;

            if (oldCategory.RssChannels != null) {
                channel = oldCategory.RssChannels.FirstOrDefault(chan => chan.IdEntity == channelId);   
            }

            if (channel == null) {
                throw new FaultException(Resources.MoveRssChannelNotOwnedByUser);
            }

            oldCategory.RssChannels.Remove(channel);
            newCategory.RssChannels.Add(channel);

            this.saveUserOrRaiseFaultException(Resources.MoveRssChannelDatabaseError);
        }

        public void dropChannelFromCategory(Int64 userId, Int64 categoryId, Int64 channelId) {
            IList<RssChannel> channels = new List<RssChannel>();

            this.findUserOrRaiseFaultException(userId, Resources.DropRssChannelUserUnknown);

            if (_user.Categories == null) {
                throw new FaultException(Resources.DropRssChannelCategoryNotOwned);
            }

            Category category = _user.Categories.FirstOrDefault(c => c.IdEntity == categoryId);

            if (category == null) {
                throw new FaultException(Resources.DropRssChannelCategoryNotOwned);
            }

            RssChannel channel = null;

            if (category.RssChannels != null) {
                channel = category.RssChannels.FirstOrDefault(chan => chan.IdEntity == channelId);
            }

            if (channel == null) {
                throw new FaultException(Resources.DropRssChannelNotOwned);
            }

            category.RssChannels.Remove(channel);
            this.saveUserOrRaiseFaultException(Resources.DropRssChannelDatabaseError);
        }

        public void dropChannel(Int64 userId, Int64 channelId) {
            IList<RssChannel> channels = new List<RssChannel>();

            this.findUserOrRaiseFaultException(userId, Resources.DropRssChannelUserUnknown);

            if (_user.Categories == null) {
                throw new FaultException(Resources.DropRssChannelCategoryNotOwned);
            }

            RssChannel channel = null;
            Category category = null;

            foreach (Category c in _user.Categories) {
                if (c.RssChannels != null) {
                    channel = c.RssChannels.FirstOrDefault(chan => chan.IdEntity == channelId);
                    if (channel != null) {
                        category = c;
                        break;
                    }
                }
            }

            if (category == null) {
                throw new FaultException(Resources.DropRssChannelCategoryNotOwned);
            }

            if (channel == null) {
                throw new FaultException(Resources.DropRssChannelCategoryNotOwned);            
            }

            category.RssChannels.Remove(channel);
            this.saveUserOrRaiseFaultException(Resources.DropRssChannelDatabaseError);
        }

        public void setChannelAsRead(Int64 userId, Int64 channelId) {
            this.findUserOrRaiseFaultException(userId, Resources.SetChannelReadUnknownUser);
            
            if (_user.Categories == null) {
                throw new FaultException(Resources.SetChannelReadNoCategory);
            }

            RssChannel channel = null;
            foreach (Category c in _user.Categories) {
                if (c.RssChannels != null) {
                    channel = c.RssChannels.FirstOrDefault(chan => chan.IdEntity == channelId);
                }
                if (channel != null) {
                    break;
                }
            }

            if (channel == null) {
                throw new FaultException(Resources.SetChannelReadNotOwned);
            }

            if (channel.RssItems == null) {
                return;
            }

            if (_user.RssItemsRead == null) {
                _user.RssItemsRead = new List<RssItem>();
            }

            foreach (RssItem item in channel.RssItems) {
                if (_user.RssItemsRead.FirstOrDefault(i => i.IdEntity == item.IdEntity) == null) {
                    _user.RssItemsRead.Add(item);
                }
            }

            this.saveUserOrRaiseFaultException(Resources.SetChannelReadDatabaseError);
        }

        public void setChannelAsUnread(Int64 userId, Int64 channelId)
        {
            this.findUserOrRaiseFaultException(userId, Resources.SetChannelUnreadUnknownUser);

            if (_user.Categories == null) {
                throw new FaultException(Resources.SetChannelUnreadNoCategory);
            }

            RssChannel channel = null;
            foreach (Category c in _user.Categories) {
                if (c.RssChannels != null) {
                    channel = c.RssChannels.FirstOrDefault(chan => chan.IdEntity == channelId);
                }
                if (channel != null) {
                    break;
                }
            }

            if (channel == null) {
                throw new FaultException(Resources.SetChannelUnreadNotOwned);
            }

            if (channel.RssItems == null) {
                return;
            }

            if (_user.RssItemsRead == null) {
                _user.RssItemsRead = new List<RssItem>();
            }

            foreach (RssItem item in channel.RssItems) {
                RssItem itemRead = _user.RssItemsRead.FirstOrDefault(i => i.IdEntity == item.IdEntity);
                if (itemRead != null) {
                    _user.RssItemsRead.Remove(itemRead);
                }
            }

            this.saveUserOrRaiseFaultException(Resources.SetChannelUnreadDatabaseError);
        }
    }
}
