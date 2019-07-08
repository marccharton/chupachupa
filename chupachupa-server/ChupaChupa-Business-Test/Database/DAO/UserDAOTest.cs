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
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace ChupaChupa.Business.Test.Database.DAO
{
    [TestFixture]
    class UserDAOTest : IDAOTest
    {

        #region Initialisation of Datas

        //private readonly User[] _users = new[] {
        //    new User() {LoginMail = "test-user@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
        //    new User() {LoginMail = "bastien.minarie-pagnier@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
        //    new User() {LoginMail = "jeremy.seita@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
        //    new User() {LoginMail = "florian.guiho@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
        //    new User() {LoginMail = "marc.charton@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
        //};

        //private void CreateInitialData()
        //{
        //    using (ISession sess = HibernateSession.getInstance().getSession())
        //        using (ITransaction tx = sess.BeginTransaction())
        //        {
        //            foreach (var user in _users)
        //                sess.Save(user);
        //            tx.Commit();
        //        }
        //}

        //[SetUp]
        //public void SetupContext()
        //{
        //    // créer une methode public dans HibernateSession pour exporter le schema
        //    // stocker la _configuration dans une variable privée pour pouvoir y accéder... car pour le moment on fait direct configure() dessus sans la stocker
        //    // new SchemaExport(_configuration).Execute(false, true, false, false);
        //    //CreateInitialData();
        //}

        #endregion


        #region Unit Testing

        [Test]
        public void Save()
        {
            var user = new User() { LoginMail = "monlogin", Password = "MonsuperPassCrypté", OAuthToken = "token"};
            var userDao = new UserDAO();
            userDao.saveOrUpdate(user);

            using (ISession sess = HibernateSession.getInstance().getSession())
            {
                var fromDb = sess.Get<User>(user.IdEntity);
                // Test that the product was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(user, fromDb);
                Assert.AreEqual(user.LoginMail, fromDb.LoginMail);
                Assert.AreEqual(user.Password, fromDb.Password);
                Assert.AreEqual(user.OAuthToken, fromDb.OAuthToken);
            }
        }

        [Test]
        public void Update()
        {
            // Let's get on the first element in the category table
            User user;
            try
            {
                using (ISession sess = HibernateSession.getInstance().getSession())
                    user = sess.Query<User>().First();

                // We update it by changing its name and then persist it through the DAO
                var userDao = new UserDAO();
                user.LoginMail = "newMail@gmail.com";
                userDao.saveOrUpdate(user);

                // We get it back from the DB with the id.
                var fromDb = userDao.findById((int)user.IdEntity);
                
                // and make our assertions
                Assert.IsNotNull(fromDb);
                Assert.IsInstanceOf<User>(fromDb);
                Assert.AreEqual(user.LoginMail, fromDb.LoginMail);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail("InvalidOperationException caught, is the table empty ?\n Message : " + ex.Message);
            }
        }

        [Test]
        public void Delete()
        {
            User user;
            using (ISession sess = HibernateSession.getInstance().getSession())
                user = sess.Query<User>().First();
            
            if (user.Categories != null)
            {
                if (user.Categories.Count > 0)
                {
                    var catDao = new CategoryDAO();
                    foreach (var category in user.Categories)
                    {
                        catDao.delete(category);
                    }
                }
            }
            var userDao = new UserDAO();
            userDao.delete(user);

            using (ISession sess = HibernateSession.getInstance().getSession())
            using (ITransaction tx = sess.BeginTransaction())
            {
                var fromDb = sess.Get<User>(user.IdEntity);
                Assert.IsNull(fromDb);
            }



            //// We delete it through the DAO
            //var categoryDao = new CategoryDAO();
            //categoryDao.delete(category);

            //// We try to get it back and test if it's null (because it doesn't exist anymore)
            //var fromDb = categoryDao.findById((int)category.IdEntity);
            //Assert.IsNull(fromDb);

        }


        [Test]
        public void FindById()
        {
            // Let's get on the first element in the user table
            User user;
            using (ISession sess = HibernateSession.getInstance().getSession())
                user = sess.Query<User>().First();

            // We try to get the user with the id of the first element 
            var userDao = new UserDAO();
            var fromDb = userDao.findById((int)user.IdEntity);

            // We test if the element is not null and if it's the same than than the first element.
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(user, fromDb);
            Assert.AreEqual(user.LoginMail, fromDb.LoginMail);
            Assert.AreEqual(user.Password, fromDb.Password);
            Assert.AreEqual(user.OAuthToken, fromDb.OAuthToken);
        }

        [Test]
        public void FindAll()
        {
            var userDao = new UserDAO();
            var allUsers = userDao.findAll();

            using (ISession sess = HibernateSession.getInstance().getSession())
            {
                var count = sess.CreateQuery("select count(*) from User").UniqueResult();
                Assert.IsNotNull(allUsers);
                Assert.AreEqual(count, allUsers.Count);
            }
        }

        [Test]
        public void FindByLoginAndPassword()
        {
            User user;
            using (ISession sess = HibernateSession.getInstance().getSession())
                user = sess.Query<User>().First();

            var userDao = new UserDAO();
            var fromDb = userDao.findByLoginAndPassword(user.LoginMail, user.Password);

            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(user, fromDb);
            Assert.AreEqual(user.LoginMail, fromDb.LoginMail);
            Assert.AreEqual(user.Password, fromDb.Password);
            Assert.AreEqual(user.OAuthToken, fromDb.OAuthToken);
        }

        #endregion


        #region Mock Testing

        [Test]
        public void Mock_FindByIdSuccess()
        {
            var mockSession = new Mock<ISession>();
            mockSession.Setup(r => r.Get<User>(It.IsAny<int>())).Returns(new User() { LoginMail = "Toto" });

            var mockSessionFactory = new Mock<ISessionFactory>();
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;

            using (var session = sessionFactory.OpenSession())
            {
                var rs = session.Get<User>(1);
                Assert.IsNotNull(rs);
                Assert.IsInstanceOf<User>(rs);
                Assert.AreEqual(rs.LoginMail, "Toto");
            }
        }

        [Test]
        public void Mock_DeleteSuccess()
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
        public void Mock_CreateSuccess()
        {
            var entityId = Guid.NewGuid();
            var entity = new Mock<User>();
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
            var user = new User();
            var mockSession = new Mock<ISession>();
            var mockSessionFactory = new Mock<ISessionFactory>();

            mockSession.Setup(s => s.Update(user));
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;
            using (var session = sessionFactory.OpenSession())
                session.Update(user);
            mockSession.Verify(s => s.Update(user));
        }




        #endregion
    }
}
