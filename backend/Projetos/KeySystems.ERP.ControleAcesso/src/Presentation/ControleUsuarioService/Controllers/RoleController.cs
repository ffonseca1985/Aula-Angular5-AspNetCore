using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security;
using KeySystems.ERP.ControleAcesso.Core.DomainModel;
using System.Threading.Tasks;

namespace KeySystems.ERP.ControleAcesso.ControleUsuarioService.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController 
        : ApiController
    {
        public CustomRoleManager CustomRoleManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Get<CustomRoleManager>();
            }
        }


        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest();

            var role = new Role(nome);
            var result = await CustomRoleManager.CreateAsync(role);

            if (result.Succeeded)
                return Ok();

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }

            return BadRequest(ModelState);
        }

        [Route("")]
        [HttpDelete]
        public async Task<IHttpActionResult> Remove(string nome)
        {
            var role = new Role(nome);
            var result = await CustomRoleManager.DeleteAsync(role);

            if (result.Succeeded)
                return Ok();

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }

            return BadRequest(ModelState);
        }
    }
}
