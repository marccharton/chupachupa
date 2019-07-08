using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class ImageController : AbstractController
    {
        public ImageController() {
            _properties = new List<ControllerProperty.IPropertyController>();

            _properties.Add(new StringPropertyController("Url", 1, 512, false));
            _properties.Add(new StringPropertyController("Title", 1, 128, false));
            _properties.Add(new StringPropertyController("Link", 1, 512, false));

            _properties.Add(new StringPropertyController("Description", 0, 512, true));
            _properties.Add(new IntPropertyController("Width", 0, Int64.MaxValue, true));
            _properties.Add(new IntPropertyController("Height", 0, Int64.MaxValue, true));
        }
    }
}
