using ChupaChupa.Business.Controller.ControllerProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChupaChupa.Business.Controller
{
    public class RssChannelController : AbstractController
    {
        public RssChannelController() : base() {
            _properties = new List<IPropertyController>();

            _properties.Add(new StringPropertyController("RssLink", 1, 512, false));

            _properties.Add(new StringPropertyController("Title", 1, 128, false));
            _properties.Add(new StringPropertyController("Link", 1, 512, false));
            _properties.Add(new StringPropertyController("Description", 1, 512, false));

            _properties.Add(new StringPropertyController("Language", 0, 32, true));
            _properties.Add(new StringPropertyController("Copyright", 0, 64, true));
            _properties.Add(new StringPropertyController("ManagingEditor", 0, 64, true));
            _properties.Add(new StringPropertyController("WebMaster", 0, 64, true));            
            //_properties.Add(new StringPropertyController("PubDate", 0, 128, true));
            //_properties.Add(new StringPropertyController("LastBuilDate", 0, 128, true));
            _properties.Add(new StringPropertyController("Generator", 0, 64, true));
            _properties.Add(new StringPropertyController("Docs", 0, 128, true));
            _properties.Add(new IntPropertyController("Ttl", 0, Int64.MaxValue, true));
            _properties.Add(new StringPropertyController("Rating", 0, 32, true));
            
            _properties.Add(new ObjectPropertyController("Image", true, new ImageController()));
            _properties.Add(new ObjectPropertyController("Cloud", true, new CloudController()));
            _properties.Add(new ListPropertyController("RssCategory", true, new RssCategoryController()));
            _properties.Add(new ListPropertyController("SkipDays", true, new SkipDaysController()));
            _properties.Add(new ListPropertyController("SkipHours", true, new SkipHoursController()));
            _properties.Add(new ListPropertyController("RssItems", true, new RssItemController()));
            
        }
    }
}
