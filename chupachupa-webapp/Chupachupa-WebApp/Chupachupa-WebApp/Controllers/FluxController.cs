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
    public class FluxController : Controller
    {
        //
        // GET: /Articles/

        public ActionResult List(int? catId)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                Session["CategoryId"] = serveur.getCategoryById((Int64)catId).IdEntity;
                Session["CategoryName"] = serveur.getCategoryById((Int64)catId).Name;
                List<RssChannel> channel = serveur.getRssChannelsInCategoryWithIdCategory((Int64)Session["CategoryId"]);
                if (serveur != null && channel != null)
                {
                    Session["ChannelList"] = channel;
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.catId = Session["CategoryId"];
            ViewBag.catName = Session["CategoryName"];
            ViewBag.channelList = Session["ChannelList"];
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return View("List");
        }

        public ActionResult Edit(int? catId, int? channelId)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                Session["Channel"] = serveur.getChannelById((Int64)channelId);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.catId = catId;
            ViewBag.category = Session["CategoryList"] as List<Category>;
            ViewBag.channelId = channelId;
            ViewBag.channel = Session["Channel"] as RssChannel;
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return View("EditFlux");
        }

        
        public ActionResult SwitchCategory(int? oldCatId, int? newCatId, int? channelId)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                serveur.moveChannelToCategory((Int64)oldCatId, (Int64)newCatId, (Int64)channelId);                
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Add()
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            ViewBag.category = Session["CategoryList"] as List<Category>;
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return View("AddFlux");
        }

        [HttpPost]
        public ActionResult Add(string name, string url)
        {
            RssChannel unChannel = new RssChannel();
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                unChannel = serveur.addChannelInCategoryWithCategoryName(url, name);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? catId, int? channelId)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                Session["ChannelName"] = serveur.getChannelById((Int64)channelId).Title;
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            ViewBag.catName = Session["CategoryName"];
            ViewBag.channelName = Session["ChannelName"];
            ViewBag.channelId = channelId;
            ViewBag.catId = catId;
            return View("DeleteFlux");
        }

        public ActionResult DeleteFlux(int? catId, int? channelId)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            try
            {
                serveur.dropChannel((Int64)channelId);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            return RedirectToAction("List", new { catId = catId });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }

    }
}
