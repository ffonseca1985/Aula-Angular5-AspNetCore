namespace KeySystems.ERP.Core.InfraEstruture.Constants
{
    using System.Configuration;

    public static class QueryStringConstant
    {
        public static string ConnectionErpKeySystems {
            get {
              return  ConfigurationManager
                    .ConnectionStrings["keySystemsErp"]
                    .ConnectionString;
            }
        }
    }
}
