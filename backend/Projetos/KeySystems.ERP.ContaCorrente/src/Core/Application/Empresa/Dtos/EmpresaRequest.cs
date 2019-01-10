using System;

namespace KeySystems.ERP.ContaCorrente.Core.Application.Empresa.Dtos
{
    public class EmpresaRequest
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeBusca { get; set; }
    }
}
