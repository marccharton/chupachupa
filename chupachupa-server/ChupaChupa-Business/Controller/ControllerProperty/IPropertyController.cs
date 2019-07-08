using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    public interface IPropertyController
    {
        String PropertyName { get; set; }

        IController Controller { get; set; }

        bool controlProperty(object obj, bool quiet);

        bool controlProperty(object obj);
    }
}
