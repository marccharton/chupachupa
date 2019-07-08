using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace ChupaChupa.Service.Tool
{
    public class ToolBox
    {
        public static void controlStringNotEmptyWithFaultException(string toControl, string errorMessage) {
            if (string.IsNullOrEmpty(toControl) || string.IsNullOrWhiteSpace(toControl)) {
                throw new FaultException(errorMessage);
            }
        }

    }
}