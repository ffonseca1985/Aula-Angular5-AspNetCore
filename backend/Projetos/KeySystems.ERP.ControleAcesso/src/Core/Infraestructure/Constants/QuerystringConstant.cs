using System.Configuration;

namespace KeySystems.ERP.ControleAcesso.Core.Infraestructure.Constants
{
    public class QuerystringConstant
    {
        public static string KeySystems {
            get {
                return ConfigurationManager.ConnectionStrings["keySystemsErp"]
                    .ConnectionString;
            }
        }
    }
}
