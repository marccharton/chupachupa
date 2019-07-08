using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    public class ListPropertyController : IPropertyController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ListPropertyController));

        public String PropertyName { get; set; }
        public IController Controller { get; set; }

        public bool CanBeNull { get; set; }

        public ListPropertyController(String propertyName) {
            PropertyName = propertyName;
            Controller = null;
            CanBeNull = true;
        }

        public ListPropertyController(String propertyName, bool canBeNull) {
            PropertyName = propertyName;
            Controller = null;
            CanBeNull = canBeNull;
        }

        public ListPropertyController(String propertyName, bool canBeNull, IController controller) {
            PropertyName = propertyName;
            Controller = controller;
            CanBeNull = canBeNull;
        }


        public virtual bool controlProperty(object obj, bool quiet) {
            bool success = true;
            IList valueToControl;

            success = this.controlNullValue(obj, quiet);
            if (obj == null) {
                return success;
            }

            success = this.controlListType(obj, quiet);
            if (!success) {
                return success;
            }
            
            valueToControl = obj as IList;

            if (Controller != null) {
                foreach (object tmp in valueToControl) {
                    success = Controller.controlData(tmp, quiet);
                    if (!success) {
                        break;
                    }
                }
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

        private bool controlListType(object value, bool quiet) {
            bool success = false;

            if (value is IList) {
                success = true;
            }

            if (!success && !quiet) {
                Logger.Error("Property " + PropertyName + " is not a list type");
            }
            return success;
        }
    }
}
