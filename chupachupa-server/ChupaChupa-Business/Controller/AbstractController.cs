using ChupaChupa.Business.Controller.ControllerProperty;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class AbstractController : IController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AbstractController));

        protected List<IPropertyController> _properties;

        public AbstractController() {
            _properties = null;
        }

        public virtual bool controlData(object obj) {
            return controlData(obj, false);
        }

        public virtual bool controlData(object obj, bool quiet) {
            bool success = true;
            
            foreach (IPropertyController controller in _properties) {
                success &= controller.controlProperty(this.getValueForProperty(obj, controller.PropertyName));
            }
            return success;
        }

        private object getValueForProperty(object obj, String propertyName) {
            object ret = null;

            if (obj == null || propertyName == null || propertyName.Length == 0) {
                return ret;
            }

            try {
                ret = obj.GetType().GetProperty(propertyName).GetValue(obj);
            } catch (Exception ex) {
                Logger.Error("Unable to get value for property: " + propertyName + " because " + ex.Message);
                ret = null;
            }
            return ret;
        }

    }
}
