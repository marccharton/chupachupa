using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    public class IntPropertyController : IPropertyController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(IntPropertyController));

        public String PropertyName { get; set; }
        public IController Controller { get; set; }

        public Int64 MinValue { get; set; }
        public Int64 MaxValue { get; set; }
        public bool CanBeNull { get; set; }
        public List<Int64> PossibleValues { get; set; }

        public IntPropertyController(String propertyName) {
            PropertyName = propertyName;
            Controller = null;
            MinValue = Int64.MinValue;
            MaxValue = Int64.MaxValue;
            CanBeNull = true;
            PossibleValues = null;            
        }

        public IntPropertyController(String propertyName, Int64 minValue, Int64 maxValue, bool canBeNull) {
            PropertyName = propertyName;
            Controller = null;
            MinValue = minValue;
            MaxValue = maxValue;
            CanBeNull = canBeNull;
            PossibleValues = null;
        }


        public virtual bool controlProperty(object obj, bool quiet) {
            bool success = true;
            Int64 valueToControl;

            try {
                valueToControl = Convert.ToInt64(obj);
            } catch (Exception ex) {
                success = false;
                if (!quiet) {
                    Logger.Error("Unable to convert "+ PropertyName +" to Int64 because " + ex.Message);
                }
                return success;
            }

            return this.controlSize(valueToControl, quiet) && this.controlPossibleValues(valueToControl, quiet);
        }

        public virtual bool controlProperty(object obj) {
            return this.controlProperty(obj, false);
        }

        private bool controlSize(Int64 value, bool quiet) {
            bool success = true;

            if (value > MaxValue) {
                if (!quiet) {
                    Logger.Error("Value for property " + PropertyName + " is too large. Max value is " + MaxValue);
                }
                success = false;
            }

            if (value < MinValue && success) {
                if (!quiet) {
                    Logger.Error("Value for property " + PropertyName + " is too small. Min value is " + MinValue);
                }
                success = false;
            }

            return success;
        }

        private bool controlPossibleValues(Int64 value, bool quiet) {
            bool success = true;
            bool valid = false;

            if (PossibleValues == null || PossibleValues.Count == 0) {
                return success;
            }

            foreach (Int64 integ in PossibleValues) {
                if (integ == value) {
                    valid = true;
                }
                if (valid) {
                    break;
                }
            } 

            success = valid;
            if (!success && !quiet) { 
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid value found for property ").Append(PropertyName).Append(". Possible values are:\n");
                foreach (Int64 integ in PossibleValues) {
                    sb.Append(integ).Append('\n');
                }
                Logger.Error(sb.ToString());
            }

            return success;
        }

    }
}
