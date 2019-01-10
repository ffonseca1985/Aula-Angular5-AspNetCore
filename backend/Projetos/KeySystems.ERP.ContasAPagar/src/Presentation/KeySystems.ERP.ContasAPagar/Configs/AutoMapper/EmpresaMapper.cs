using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.Empresa;
using KeySystems.ERP.ContasAPagar.Models;

namespace KeySystems.ERP.ContasAPagar.Configs.AutoMapper
{
    public class EmpresaMapper : Profile
    {
        public EmpresaMapper()
        {
            CreateMap<EmpresaModel, Empresa>();
            CreateMap<Empresa, EmpresaModel>();
        }
    }
}
