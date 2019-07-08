using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChupaChupa.Business.Test.Database.DAO
{
    public interface IDAOTest
    {
        void Save();
        void Update();
        //void Delete();
        void FindById();
        void FindAll();
    }

}
