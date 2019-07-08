using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller.ControllerProperty
{
    public class StringPropertyController : IPropertyController
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(StringPropertyController));

        public String PropertyName { get; set; }
        public IController Controller { get; set; }

        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public bool CanBeNull { get; set; }
        public List<String> PossibleFormats { get; set; }
        public List<String> PossibleValues { get; set; }

        public StringPropertyController(String propertyName) {
            PropertyName = propertyName;
            Controller = null;
            MinSize = -1;
            MaxSize = 100000;
            CanBeNull = true;
            PossibleFormats = null;
            PossibleValues = null;            
        }

        public StringPropertyController(String propertyName, int minSize, int maxSize, bool canBeNull) {
            PropertyName = propertyName;
            Controller = null;
            MinSize = minSize;
            MaxSize = maxSize;
            CanBeNull = canBeNull;
            PossibleFormats = null;
            PossibleValues = null;
        }

        public StringPropertyController(String propertyName, int minSize, int maxSize, bool canBeNull, List<String> possibleValues) {
            PropertyName = propertyName;
            Controller = null;
            MinSize = minSize;
            MaxSize = maxSize;
            CanBeNull = canBeNull;
            PossibleFormats = null;
            PossibleValues = possibleValues;
        }

        public virtual bool controlProperty(object obj, bool quiet) {
            bool success = true;
            
            String valueToControl = obj as String;

            success = this.controlNullValue(valueToControl, quiet);
            if (!success || valueToControl == null) {
                return success;
            }
            return this.controlSize(valueToControl, quiet) && this.controlPossibleValues(valueToControl, quiet) && 
                this.controlPossibleFormats(valueToControl, quiet);
        }

        public virtual bool controlProperty(object obj) {
            return this.controlProperty(obj, false);
        }

        private bool controlNullValue(String value, bool quiet) {
            bool success = true;

            if (value == null && !CanBeNull) {
                if (!quiet) {
                    Logger.Error("Property " + PropertyName + " is null");
                }
                success = false;
            }
            return success;
        }

        private bool controlSize(String value, bool quiet) {
            bool success = true;

            if (value.Length > MaxSize) {
                if (!quiet) {
                    Logger.Error("Value for property " + PropertyName + " is too large. Max length is " + MaxSize);
                }
                success = false;
            }

            if (value.Length < MinSize && success) {
                if (!quiet) {
                    Logger.Error("Value for property " + PropertyName + " is too small. Min length is " + MinSize);
                }
                success = false;
            }

            return success;
        }

        private bool controlPossibleValues(String value, bool quiet) {
            bool success = true;
            bool valid = false;

            if (PossibleValues == null || PossibleValues.Count == 0) {
                return success;
            }

            foreach (String str in PossibleValues) {
                if (value.CompareTo(str) == 0) {
                    valid = true;
                    break;
                }
            } 

            success = valid;
            if (!success && !quiet) { 
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid value found for property ").Append(PropertyName).Append(". Possible values are:\n");
                foreach (String str in PossibleValues) {
                    sb.Append(str).Append('\n');
                }
                Logger.Error(sb.ToString());
            }

            return success;
        }

        private bool controlPossibleFormats(String value, bool quiet) {
            bool success = true;
            bool valid = true;

            if (PossibleFormats == null || PossibleFormats.Count == 0) {
                return success;
            }

            foreach (String str in PossibleValues) {
//                 if (value.CompareTo(str) == 0) {
//                     valid = true;
//                 }
                if (valid) {
                    break;
                }
            }

            success = valid;
            if (!success && !quiet)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Invalid format found for property ").Append(PropertyName).Append(". Possible formats are:\n");
                foreach (String str in PossibleFormats) {
                    sb.Append(str).Append('\n');
                }
                Logger.Error(sb.ToString());
            }
            return success;
        }

    }
}
