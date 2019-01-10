using KeySystems.ERP.ContaCorrente.Core.Application.Empresa.Dtos;

namespace KeySystems.ERP.ContaCorrente.Core.Application.Empresa
{
    using AutoMapper;
    using DomainModel.Empresa;
    using KeySystems.ERP.ContaCorrente.Core.Infrastructure.MysqlDataBase.Repositories;
    using System;

    public class EmpresaService
    {
        EmpresaRepository _empresaRepository;
        IMapper _mapper;

        public EmpresaService(EmpresaRepository empresaRepository,
            IMapper mapper)
        {
            this._empresaRepository = empresaRepository;
            this._mapper = mapper;
        }

        public void Add(EmpresaRequest request)
        {
            var identificador = new IdentificadorEmpresa(Guid.NewGuid());
            var empresa = new Empresa(identificador, request.RazaoSocial, request.NomeBusca);

            //inserir empresa no banco de dados
            _empresaRepository.Add(empresa);
        }

        public EmpresaResponse Get(Guid id)
        {
            var empresa = _empresaRepository.Get(id);
            var response = _mapper.Map<EmpresaResponse>(empresa);

            return response;
        }
    }
}
