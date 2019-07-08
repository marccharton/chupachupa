using ChupaChupa.Business.RSS.Scheduler;
using ChupaChupa.Service.Message;
using ChupaChupa.Service.ServiceContract;
using ChupaChupa.Service.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChupaChupa.Service.ServiceContractImpl
{
    class ServiceContractImpl : IServiceContract
    {
        public static void Configure(ServiceConfiguration config) {
            // log4net.Config.XmlConfigurator.Configure();
            //RssScheduler scheduler = new RssScheduler(TimeSpan.FromHours(1).TotalMilliseconds);
            //scheduler.run();

            config.LoadFromConfiguration();
        }

        private Int64 _currentUserId;

        public ServiceContractImpl() {
            _currentUserId = -1;
        }

        #region Authentification Service

        public void authenticate(string login, string password) {
            _currentUserId = new AuthenticationService().authenticate(login, password);
            if (_currentUserId == -1) {
                throw new FaultException(Resources.AuthTechnicalError);
            }
        }

        public void disconnect() {
            _currentUserId = -1;
        }

        #endregion

        #region User service

        public Int64 getUserId()
        {
            return _currentUserId;
        }

        public void changePassword(String password) {
            new UserService().changePassword(_currentUserId, password);
        }

        #endregion

        #region Category service

        public IList<Message.Category> getCategories() {
            return new CategoryService().getCategories(_currentUserId);
        }

        public Message.Category getCategoryById(Int64 idCategory) {
            return new CategoryService().getCategoryById(_currentUserId, idCategory);
        }

        public Message.Category addCategory(string categoryName) {
            return new CategoryService().addCategory(_currentUserId, categoryName);
        }

        public void dropCategoryWithId(Int64 idCategory) {
            new CategoryService().dropCategory(_currentUserId, idCategory);
        }

        public void dropCategoryWithCategoryName(string name) {
            new CategoryService().dropCategory(_currentUserId, name);
        }

        public void renameCategory(Int64 idCategory, string newName) {
            new CategoryService().renameCategory(_currentUserId, idCategory, newName);
        }

        #endregion

        #region Channel service

        public IList<Message.RssChannel> getRssChannels() {
            return new ChannelService().getRssChannels(_currentUserId);
        }

        public IList<Message.RssChannel> getRssChannelsInCategoryWithIdCategory(Int64 idCategory) {
            return new ChannelService().getRssChannelsInCategory(_currentUserId, idCategory);
        }

        public IList<Message.RssChannel> getRssChannelsInCategoryWithCategoryName(string categoryName) {
            return new ChannelService().getRssChannelsInCategory(_currentUserId, categoryName);
        }

        public Message.RssChannel getChannelById(Int64 idChannel) {
            return new ChannelService().getChannelById(idChannel);
        }

        public Message.RssChannel addChannelInCategoryWithIdCategory(string channelUrl, Int64 idCategory) {
            return new ChannelService().addChannelToCategory(_currentUserId, idCategory, channelUrl);
        }

        public Message.RssChannel addChannelInCategoryWithCategoryName(string channelUrl, string categoryName) {
            return new ChannelService().addChannelToCategory(_currentUserId, categoryName, channelUrl);
        }

        public void moveChannelToCategory(Int64 oldCategory, Int64 newCategory, Int64 idChannel) {
            new ChannelService().moveChannel(_currentUserId, oldCategory, newCategory, idChannel);
        }

        public void dropChannelFromCategory(Int64 idCategory, Int64 idChannel) {
            new ChannelService().dropChannelFromCategory(_currentUserId, idCategory, idChannel);
        }

        public void dropChannel(Int64 idChannel) {
            new ChannelService().dropChannel(_currentUserId, idChannel);
        }

        public void setChannelAsRead(Int64 idChannel) {
            new ChannelService().setChannelAsRead(_currentUserId, idChannel);
        }

        public void setChannelAsUnread(Int64 idChannel) {
            new ChannelService().setChannelAsUnread(_currentUserId, idChannel);
        }
        
        #endregion

        #region Item service

        public IList<Message.RssItem> getRssItemsWithChannelId(Int64 idRssChannel) {
            return new ItemService().getRssItemsWithChannelId(_currentUserId, idRssChannel);
        }

        public IList<Message.RssItem> getRssItemsWithCategoryId(Int64 idCategory) {
            return new ItemService().getRssItemsWithCategoryId(_currentUserId, idCategory);
        }

        public Message.RssItem getRssItemById(Int64 idRssItem) {
            return new ItemService().getRssItemById(_currentUserId, idRssItem);
        }

        public void setItemAsRead(Int64 idRssItem) {
            new ItemService().setItemAsRead(_currentUserId, idRssItem);
        }

        public void setItemAsUnread(Int64 idRssItem) {
            new ItemService().setItemAsUnread(_currentUserId, idRssItem);
        }

        #endregion
    }
}

