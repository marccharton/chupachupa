using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class UserController : AbstractController
    {
        public UserController() : base() {
            _properties = new List<ControllerProperty.IPropertyController>();

            _properties.Add(new StringPropertyController("LoginMail", 1, 255, false));
            _properties.Add(new StringPropertyController("Password", 1, 255, false));
            _properties.Add(new StringPropertyController("OAuthToken", 0, 255, true));
        }
    }
}
