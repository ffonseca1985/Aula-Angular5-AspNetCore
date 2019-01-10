using System;

namespace KeySystems.ERP.ContaCorrente.Core.Application.Empresa.Dtos
{
    public class EmpresaResponse
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; } 
        public string RazaoSocial { get; set; }
        public string NomeBusca { get; set; }
    }
}
