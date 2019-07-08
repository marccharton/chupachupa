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
    public class HomeController : Controller
    {
        //
        // GET: /Home

        public ActionResult Index()
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout");
            }
            try
            {
                IList<Category> cat = serveur.getCategories();
                if (serveur != null && cat != null)
                {
                     Session["CategoryList"] = cat.ToList();
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            ViewBag.category = Session["CategoryList"] as List<Category>;
            return View("Homepage");
        }

        public ActionResult Edition(int? id)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout");
            }
            try
            {
                Session["Category"] = serveur.getCategoryById((Int64)id);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            var category = Session["Category"] as Category;
            ViewBag.catName = category.Name;
            ViewBag.category = Session["Category"] as Category;
            return View("EditCategorie");
        }

        [HttpPost]
        public ActionResult Edition(int? id, string name)
        {
            var serveur = Session["serveur"] as ServiceContractClient;            
            if (serveur == null)
            {
                return RedirectToAction("Logout");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            try
            {
                Session["Category"] = serveur.getCategoryById((Int64)id);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            if (string.IsNullOrEmpty(name))
            {
                var category = Session["Category"] as Category;
                ViewBag.catName = category.Name;
                return View("EditCategorie");
            }
            try
            {
                serveur.renameCategory((Int64)id, name);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.category = Session["Category"];
            return RedirectToAction("Index");
        }

        public ActionResult Suppression(int? id)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout");
            }
            try
            {
                Session["Category"] = serveur.getCategoryById((Int64)id);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            ViewBag.category = Session["Category"] as Category;
            return View("SuppCategorie");
        }

        [HttpPost]
        [ActionName("Suppression")]
        public ActionResult SuppressionCategorie(int? id)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout");
            }
            try
            {
                serveur.dropCategoryWithId((Int64)id);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return RedirectToAction("Index");
        }

        public ActionResult AjoutCategorie()
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return View("AjoutCategorie");
        }

        [HttpPost]
        [ActionName("AjoutCategorie")]
        public ActionResult Ajout(string name)
        {
            var serveur = Session["serveur"] as ServiceContractClient;
            if (serveur == null)
            {
                return RedirectToAction("Logout");
            }
            try
            {
                serveur.addCategory(name);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return View("Error");
            }
            ViewBag.userName = serveur.ClientCredentials.UserName.UserName;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }
    }
}
