using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChupaChupa.Business.Database.DAO;
using ChupaChupa.Entities;
using Moq;
using NHibernate.Linq;
using NUnit.Framework;
using NHibernate;
using ChupaChupa.Business.Database.Session;

namespace ChupaChupa.Business.Test.Database.DAO
{
    [TestFixture]
    class CategoryDAOTest : IDAOTest
    {

        #region Initialisation of Datas

        //private readonly Category[] _categories = new[] {
        //    new Category() {Name = "Heu qu'est ce que tu fous la toi!"},
        //    new Category() {Name = "Informatique"},
        //    new Category() {Name = "Divers"},
        //    new Category() {Name = "Geek"},
        //    new Category() {Name = "Tunning"},
        //    new Category() {Name = "News"},
        //    new Category() {Name = "Sport"}
        //};

        //private void CreateInitialData()
        //{
        //    var userDao = new UserDAO();
        //    User usr = userDao.findById(1);
        //    if (usr == null)
        //        return;
        //    foreach (var category in _categories)
        //        usr.addCategory(category);
        //    userDao.saveOrUpdate(usr);
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
            // First you have to get the user you want to add the category to.
            // In this example, we create a new user
            var userDao = new UserDAO();
            var user = new User() { LoginMail = "monlogindesuperuser", Password = "passde MALADE" };

            // Now let's create our category
            var category = new Category() { Name = "Coucoulescopains" };
           
            // Now we add the category to the user
            user.addCategory(category);

            // And then, we save the user we've just created
            // The category we'll be inserted too thanks to the relationship between User and Category
            userDao.saveOrUpdate(user);

            using (ISession sess = HibernateSession.getInstance().getSession())
            {
                var fromDb = sess.Get<Category>(category.IdEntity);
                // Test that the category was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(category, fromDb);
                Assert.AreEqual(category.Name, fromDb.Name);
            }
        }

        [Test]
        public void Update()
        {
            // Let's get on the first element in the category table
            Category category;
            try {
                using (ISession sess = HibernateSession.getInstance().getSession())
                    category = sess.Query<Category>().First();

                // We update it by changing its name and then persist it through the DAO
                var categoryDao = new CategoryDAO();
                category.Name = "Nouveau Nom ouechouech";
                categoryDao.saveOrUpdate(category);

                // We get it back from the DB with the id.
                var fromDb = categoryDao.findById((int)category.IdEntity);
                // and check if the names are equals
                Assert.AreEqual(category.Name, fromDb.Name);
            }
            catch (InvalidOperationException ex) {
                Assert.Fail("InvalidOperationException caught, is the table empty ?\n Message : " + ex.Message);
            }
        }

        [Test]
        public void Delete()
        {
            // Let's get on the first element in the category table
            Category category;
            using (ISession sess = HibernateSession.getInstance().getSession())
                category = sess.Query<Category>().First();

            // We delete it through the DAO
            var categoryDao = new CategoryDAO();
            categoryDao.delete(category);

            // We try to get it back and test if it's null (because it doesn't exist anymore)
            var fromDb = categoryDao.findById((int)category.IdEntity);
            Assert.IsNull(fromDb);
        }


        [Test]
        public void FindById()
        {
            // Let's get on the first element in the category table
            Category category;
            using (ISession sess = HibernateSession.getInstance().getSession())
                category = sess.Query<Category>().First();

            // We try to get the category with the id of the first element 
            var categoryDao = new CategoryDAO();
            var fromDb = categoryDao.findById((int)category.IdEntity);
            
            // We test if the element is not null and if it's the same than than the first element.
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(category, fromDb);
            Assert.AreEqual(category.Name, fromDb.Name);
        }

        [Test]
        public void FindAll()
        {
            var categoryDao = new CategoryDAO();
            var allCategories = categoryDao.findAll();

            using (ISession sess = HibernateSession.getInstance().getSession())
            {
                var count = sess.CreateQuery("select count(*) from Category").UniqueResult();
                Assert.IsNotNull(allCategories);
                Assert.AreEqual(count, allCategories.Count);
            }
        }

        [Test]
        public void FindByUserAndName()
        {
            // Let's first save a user with a category to be sure we have what we want to test
            var userDao = new UserDAO();
            var user = new User() { LoginMail = "monlogindesuperuser", Password = "passde MALADE" };
            var category = new Category() { Name = "Coucoulescopains" };
            user.addCategory(category);
            userDao.saveOrUpdate(user);

            // we get the category with the user
            var categoryDao = new CategoryDAO();
            var fromDb = categoryDao.findByUserAndName(user, category.Name);

            // We test if the category is the one we want and if it is assigned to the same user
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(category, fromDb);
            Assert.AreEqual(category.Name, fromDb.Name);
            Assert.AreEqual(user.IdEntity, fromDb.User.IdEntity);
        }

        #endregion 


        #region Mock Testing

        [Test]
        public void Mock_FindByIdSuccess()
        {
            var mockSession = new Mock<ISession>();
            mockSession.Setup(r => r.Get<Category>(It.IsAny<int>())).Returns(new Category() { Name = "Informatique" });

            var mockSessionFactory = new Mock<ISessionFactory>();
            mockSessionFactory.Setup(r => r.OpenSession()).Returns(mockSession.Object);

            var sessionFactory = mockSessionFactory.Object;

            using (var session = sessionFactory.OpenSession())
            {
                var rs = session.Get<Category>(1);
                Assert.IsNotNull(rs);
                Assert.IsInstanceOf<Category>(rs);
                Assert.AreEqual(rs.Name, "Informatique");
            }
        }

        [Test]
        public void Mock_DeleteSuccess()
        {
            var obj = new Category();
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
            var entity = new Mock<Category>();
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
            var obj = new Category();
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
