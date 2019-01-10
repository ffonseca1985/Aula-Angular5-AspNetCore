using KeySystems.ERP.ControleAcesso.ControleUsuarioService.Models;
using KeySystems.ERP.ControleAcesso.Core.Infraestructure.Security;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using KeySystems.ERP.ControleAcesso.Core.DomainModel;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace KeySystems.ERP.ControleAcesso.ControleUsuarioService.Controllers
{
    [RoutePrefix("api/private/keysystems/erp/ControleDeAcesso/usuario")]
    public class UsuarioController
        : ApiController
    {
        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(LoginViewModel login)
        {
            if (login == null)
                return BadRequest();

            var userManager = HttpContext.Current.GetOwinContext()
               .GetUserManager<CustomUserManager>();

            var user = await userManager.FindAsync(login.UserName, login.Password);

            if (user == null)
                return NotFound();

            return Ok(user);
        }


        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(CreateUsuarioViewModel vm)
        {
            if (vm == null)
                return BadRequest("Usuário não informado");

            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<CustomUserManager>();

            Usuario usuario = new Usuario(vm.UserName)
            {
                Cpf = vm.Cpf,
                DataNascimento = vm.DataNascimento,
                Ativo = vm.Ativo,
                Email = vm.Email,
                Nome = vm.Nome,
                SobreNome = vm.SobreNome,
                Telefone = vm.Telefone,
                IdTenant = vm.IdTenant
            };


            var result = await userManager.CreateAsync(usuario, vm.Password);

            try
            {
                if (result.Succeeded)
                {

                    var user = await userManager.FindByNameAsync(vm.UserName);
                    var link = Url.Link("GetById", new { id = user.Id });

                    var model = FastMapper.TypeAdapter.Adapt<UsuarioViewModel>(user);

                    return Created(link, model);
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }

                return BadRequest(ModelState);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> IsInRole(int userId, string role)
        {
            var userManager = HttpContext.Current.GetOwinContext()
               .GetUserManager<CustomUserManager>();

            var isInRole = await userManager.IsInRoleAsync(userId, role);

            return Ok(isInRole);
        }

        [HttpGet]
        public async Task<IHttpActionResult> AddToRolesAsync(int userId, string[] roles)
        {
            var userManager = HttpContext.Current.GetOwinContext()
               .GetUserManager<CustomUserManager>();

            var isInRole = await userManager.AddToRolesAsync(userId, roles);

            return Ok(isInRole);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddToRole(int userId, string role)
        {
            var userManager = HttpContext.Current.GetOwinContext()
               .GetUserManager<CustomUserManager>();

            var isInRole = await userManager.AddToRoleAsync(userId, role);

            return Ok(isInRole);
        }

        [HttpPost]
        public async Task<IHttpActionResult> RemoveRole(int userId, string role)
        {
            var userManager = HttpContext.Current.GetOwinContext()
               .GetUserManager<CustomUserManager>();

            var isInRole = await userManager.RemoveFromRoleAsync(userId, role);

            return Ok(isInRole);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var userManager = HttpContext.Current.GetOwinContext()
                        .GetUserManager<CustomUserManager>();

                var users = userManager.Users.ToList();

                var vm = FastMapper.TypeAdapter.Adapt<List<UsuarioViewModel>>(users);

                return Ok(vm);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var userManager = HttpContext.Current.GetOwinContext()
                .GetUserManager<CustomUserManager>();

            var user = await userManager.FindByIdAsync(id);

            var vm = FastMapper.TypeAdapter.Adapt<UsuarioViewModel>(user);

            return Ok(vm);
        }

        [Route("")]
        [HttpPatch]
        public async Task<IHttpActionResult> Update(CreateUsuarioViewModel vm)
        {
            if (vm == null)
                return BadRequest("Usuário não informado");

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<CustomUserManager>();

            var usuario = await userManager.FindByIdAsync(vm.Id);

            if (usuario == null)
                return NotFound();

            var result = await userManager.UpdateAsync(usuario);

            if (result.Succeeded)
                return Ok();

            return BadRequest(ModelState);
        }
    }
}
