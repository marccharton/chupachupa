using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class SourceController : AbstractController
    {
        public SourceController() : base () {
            _properties = new List<ControllerProperty.IPropertyController>();

            _properties.Add(new StringPropertyController("Url", 1, 512, false));
        }

    }
}
