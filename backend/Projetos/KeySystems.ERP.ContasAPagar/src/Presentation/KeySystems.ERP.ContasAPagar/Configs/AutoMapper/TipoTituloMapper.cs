using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar;
using KeySystems.ERP.ContasAPagar.Models;

namespace KeySystems.ERP.ContasAPagar.Configs.AutoMapper
{
    public class TipoTituloMapper
        : Profile
    {
        public TipoTituloMapper()
        {
            CreateMap<TipoTituloModel, TipoTitulo>();
            CreateMap<TipoTitulo, TipoTituloModel>();
        }
    }
}
