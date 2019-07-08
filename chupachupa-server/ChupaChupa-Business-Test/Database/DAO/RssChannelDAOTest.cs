using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Entities;
using ChupaChupa.Business.Database.Session;
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace ChupaChupa.Business.Test.Database.DAO
{
    [TestFixture]
    public class RssChannelDAOTest : IDAOTest
    {

        #region Unit Testing

        [Test]
        public void Save()
        {
            var rssChannelDao = new RssChannelDAO();

            var dt = new DateTime(1999, 12, 06);
            var cloud = new Cloud() { Domain = "dcsc", Port = 4747, Path = "dc", Protocol = "dc", RegisterProcedure = "dc" };
            var textInput = new TextInput() { Description = "un text input super", Name = "mytextipnut2", Link = "www.textINput.com", Title = "MY TEXT INPUT" };
            var image = new Image() { Url = "www.monimage.fr", Title = "Monimage", Link = "www.monimage.com/monimage" };
            var rssCategory = new RssCategory() {Domain = "categoryDomain", Name = "myCategory"};
            var skipDays = new SkipDays() {Day = "Tuesday"};
            var skipHours = new SkipHours() {Hour = 12};

            #region RssItem
                var dt2 = new DateTime(1999, 12, 06);
                var enclosure = new Enclosure() { Length = 10, Url = "www.myenclosure.com", Type = "Typedemonenclosure" };
                var source = new Source() { Url = "www.mysource.com" };

                var rssItem = new RssItem()
                {
                    Title = "My ITEM",
                    Link = "www.myItem.com",
                    PubDate = dt2,
                    Description = "super item ce myItem !",
                    Enclosure = enclosure,
                    Source = source
                };
            #endregion

            var rssChannel = new RssChannel() {
                RssLink = "www.monchanneldelamortquitue.com",
                Title = "Mon channel",
                Link = "www.myLink.com",
                LastBuildDate = dt,
                PubDate = dt,
                Description = "super link ce mylink !",
                Cloud = cloud,
                TextInput = textInput,
                Image = image
            };
            rssChannel.addRssItem(rssItem);
            rssChannel.addRssCategory(rssCategory);
            rssChannel.addSkipDays(skipDays);
            rssChannel.addSkipHours(skipHours);
            
            rssChannelDao.saveOrUpdate(rssChannel);

            using (ISession sess = HibernateSession.getInstance().getSession())
            {
                var fromDb = sess.Get<RssChannel>(rssChannel.IdEntity);
                // Test that the rssChannel was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(rssChannel, fromDb);
                Assert.AreEqual(rssChannel.Title, fromDb.Title);
            }
        }

        [Test]
        public void Update()
        {
            try
            {
                // Let's get on the first element in the category table
                RssChannel channel;

                using (ISession sess = HibernateSession.getInstance().getSession())
                    channel = sess.Query<RssChannel>().First();

                // We update it by changing its name and then persist it through the DAO
                var rssChannelDao = new RssChannelDAO();
                channel.Title = "Nouveau Nom ouechouech";
                rssChannelDao.saveOrUpdate(channel);

                // We get it back from the DB with the id.
                var fromDb = rssChannelDao.findById((int)channel.IdEntity);
                
                // and check if the names are equals
                Assert.IsNotNull(fromDb);
                Assert.AreEqual(channel.Title, fromDb.Title);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail("InvalidOperationException caught, is the table empty ?\n Message : " + ex.Message);
            }
        }

        //[Test]
        //public void Delete()
        //{
        //    // Let's get on the first element in the rssChannel table
        //    RssChannel rssChannel;
        //    using (ISession sess = HibernateSession.getInstance().getSession())
        //        rssChannel = sess.Query<RssChannel>().First();

        //    Console.WriteLine("---ouech--------- Title = " + rssChannel.Title);

        //    // We delete it through the DAO
        //    var rssChannelDao = new RssChannelDAO();
        //    rssChannelDao.delete(rssChannel);

        //    // We try to get it back and test if it's null (because it doesn't exist anymore)
        //    var fromDb = rssChannelDao.findById((int)rssChannel.IdEntity);
        //    Assert.IsNull(fromDb);
        //}

        [Test]
        public void FindById()
        {
            // Let's get on the first element in the rssChannel table
            RssChannel rssChannel;
            using (ISession sess = HibernateSession.getInstance().getSession())
                rssChannel = sess.Query<RssChannel>().First();

            // We try to get the rssChannel with the id of the first element 
            var rssChannelDao = new RssChannelDAO();
            var fromDb = rssChannelDao.findById((int)rssChannel.IdEntity);

            // We test if the element is not null and if it's equal to the first element.
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(rssChannel, fromDb);
            Assert.AreEqual(rssChannel.Title, fromDb.Title);
        }

        [Test]
        public void FindAll()
        {
            var rssChannelDao = new RssChannelDAO();
            var allChannels = rssChannelDao.findAll();

            using (ISession sess = HibernateSession.getInstance().getSession())
            {
                var count = sess.CreateQuery("select count(*) from RssChannel").UniqueResult();
                Assert.IsNotNull(allChannels);
                Assert.AreEqual(count, allChannels.Count);
            }
        }

        #endregion


        //[Test]
        //public void DummyTest()
        //{
        //    var userList = new List<User>() { new User() { ID = 2, FirstName = "John", LastName = "Peterson" } };
        //    var sessionMock = new Mock<ISession>();
        //    var queryMock = new Mock<IQuery>();
        //    var transactionMock = new Mock<ITransaction>();

        //    sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
        //    sessionMock.Setup(session => session.CreateQuery("from User")).Returns(queryMock.Object);
        //    queryMock.Setup(x => x.List<User>()).Returns(userList);

        //    var controller = new UsersController(sessionMock.Object);
        //    var result = controller.Index() as ViewResult;
        //    Assert.IsNotNull(result.ViewData);
        //}


        [Test]
        public void Mock_FindByIdSuccess()
        {
            var mockSession = new Mock<ISession>();
            mockSession.Setup(r => r.Get<RssChannel>(It.IsAny<int>())).Returns(new RssChannel() { Title = "Marmiton" });

            var mockSessionFactory = new Mock<ISessionFactory>();
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;

            using (var session = sessionFactory.OpenSession())
            {
                var rs = session.Get<RssChannel>(1);
                Assert.IsNotNull(rs);
                Assert.IsInstanceOf<RssChannel>(rs);
                Assert.AreEqual(rs.Title, "Marmiton");
            }
        }


        [Test]
        public void Mock_DeleteSuccess()
        {
            var obj = new RssChannel();
            var mockSession = new Mock<ISession>();
            var mockSessionFactory = new Mock<ISessionFactory>();

            mockSession.Setup(s => s.Delete(obj));
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;
            using (var session = sessionFactory.OpenSession())
                session.Delete(obj);
            mockSession.Verify(s => s.Delete(obj));
        }

        [Test]
        public void Mock_CreateSuccess()
        {
            var entityId = Guid.NewGuid();
            var entity = new Mock<RssChannel>();
            entity.SetupAllProperties();

            var mockSession = new Mock<ISession>();
            var mockSessionFactory = new Mock<ISessionFactory>();

            mockSession.Setup(s => s.Save(entity.Object)).Returns(entityId);
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;
            using (var session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity.Object);
                Assert.AreEqual(entityId, id, "ids of Entity for created object should match.");
            }
            mockSession.Verify(s => s.Save(entity.Object));
        }

        [Test]
        public void Mock_UpdateSuccess()
        {
            var obj = new RssChannel();
            var mockSession = new Mock<ISession>();
            var mockSessionFactory = new Mock<ISessionFactory>();

            mockSession.Setup(s => s.Update(obj));
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;
            using (var session = sessionFactory.OpenSession())
                session.Update(obj);
            mockSession.Verify(s => s.Update(obj));
        }


    }
}