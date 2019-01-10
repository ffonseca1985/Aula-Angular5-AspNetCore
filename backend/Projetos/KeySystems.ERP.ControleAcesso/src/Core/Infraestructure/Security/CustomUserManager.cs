using System.Linq;
using System.Threading.Tasks;
using KeySystems.ERP.ControleAcesso.Core.DomainModel;
using Microsoft.AspNet.Identity;

namespace KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security
{
    //Classe responsável por gerenciar o fluxo de criação do usuário
    public class CustomUserManager
        : UserManager<Usuario, int>
    {
        public CustomUserManager()
            : base(new CustomUserStore())
        {
            this.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireNonLetterOrDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };
            
        }

        public override IQueryable<Usuario> Users {

            get {

                var storeCustom = base.Store as CustomUserStore;
                return storeCustom.Get().Result;
            }
        }    

        //subject => titulo do email
        //body => conteúdo do email
        //userId => Id do usuario
        public override async Task SendEmailAsync(int userId, string subject, string body)
        {
            var usuario = await this.FindByIdAsync(userId);
            //Enviar um email com os dados do usuario
        }

        public override async Task SendSmsAsync(int userId, string message)
        {
            var usuario = await this.FindByIdAsync(userId);
            //Enviar SMS
        }
    }
}
