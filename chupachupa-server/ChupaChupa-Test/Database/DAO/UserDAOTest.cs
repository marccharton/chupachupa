using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa_Server.Database.DAO;
using ChupaChupa_Model.Entities;
using ChupaChupa_Server.Database.Session;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace ChupaChupa_Server_Test.Database.DAO
{
    [TestFixture]
    class UserDAOTest : IDAOTest
    {
        private readonly User[] _users = new[] {
            new User() {LoginMail = "test-user@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
            new User() {LoginMail = "bastien.minarie-pagnier@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
            new User() {LoginMail = "jeremy.seita@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
            new User() {LoginMail = "florian.guiho@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
            new User() {LoginMail = "marc.charton@epitech.eu", Password = "7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b"},
        };

        private void CreateInitialData()
        {
            using (ISession sess = HibernateSession.getInstance().getSession())
                using (ITransaction tx = sess.BeginTransaction())
                {
                    foreach (var user in _users)
                        sess.Save(user);
                    tx.Commit();
                }
        }

        [SetUp]
        public void SetupContext()
        {
            // créer une methode public dans HibernateSession pour exporter le schema
            // stocker la _configuration dans une variable privée pour pouvoir y accéder... car pour le moment on fait direct configure() dessus sans la stocker
            // new SchemaExport(_configuration).Execute(false, true, false, false);
            //CreateInitialData();
        }

        [Test]
        public void Save()
        {
            var user = new User() { LoginMail = "jeanpierre", Password = "passDeJeanpierre", OAuthToken = "token" };
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
            var user = _users[0];
            user.LoginMail = "newMail@gmail.com";
            var userDao = new UserDAO();
            userDao.saveOrUpdate(user);

            // use session to try to load the product
            using (ISession sess = HibernateSession.getInstance().getSession())
                using (ITransaction tx = sess.BeginTransaction())
                {
                    var fromDb = sess.Get<User>(user.IdEntity);
                    Assert.AreEqual(user.LoginMail, fromDb.LoginMail);
                }
        }

        [Test]
        public void Delete()
        {
            var user = _users[0];
            var userDao = new UserDAO();
            userDao.delete(user);

            using (ISession sess = HibernateSession.getInstance().getSession())
                using (ITransaction tx = sess.BeginTransaction())
                {
                    var fromDb = sess.Get<User>(user.IdEntity);
                    Assert.IsNull(fromDb);
                }
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

        [Test]
        public void FindByToken()
        {
            User user;
            using (ISession sess = HibernateSession.getInstance().getSession())
                user = sess.Query<User>().First();

            var userDao = new UserDAO();
            var fromDb = userDao.findByToken(user.OAuthToken);

            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(user, fromDb);
            Assert.AreEqual(user.LoginMail, fromDb.LoginMail);
            Assert.AreEqual(user.Password, fromDb.Password);
            Assert.AreEqual(user.OAuthToken, fromDb.OAuthToken);
        }
    }
}
