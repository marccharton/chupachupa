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
using System.Net.Security;

namespace Chupachupa_WebApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index(int? id)
        {
            int? myId = id;
            ViewBag.error = myId;
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(string name, string pass)
        {
            int errorId = 1;
            Session["serveur"] = new ServiceContractClient();
            System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(CertificateCallback);
            var serveur = Session["serveur"] as ServiceContractClient;
            serveur.ClientCredentials.UserName.UserName = name;
            serveur.ClientCredentials.UserName.Password = pass;
            try
            {
                serveur.authenticate(name, pass); 
                FormsAuthentication.SetAuthCookie(name, false);
            }
            catch (Exception e) 
            {
                errorId = 2;
                return RedirectToAction("Index", new { id = errorId });
            }
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index"} ));
        }

        private bool CertificateCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (certificate.Issuer != null && certificate.Issuer.Contains("SasukeCA")) {
                return true;
            }
            return false;
        }

        public ActionResult Create(string error)
        {
            if (string.IsNullOrEmpty(error)) 
            {
                ViewBag.error = "OK";
            }
            else
            {
                ViewBag.error = "Merci de remplir correctement le formulaire / Votre identifiant est déjà utilisé";
            }
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(string name, string pass)
        {
            PublicServiceContractClient pubserveur = new PublicServiceContractClient();
            try
            {
                pubserveur.createAccount(name, pass);
            }
            catch (Exception e)
            {
                string error = e.ToString();
                return RedirectToAction("Create", new { error = error});
            }
            return RedirectToAction("Index");
        }
    }
}
