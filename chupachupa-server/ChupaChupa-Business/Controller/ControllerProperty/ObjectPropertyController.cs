using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    public class ObjectPropertyController : IPropertyController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ObjectPropertyController));

        public String PropertyName { get; set; }
        public IController Controller { get; set; }

        public bool CanBeNull { get; set; }

        public ObjectPropertyController(String propertyName) {
            PropertyName = propertyName;
            Controller = null;
            CanBeNull = true;
        }

        public ObjectPropertyController(String propertyName, bool canBeNull) {
            PropertyName = propertyName;
            Controller = null;
            CanBeNull = canBeNull;
        }

        public ObjectPropertyController(String propertyName, bool canBeNull, IController controller) {
            PropertyName = propertyName;
            Controller = controller;
            CanBeNull = canBeNull;
        }


        public virtual bool controlProperty(object obj, bool quiet) {
            bool success = true;

            success = this.controlNullValue(obj, quiet);
            if (!success || obj == null) {
                return success;
            }
            if (Controller != null) {
                success = Controller.controlData(obj, quiet); 
            } else {
                if (!quiet) {
                    Logger.Warn("No controller found for " + PropertyName);
                }
            }
            return success;
        }

        public virtual bool controlProperty(object obj) {
            return this.controlProperty(obj, false);
        }

        private bool controlNullValue(object value, bool quiet) {
            bool success = true;

            if (value == null && !CanBeNull) {
                if (!quiet) {
                    Logger.Error("Property " + PropertyName + " is null");
                }
                success = false;
            }
            return success;
        }
    }
}
