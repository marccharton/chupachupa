using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Web.Routing;
using Chupachupa_WebApp.PublicService;
using Chupachupa_WebApp.PrivateService;
using Chupachupa_WebApp.Models;


namespace Chupachupa_WebApp.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult List(int? channelId, int? catId)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                RssChannel channel = new RssChannel();
                channel = serveur.getChannelById((Int64)channelId);
                ViewBag.channel = channel;
                List <RssItem> itemList = serveur.getRssItemsWithChannelId((Int64)channelId);
                ViewBag.itemList = itemList;
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.catId = catId;
            ViewBag.channelId = channelId;
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return View("ListArticle");
        }

        public ActionResult Afficher(int? itemId, int? channelId, int? catId)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                serveur.setItemAsRead((Int64)itemId);
                ViewBag.itemTitle = serveur.getRssItemById((Int64)itemId).Title;
                ViewBag.itemDescription = serveur.getRssItemById((Int64)itemId).Description;
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.itemId = itemId;
            ViewBag.catId = catId;
            ViewBag.channelId = channelId;
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return View("AfficherArticle");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }
    }
}
