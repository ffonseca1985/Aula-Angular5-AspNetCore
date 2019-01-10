using KeySystems.ERP.ControleAcesso.Core.DomainModel;
using Microsoft.AspNet.Identity;

namespace KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security
{
    public class CustomRoleManager
        : RoleManager<Role, int>
    {
        public CustomRoleManager() 
            : base(new CustomRoleStore())
        {
        }
    }
}
