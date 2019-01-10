using KeySystems.ERP.ContasAPagar.Core.Application.ContasAPagar.TipoPgto;
using KeySystems.ERP.ContasAPagar.Core.Application.ContasAPagar.TipoTitulo;
using KeySystems.ERP.ContasAPagar.Core.Application.Empresa;
using KeySystems.ERP.ContasAPagar.Core.Application.Fornecedor;
using KeySystems.ERP.ContasAPagar.Core.Infraestructure.MysqlDapper.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace KeySystems.ERP.ContasAPagar.Core.Infraestructure.ServiceLocator
{
    public static class ContasAPagarServiceLocator
    {
        public static void Inicializar(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<EmpresaRepository>();
            serviceCollection.AddScoped<FornecedorRepository>();
            serviceCollection.AddScoped<EmpresaService>();
            serviceCollection.AddScoped<FornecedorService>();
            serviceCollection.AddScoped<TipoPgtoRepository>();
            serviceCollection.AddScoped<TipoTituloRepository>();
            serviceCollection.AddScoped<TipoTituloService>();
            serviceCollection.AddScoped<TipoPgtoService>();
        }
    }
}
