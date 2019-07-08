using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NHibernate;
using ChupaChupa.Business.Database.Session;

namespace ChupaChupa.Business.Test.Database.Session
{
    [TestFixture(Description = "Test Class For Nhibernate Session")]
    class NHibernateSessionTest
    {
        [Test]
        public void test_getInstanceSession()
        {
            HibernateSession hs = HibernateSession.getInstance();
            Assert.IsNotNull(hs);
        }

        [Test]
        public void test_openSession()
        {
            HibernateSession hs = HibernateSession.getInstance();
            Assert.IsTrue(hs.openSession());
        }

        [Test]
        public void test_getSession()
        {
            HibernateSession hs = HibernateSession.getInstance();
            ISession sess       = hs.getSession();
            Assert.IsNotNull(sess);
        }

        [Test]
        public void test_closeSession()
        {
            HibernateSession hs = HibernateSession.getInstance();
            hs.closeSession();
        }

        [Test]
        public void test_beginTransaction()
        {
            HibernateSession hs = HibernateSession.getInstance();
            ISession sess       = hs.getSession();
            ITransaction tx     = sess.BeginTransaction();
            Assert.IsNotNull(tx);
            sess.Close();
        }
        

        
    }


}
