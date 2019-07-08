using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class RssItemController : AbstractController
    {
        public RssItemController() : base() {
            _properties = new List<ControllerProperty.IPropertyController>();

            _properties.Add(new StringPropertyController("Title", 1, 128, false));
            _properties.Add(new StringPropertyController("Link", 1, 512, false));
            _properties.Add(new StringPropertyController("Description", 1, 512, false));

            _properties.Add(new StringPropertyController("Author", 0, 64, true));
            _properties.Add(new StringPropertyController("Comments", 0, 256, true));
            _properties.Add(new StringPropertyController("Guid", 0, 512, true));
            //_properties.Add(new StringPropertyController("PubDate", 0, 128, true));

            _properties.Add(new ObjectPropertyController("RssChannel", false, null));
            _properties.Add(new ObjectPropertyController("Enclosure", true, new EnclosureController()));
            _properties.Add(new ObjectPropertyController("Source", true, new SourceController()));
            _properties.Add(new ListPropertyController("RssCategory", true, new RssCategoryController()));

        }

    }
}
