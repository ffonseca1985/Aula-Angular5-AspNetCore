using AutoMapper;
using KeySystems.ERP.ContaCorrente.Core.Application.ContaCorrente.Dtos;
using KeySystems.ERP.ContaCorrente.Core.Infrastructure.MysqlDataBase.Repositories;

namespace KeySystems.ERP.ContaCorrente.Core.Application.ContaCorrente
{
    using DomainModel.ContaCorrente;
    using KeySystems.ERP.ContaCorrente.Core.DomainModel.ContaCorrente.Identificadores;
    using System;

    public class ContaCorrenteService
    {
        ContaCorrenteRepository _contaCorrenteRepository;
        IMapper _mapper;

        public ContaCorrenteService(
            ContaCorrenteRepository contaCorrenteRepository,
            IMapper mapper)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _mapper = mapper;
        }

        public void Add(ContaCorrenteRequest request)
        {
            var identificadorContaCorrente = 
                new IdentificadorContaCorrente(
                    request.IdContaCorrente, 
                    request.Grupo,
                    request.SubGrupo, 
                    request.Numero);

            var contaCorrente = 
                new ContaCorrente(identificadorContaCorrente, 
                request.CoditoEmpresa, request.DataCadastro);

            _contaCorrenteRepository.Add(contaCorrente);
        }

        public ContaCorrenteResponse Get(string identificador, int codigoEmpresa)
        {
            if (!ContaCorrente.IdentificadorValido(identificador))
                throw new ArgumentException();

            var segments = identificador.Split(',');

            int grupo = Convert.ToInt32(segments[0]);
            int subgrupo = Convert.ToInt32(segments[1]);
            int conta = Convert.ToInt32(segments[2]);

            var response = this.Get(grupo, subgrupo, conta, codigoEmpresa);
            return response;
        }

        public ContaCorrenteResponse Get(int grupo, int subGrupo, int numero, int codigoEmpresa)
        {
           ContaCorrente cc = _contaCorrenteRepository.Get(grupo, subGrupo, numero, codigoEmpresa);
           var response =  _mapper.Map<ContaCorrenteResponse>(cc);

           return response;
        }

        public void AddLancamento(Guid idContaCorrente, LancamentoRequest request)
        {
            if (_contaCorrenteRepository.GetById(idContaCorrente) == null)
                throw new ArgumentException("Conta corrente invalida");

            Lancamento lancamento = _mapper.Map<Lancamento>(request);
            _contaCorrenteRepository.AddLancamento(idContaCorrente, lancamento);
        }
    }
}
