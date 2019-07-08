using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chupachupa_WebApp.PrivateService;

namespace Chupachupa_WebApp.Models
{
    public class monObjet
    {
        public static RssItem rssItem1 = new RssItem() { Title = "Les huitres du groenland", Description = "ouech salut sdcsd jhc ", IdEntity = 1 };
        public static RssItem rssItem2 = new RssItem() { Title = "Les bons plan cuisto", Description = "ouechdc sk doicu dcsdck sjdh c ", IdEntity = 2 };
        public static RssItem rssItem3 = new RssItem() { Title = "La cuisine facile", Description = "ben ouai quoi c'est pas dur de cuisiner ", IdEntity = 3 };
        public static RssItem rssItem4 = new RssItem() { Title = "coucou les moules", Description = "ceci est ma description et tout ca ", IdEntity = 4 };
        public static RssItem rssItem5 = new RssItem() { Title = "ouech ma gueule t'as faim ?", Description = "ben parceque si cest pas le cas faut le dire sinon ca le fait pas", IdEntity = 5 };
        public static RssItem rssItem6 = new RssItem() { Title = "ouech ma gueule t'as faim ?", Description = "ben parceque si cest pas le cas faut le dire sinon ca le fait pas", IdEntity = 6 };
        public static RssItem rssItem7 = new RssItem() { Title = "ouech ma gueule t'as faim ?", Description = "ben parceque si cest pas le cas faut le dire sinon ca le fait pas", IdEntity = 7 };

        //public static RssChannel channel1 = new RssChannel() { Title = "Youporn", RssItems = new List<RssItem>() { rssItem2, rssItem4, rssItem6 }, IdEntity = 1 };
        //public static RssChannel channel2 = new RssChannel() { Title = "Intranet", RssItems = new List<RssItem>() { rssItem1, rssItem3, rssItem5, rssItem7 }, IdEntity = 2 };
        //public static RssChannel channel3 = new RssChannel() { Title = "Youtube", RssItems = new List<RssItem>() { rssItem1, rssItem2, rssItem3, rssItem4, rssItem5, rssItem6, rssItem7 }, IdEntity = 3 };
        //public static RssChannel channel4 = new RssChannel() { Title = "01.net", RssItems = new List<RssItem>() { rssItem1 }, IdEntity = 4 };

        //public static Category category1 = new Category() { Name = "Web", RssChannels = new List<RssChannel>() { channel1, channel2, channel3, channel4 }, IdEntity = 1 };
        //public static Category category2 = new Category() { Name = "Cuisine", RssChannels = new List<RssChannel>() { channel4, channel3, channel2, channel1 }, IdEntity = 2 };
        //public static Category category3 = new Category() { Name = "Voitures", RssChannels = new List<RssChannel>() { channel1, channel3 }, IdEntity = 3 };
        //public static Category category4 = new Category() { Name = "Voitures", RssChannels = new List<RssChannel>() { channel2, channel4 }, IdEntity = 4 };
        //public static Category category5 = new Category() { Name = "Voitures", RssChannels = new List<RssChannel>() { channel4 }, IdEntity = 5 };

        //public static List<Category> catList = new List<Category>() { category1, category2, category3, category4, category5 };
        //public static List<RssChannel> chanList = new List<RssChannel>() { channel1, channel2, channel3, channel4 };
        //public static List<RssItem> cartList = new List<RssItem>() { rssItem1, rssItem2, rssItem3, rssItem4, rssItem5, rssItem6, rssItem7 };

        public static Category getCategoryById(int? id)
        {
            //if (id == 1)
            //{
            //    return (category1);
            //}
            //else if (id == 2)
            //{
            //    return (category2);
            //}
            //else if (id == 3)
            //{
            //    return (category3);
            //}
            //else if (id == 4)
            //{
            //    return (category4);
            //}
            //else
            //{
            //    return (category5);
            //}
            return (new Category());
        }

        public static RssChannel getChannelById(int? id)
        {
            //if (id == 1)
            //{
            //    return (channel1);
            //}
            //else if (id == 2)
            //{
            //    return (channel2);
            //}
            //else if (id == 3)
            //{
            //    return (channel3);
            //}
            //else
            //{
            //    return (channel4);
            //}
            return (new RssChannel());
        }

        public static RssItem getItemById(int? id)
        {
            if (id == 1)
            {
                return (rssItem1);
            }
            else if (id == 2)
            {
                return (rssItem2);
            }
            else if (id == 3)
            {
                return (rssItem3);
            }
            if (id == 1)
            {
                return (rssItem4);
            }
            else if (id == 2)
            {
                return (rssItem5);
            }
            else if (id == 3)
            {
                return (rssItem6);
            }
            else
            {
                return (rssItem7);
            }
        }
    }
}