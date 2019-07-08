using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.IO;
using ChupaChupa_WcfLibrary.ServiceContractsImpl;
using ChupaChupa_Model.Entities;
using ChupaChupa_Server.Database.DAO;
using System.Xml;
using ChupaChupa_Server.RSS.Parser;
using ChupaChupa_Server.Controller;
using ChupaChupa_Server.RSS.Scheduler;
using log4net;

namespace ChupaChupa_Server
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        private static RssScheduler schedulerObj;

        static void Main(string[] args)
        {

            String toto = "toto";
            Console.WriteLine("" + toto.Split('/').Length);

            log4net.Config.XmlConfigurator.Configure();

            //Logger.Debug("Coucou!");
            //Console.ReadKey();

            //parsing();
            //testNetworkWcf();

            //scheduler();
            //database();

            Console.ReadLine();
            //schedulerObj.stop();

        }

        static void parsing() { 
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(@"TestsRssChannel\ChannelTest.xml")) 
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            string allines = sb.ToString();
            
            using (XmlReader reader = XmlReader.Create(new StringReader(allines)))
            {

                XmlDocument document = new XmlDocument();
                try
                {
                    document.Load(reader);
                    RssChannelParser parser = new RssChannelParser();
                    if (parser.parseData(document.DocumentElement.SelectSingleNode("channel"))) {
                        Logger.Debug(parser.getExtractedData());
                        controller((RssChannel) parser.getExtractedData());
                    }
                    
               }
                catch (Exception ex)
                {
                    Logger.Debug("Unable to load XML content because: " + ex.Message);
                }
            }
        }


        static void controller(RssChannel channel) {
            RssChannelController controller = new RssChannelController();
            controller.controlData(channel);
        }

        static void scheduler() {
            schedulerObj = new RssScheduler(TimeSpan.FromSeconds(5).TotalMilliseconds);

            schedulerObj.run();
//            Logger.Debug(TimeSpan.FromMinutes(5).TotalMilliseconds);
        }

        static void testNetworkWcf() {
            Uri baseAddress = new Uri("http://localhost:8080/hello");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(AuthenticationService), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

//                 Logger.Debug("The service is ready at {0}" +  baseAddress);
//                 Logger.Debug("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }

        }

        static void database()
        {

            Logger.Debug("------------------------------------------ Test DAOs ------------------------------------------");

            #region UserDAO

            //Logger.Debug("--------------------  User DAO");
            UserDAO userDao = new UserDAO();

            //Logger.Debug("-- All Users --");
            //IList<User> users = userDao.findAll();
            //foreach (User e in users)
            //    Logger.Debug(e);

            //Logger.Debug("-- User with id=47 --");
            //Logger.Debug(userDao.findById(47));
            #endregion


            #region CategorieDAO

            Logger.Debug("--------------------  Categorie DAO");

            CategoryDAO categoryDao = new CategoryDAO();


            var category = new Category() {Name = "Coucoulescopains"};
            
            var user = new User() { LoginMail = "monlogindesuperuser", Password = "passde MALADE" };
            user.addCategory(category);
            userDao.saveOrUpdate(user);

            Logger.Debug("-- Save Category --");
            categoryDao.saveOrUpdate(category);
            
            //Logger.Debug("-- All Categories --");
            //IList<Category> categories = categoryDao.findAll();
            //foreach (Category c in categories)
            //    Logger.Debug(c);

            //Logger.Debug("-- Category with id=3 --");
            //Logger.Debug(categoryDao.findById(3));

            #endregion


            #region RssItemDAO
            //RssItemDAO rssItemDAO = new RssItemDAO();
            
            //Logger.Debug("-------------------- Creation d'un rss item");
            //DateTime dt2 = new DateTime(1999, 12, 06);
            //Enclosure myEnclosure = new Enclosure() { Length = 10, Url = "www.myenclosure.com", Type = "Typedemonenclosure" };
            //Source mySource = new Source() { Url = "www.mysource.com" };

            //RssItem rssItem = new RssItem()
            //{
            //    Title = "My ITEM",
            //    Link = "www.myItem.com",
            //    PubDate = dt2,
            //    Description = "super item ce myItem !",
            //    Enclosure = myEnclosure,
            //    Source = mySource
            //};
            //rssItem.addRssCategory(new RssCategory() { Name = "category", Domain = "ouech tonton" });
            
            ////RssChannelDAO rssChannelDAO1 = new RssChannelDAO();
            ////rssItem.RssChannel = rssChannelDAO1.findById(41);

            ////rssItemDAO.saveOrUpdate(rssItem);


            //Logger.Debug("-------------------- Update du rss item (id = 15)");
            //RssItem ri = rssItemDAO.findById(15);
            //ri.Title = "NouveauTITRE";
            //ri.addRssCategory(new RssCategory() { Name = "category", Domain = "ouech tonton" });
            //rssItemDAO.saveOrUpdate(ri);


            #endregion



            Console.ReadLine();

            #region RssChannelDAO

            Logger.Debug("----------------------------------------  RssChannel DAO");
            RssChannelDAO rssChannelDAO = new RssChannelDAO();

            //DateTime dt = new DateTime(1999, 12, 06);
            //Cloud myCloud = new Cloud() { Domain = "dcsc", Port = 4747, Path = "dc", Protocol = "dc", RegisterProcedure = "dc" };
            //TextInput myTextInput = new TextInput() { Description = "un text input super", Name = "mytextipnut2", Link = "www.textINput.com", Title = "MY TEXT INPUT" };
            //Image myImage = new Image() { Url = "www.monimage.fr", Title = "Monimage", Link = "www.monimage.com/monimage" };

            //RssChannel rssChannel = new RssChannel()
            //{
            //    RssLink = "www.monchanneldelamortquitue.com",
            //    Title = "Mon channel",
            //    Link = "www.myLink.com",
            //    LastBuildDate = dt,
            //    PubDate = dt,
            //    Description = "super link ce mylink !",
            //    Cloud = myCloud,
            //    TextInput = myTextInput,
            //    Image = myImage
            //};

            //rssChannel.addRssCategory(new RssCategory() { Domain="categoryDomain", Name="myCategory"});
            //rssChannel.addSkipDays(new SkipDays(){ Day = "Tuesday" });
            //rssChannel.addSkipHours(new SkipHours() { Hour = 12 });
            
            ////rssChannel.addRssItem(rssItem);
            ////rssItem.RssChannel = rssChannel;
            
            //Logger.Debug("-------------------- Sauvegarde d'un rsschannel");
            //rssChannelDAO.saveOrUpdate(rssChannel);

            Logger.Debug("-------------------- Liste du rss channel (id = 41)");
            Logger.Debug(rssChannelDAO.findById(41));

            Logger.Debug("-------------------- Liste de tous les rss channel");
            foreach (RssChannel ch in rssChannelDAO.findAll())
                Logger.Debug(ch);

            #endregion





            // http://tahe.developpez.com/dotnet/nhibernate/?page=page_1
            // http://www.objis.com/formation-java/tutoriel-hibernate-3-creation-couche-dao-acces-donnees-hibernate-3.html
        }
    }
}
