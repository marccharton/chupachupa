using ChupaChupa.Service.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Service.ServiceContract
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IServiceContract
    {

        #region Authentification Service

        [OperationContract(IsOneWay = false, IsInitiating = true, IsTerminating = false)]
        void authenticate(string login, string password);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void disconnect();

        #endregion

        #region User service

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        Int64 getUserId();


        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = true)]
        void changePassword(String password);

        #endregion

        #region Category service
        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        IList<Message.Category> getCategories();

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        Message.Category getCategoryById(Int64 idCategory);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        Message.Category addCategory(string categoryName);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void dropCategoryWithId(Int64 idCategory);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void dropCategoryWithCategoryName(string categoryName);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void renameCategory(Int64 idCategory, string newName);


        #endregion

        #region Channel service

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        IList<Message.RssChannel> getRssChannels();

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        IList<Message.RssChannel> getRssChannelsInCategoryWithIdCategory(Int64 idCategory);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        IList<Message.RssChannel> getRssChannelsInCategoryWithCategoryName(string categoryName);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        Message.RssChannel getChannelById(Int64 idChannel);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        Message.RssChannel addChannelInCategoryWithIdCategory(string channelUrl, Int64 idCategory);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        Message.RssChannel addChannelInCategoryWithCategoryName(string channelUrl, string categoryName);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void moveChannelToCategory(Int64 oldCategoryId, Int64 newCategoryId, Int64 idChannel);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void dropChannel(Int64 idChannel);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void dropChannelFromCategory(Int64 idCategory, Int64 idChannel);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void setChannelAsRead(Int64 idChannel);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void setChannelAsUnread(Int64 idChannel);
        
        #endregion

        #region Item service
        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        IList<Message.RssItem> getRssItemsWithChannelId(Int64 idRssChannel);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        IList<Message.RssItem> getRssItemsWithCategoryId(Int64 idCategory);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        Message.RssItem getRssItemById(Int64 idRssItem);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void setItemAsRead(Int64 idRssItem);

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = false)]
        void setItemAsUnread(Int64 idRssItem);
        
        #endregion

    }
}
