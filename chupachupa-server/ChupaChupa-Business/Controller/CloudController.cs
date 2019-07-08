using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class CloudController : AbstractController
    {
        public CloudController() : base () {
            _properties = new List<ControllerProperty.IPropertyController>();

            _properties.Add(new StringPropertyController("Domain", 1, 128, false));
            _properties.Add(new IntPropertyController("Port", 1, 65536, false));
            _properties.Add(new StringPropertyController("Path", 1, 128, false));
            _properties.Add(new StringPropertyController("RegisterProcedure", 1, 32, false));
            _properties.Add(new StringPropertyController("Protocol", 1, 32, false));
        }
    }
}
