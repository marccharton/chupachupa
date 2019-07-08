using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chupachupa_WebApp.PrivateService;

namespace Chupachupa_WebApp.Models
{
    public class ServeurSingleton
    {
        private static ServiceContractClient _serveur = null;
        public static List<Category> categoryList = new List<Category>() { };
        public static Category category = new Category();
        public static RssChannel flux = new RssChannel();

        private ServeurSingleton() {}

        public static ServiceContractClient GetInstance()
        {
            if (_serveur == null)
                _serveur = new ServiceContractClient();
            return _serveur;
        }

        public static ServiceContractClient Reset()
        {
            _serveur = new ServiceContractClient();
            return _serveur;
        }
    }
}