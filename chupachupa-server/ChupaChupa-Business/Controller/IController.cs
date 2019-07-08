using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public interface IController
    {
        bool controlData(object obj);

        bool controlData(object obj, bool quiet);
    }
}
