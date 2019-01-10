using KeySystems.ERP.Core.InfraEstruture.Mysql.Repositories.Model;
using System.Collections.Generic;
using System.Linq;

namespace KeySystems.ERP.Core.InfraEstruture.Mysql.Repositories
{
    //Front end
    public class ClientRepository
    {
        private List<Client> Clients = new List<Client>()
        {
            new Client()
            {
                Active = true,
                AllowedOrigin = "*",
                ApplicationType = ApplicationType.NativeConfidential,
                Id = "ffonseca_is",
                Name = "keySystems",
                RefreshTokenLifeTime = 1,
                Secret = "123456"
            }
        };

        public Client Find(string clientId)
        {
            return this.Clients.FirstOrDefault(x => x.Id == clientId);
        }
    }
}
