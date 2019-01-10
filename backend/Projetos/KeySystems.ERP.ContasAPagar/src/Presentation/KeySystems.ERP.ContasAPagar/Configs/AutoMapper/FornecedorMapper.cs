using AutoMapper;
using KeySystems.ERP.ContasAPagar.Core.DomainModel.Fornecedor;
using KeySystems.ERP.ContasAPagar.Models;

namespace KeySystems.ERP.ContasAPagar.Configs.AutoMapper
{
    public class FornecedorMapper
         : Profile
    {
        public FornecedorMapper()
        {
            CreateMap<FornecedorModel, Fornecedor>();
            CreateMap<Fornecedor, FornecedorModel>();
        }
    }
}
