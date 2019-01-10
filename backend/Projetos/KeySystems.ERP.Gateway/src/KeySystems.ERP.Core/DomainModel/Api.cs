using System;

namespace KeySystems.ERP.Core.DomainModel
{
    //Para satisfazer um modelo de api
    //iremos sempre ter o seguinte formato:
    //Domain:porta/{modulo}/{action}/{tenantId}/{parametros}
    public class Api
    {
        private Api()
        {

        }

        public Api(int idTenant, int idModulo, 
            string endpoint, int idMetodo)
        {
            this.IdTenant = idTenant;
            this.IdModulo = idModulo;
            this.IdMetodo = idMetodo;
            this.Endpoint = endpoint;
        }

        public int Id { get; set; }
        public int IdTenant { get; private set; }
        public int IdModulo { get; private set; }
        public int IdMetodo { get; private set; }
        public string Endpoint { get; private set; }

        public EMetodo GetMethod()
        {
            return (EMetodo)Enum.Parse(typeof(EMetodo), this.IdMetodo.ToString());
        }
    }
}
