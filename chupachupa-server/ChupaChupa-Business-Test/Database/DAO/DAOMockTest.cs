using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Business.Database.Session;
using ChupaChupa.Entities;
using Moq;
using NHibernate;
using NUnit.Framework;

namespace ChupaChupa.Business.Test.Database.DAO
{
    [TestFixture]
    public class nHibernateRepositoryTests
    {

        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        [Ignore]
        public void Verify_NHibernateMappings()
        {
            //ToDo: validate mapping files
        }

        /// <summary>
        /// Verify that the Repository create calls into the provided NHibernate session.
        /// We are only going to verify that the repository correctly calls the provided NHibernate session object
        /// </summary>
        [Test]
        public void Create_Success()
        {
            ////Setup sessions
            

            //var entityId = Guid.NewGuid();
            //var entity = new Mock<User>();
            //entity.SetupAllProperties();
            ////entity.Stub(y => y.Id, entityId);
            //////entity.Object.Id = entityId; //ToDo: define how and where we want to inject our id generation strategies


            //var mockSession = new Mock<ISession>();
            //var mockSessionFactory = new Mock<ISessionFactory>();

            //mockSession.Setup(s => s.Save(entity.Object)).Returns(entityId);
            //mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            //var sessionFactory = mockSessionFactory.Object;
            //using (var session = sessionFactory.OpenSession())
            //    session.Save(entityId);

            //////Assert Results
            ////Assert.AreEqual(entityId, id, "Entity ids for created object should match.");

            //////Verify Mocks
            ////_mockSessionManager.Verify(sm => sm.OpenSession());
            //mockSession.Verify(s => s.Save(entity.Object));

        }

        [Test]
        public void Delete_ById_Success()
        {
            var user = new User();
            var mockSession = new Mock<ISession>();
            var mockSessionFactory = new Mock<ISessionFactory>();
            
            mockSession.Setup(s => s.Delete(user));
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;
            using (var session = sessionFactory.OpenSession())
                session.Delete(user);
            mockSession.Verify(s => s.Delete(user));
        }

        [Test]
        public void Delete_Entity_Success()
        {
            //var entity = new ContentItem();

            //_mockSession.Setup(s => s.Delete(entity));

            //var repos = new nHibernateRepository<ContentItem>(_mockSessionManager.Object);
            //repos.Delete(entity);

            //_mockSessionManager.Verify(s => s.OpenSession());
            //_mockSession.Verify(s => s.Delete(entity));
        }

        [Test]
        [Ignore("Need to implement Mantle ICriteria to NHibernate Criteria type conversion for this test to pass.")]
        public void Delete_ByCriteria_Success()
        {
            //var criteria = new Mock<Mantle.Framework.Criteria.ICriteria>();

            //_mockSession.Setup(s => s.Delete(criteria.Object));

            //var repos = new nHibernateRepository<ContentItem>(_mockSessionManager.Object);
            //repos.Delete(criteria.Object);

            //_mockSessionManager.Verify(s => s.OpenSession());
            //_mockSession.Verify(s => s.Delete(criteria.Object));
        }

        [Test]
        public void Update_Entity_Success()
        {
            //var contentItem = new ContentItem();

            //_mockSession.Setup(s => s.Update(contentItem));

            //var repos = new nHibernateRepository<ContentItem>(_mockSessionManager.Object);
            //var result = repos.Update(contentItem);

            //Assert.AreSame(contentItem, result);

            //_mockSessionManager.Verify(s => s.OpenSession());
            //_mockSession.Verify(s => s.Update(contentItem));

        }

        [Test]
        public void Fetch_Entity_ById_Success()
        {
            //var id = Guid.NewGuid();
            //var contentItem = new ContentItem();

            //_mockSession.Setup(s => s.Get<ContentItem>(id)).Returns(contentItem);

            //var repos = new nHibernateRepository<ContentItem>(_mockSessionManager.Object);
            //var result = repos.Fetch(id);

            //Assert.AreSame(contentItem, result, "Did not receive expected content item.");

            //_mockSessionManager.Verify(s => s.OpenSession());
            //_mockSession.Verify(s => s.Get<ContentItem>(id));
        }

        [Test]
        [Ignore("Need to implement Mantle ICriteria to NHibernate Criteria type conversion for this test to pass.")]
        public void FetchAll_ByCriteria_Success()
        {

        }
    }
}
