using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class SkipHoursController : AbstractController
    {
        public SkipHoursController() : base() {
            _properties = new List<ControllerProperty.IPropertyController>();

            _properties.Add(new IntPropertyController("Hour", 0, 23, false));
        }

    }
}
