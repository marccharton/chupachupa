using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class SkipDaysController : AbstractController
    {
        public SkipDaysController() : base() {
            _properties = new List<ControllerProperty.IPropertyController>();

            List<String> possibleValues = new List<String>();
            possibleValues.Add("Monday");
            possibleValues.Add("Tuesday");
            possibleValues.Add("Wednesday");
            possibleValues.Add("Thursday");
            possibleValues.Add("Friday");
            possibleValues.Add("Saturday");
            possibleValues.Add("Sunday");

            _properties.Add(new StringPropertyController("Day", 1, 32, false, possibleValues));
        }
    }
}
