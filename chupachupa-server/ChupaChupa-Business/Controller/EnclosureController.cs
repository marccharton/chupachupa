using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class EnclosureController : AbstractController
    {
        public EnclosureController() : base() {
            _properties = new List<ControllerProperty.IPropertyController>();
            
            _properties.Add(new StringPropertyController("Url", 1, 512, false));
            _properties.Add(new IntPropertyController("Length", 0, Int64.MaxValue, false));
            _properties.Add(new StringPropertyController("Type", 1, 64, false));
        }
    }
}
