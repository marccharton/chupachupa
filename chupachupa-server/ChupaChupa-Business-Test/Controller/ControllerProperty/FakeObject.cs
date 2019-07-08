using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Test.Controller.ControllerProperty
{
    class FakeObject
    {
        public Int64 intValue { get; set; }
        public string stringValue { get; set; }

        public FakeObject() {
            intValue = 0;
            stringValue = null;
        }

    }
}
