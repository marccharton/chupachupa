using ChupaChupa.Business.Controller;
using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Test.Controller.ControllerProperty
{
    class FakeObjectController : IController
    {
        protected List<IPropertyController> _properties;

        public FakeObjectController() {
            _properties = new List<IPropertyController>();

            _properties.Add(new StringPropertyController("stringValue", 1, 128, false));
            _properties.Add(new IntPropertyController("intValue", 1, 65536, false));
        }

        public virtual bool controlData(object obj, bool quiet) {
            bool success = true;

            foreach (IPropertyController controller in _properties) {
                success &= controller.controlProperty(this.getValueForProperty(obj, controller.PropertyName));
            }
            return success;
        }

        private object getValueForProperty(object obj, String propertyName)
        {
            object ret = null;

            if (obj == null || propertyName == null || propertyName.Length == 0) {
                return ret;
            }

            try
            {
                ret = obj.GetType().GetProperty(propertyName).GetValue(obj);
            }
            catch (Exception ex)
            {
                ret = null;
            }
            return ret;
        }

        public virtual bool controlData(object obj) {
            return controlData(obj, false);
        }

    }
}
