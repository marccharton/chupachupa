using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Database.DAO
{
    public interface IDAO<T>
    {
        IList<T> findAll();
        T findById(Int64 id);
        bool delete(T obj);
        bool saveOrUpdate(T obj);
    }
}
