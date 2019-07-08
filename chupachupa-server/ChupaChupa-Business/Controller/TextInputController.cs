using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class TextInputController : AbstractController
    {
        public TextInputController() : base() {
            _properties = new List<ControllerProperty.IPropertyController>();

            _properties.Add(new StringPropertyController("Title", 1, 128, false));
            _properties.Add(new StringPropertyController("Description", 1, 512, false));
            _properties.Add(new StringPropertyController("Name", 1, 64, false));
            _properties.Add(new StringPropertyController("Link", 0, 512, true));
        }
    }
}
