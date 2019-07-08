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
    public class RssItemDAOTest : IDAOTest
    {

        #region Unit Testing

        [Test]
        public void Save()
        {
            RssChannel rssChannel;

            using (ISession sess = HibernateSession.getInstance().getSession())
                rssChannel = sess.Query<RssChannel>().First();

            var rssItemDao = new RssItemDAO();

            var dt2 = new DateTime(1999, 12, 06);
            var myEnclosure = new Enclosure() { Length = 10, Url = "www.myenclosure.com", Type = "Typedemonenclosure" };
            var mySource = new Source() { Url = "www.mysource.com" };

            var rssItem = new RssItem()
            {
                Title = "My ITEM",
                Link = "www.myItem.com",
                PubDate = dt2,
                Description = "super item ce myItem !",
                Enclosure = myEnclosure,
                Source = mySource
            };
            rssItem.addRssCategory(new RssCategory() { Name = "category", Domain = "ouech tonton" });
            rssChannel.addRssItem(rssItem);

            rssItemDao.saveOrUpdate(rssItem);
        }

        [Test]
        public void Update()
        {
            try
            {
                // Let's get on the first element in the category table
                RssItem rssItem;

                using (ISession sess = HibernateSession.getInstance().getSession())
                    rssItem = sess.Query<RssItem>().First();

                // We update it by changing its name and then persist it through the DAO
                var rssItemDao = new RssItemDAO();
                rssItem.Title = "Nouveau Nom ouechouech";
                rssItemDao.saveOrUpdate(rssItem);

                // We get it back from the DB with the id.
                var fromDb = rssItemDao.findById((int)rssItem.IdEntity);

                // and check if the names are equals
                Assert.IsNotNull(fromDb);
                Assert.AreEqual(rssItem.Title, fromDb.Title);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail("InvalidOperationException caught, is the table empty ?\n Message : " + ex.Message);
            }
        }

        [Test]
        public void FindById()
        {
            // Let's get on the first element in the rssItem table
            RssItem rssItem;
            using (ISession sess = HibernateSession.getInstance().getSession())
                rssItem = sess.Query<RssItem>().First();

            // We try to get the rssItem with the id of the first element 
            var rssItemDao = new RssItemDAO();
            var fromDb = rssItemDao.findById((int)rssItem.IdEntity);

            // We test if the element is not null and if it's equal to the first element.
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(rssItem, fromDb);
            Assert.AreEqual(rssItem.Title, fromDb.Title);
        }

        [Test]
        public void FindAll()
        {
            var rssItemDao = new RssItemDAO();
            var allChannels = rssItemDao.findAll();

            using (ISession sess = HibernateSession.getInstance().getSession())
            {
                var count = sess.CreateQuery("select count(*) from RssItem").UniqueResult();
                Assert.IsNotNull(allChannels);
                Assert.AreEqual(count, allChannels.Count);
            }
        }

        #endregion


        #region Mock Testing
        [Test]
        public void Mock_FindByIdSuccess()
        {
            var mockSession = new Mock<ISession>();
            mockSession.Setup(r => r.Get<RssItem>(It.IsAny<int>())).Returns(new RssItem() { Title = "La recette de la tarte aux poireaux" });

            var mockSessionFactory = new Mock<ISessionFactory>();
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;

            using (var session = sessionFactory.OpenSession())
            {
                var rs = session.Get<RssItem>(1);
                Assert.IsNotNull(rs);
                Assert.IsInstanceOf<RssItem>(rs);
                Assert.AreEqual(rs.Title, "La recette de la tarte aux poireaux");
            }
        }

        [Test]
        public void Mock_DeleteSuccess()
        {
            var obj = new RssItem();
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
            var entity = new Mock<RssItem>();
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
            var obj = new RssItem();
            var mockSession = new Mock<ISession>();
            var mockSessionFactory = new Mock<ISessionFactory>();

            mockSession.Setup(s => s.Update(obj));
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;
            using (var session = sessionFactory.OpenSession())
                session.Update(obj);
            mockSession.Verify(s => s.Update(obj));
        }

        #endregion

    }
}
