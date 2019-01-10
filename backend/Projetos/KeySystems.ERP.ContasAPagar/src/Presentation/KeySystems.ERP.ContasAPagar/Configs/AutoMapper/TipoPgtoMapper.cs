using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.ContasAPagar;
using KeySystems.ERP.ContasAPagar.Models;

namespace KeySystems.ERP.ContasAPagar.Configs.AutoMapper
{
    public class TipoPgtoMapper
        : Profile
    {
        public TipoPgtoMapper()
        {
            CreateMap<TipoPgtoModel, TipoPgto>();
            CreateMap<TipoPgto, TipoPgtoModel>();
        }
    }
}
