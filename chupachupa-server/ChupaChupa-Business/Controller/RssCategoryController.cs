using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class RssCategoryController : AbstractController
    {
        public RssCategoryController() : base() 
        {
            _properties = new List<ControllerProperty.IPropertyController>();
            
            _properties.Add(new StringPropertyController("Name", 1, 64, false));
            _properties.Add(new StringPropertyController("Domain", 1, 128, false));
        }

    }
}
