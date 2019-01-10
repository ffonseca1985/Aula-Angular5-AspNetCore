
using System.Runtime.InteropServices;

namespace KeySystems.ERP.ContaCorrente.Core.DomainModel
{
    public abstract class IEntity<T>
    {
        public T Id { get; protected set; }

        public IEntity(T id)
        {
            this.Id = id;
        }
    }

    public abstract class IEntity<T, E>
    {
        public T Id { get; protected set; }
        public E Codigo { get; protected set; }

        public IEntity(T id, [Optional]E codigo)
        {
            this.Id = id;

            if (codigo == null)
                codigo = default(E);

            this.Codigo = codigo;
        }
    }

    public abstract class IEntity<A, T, E, F>
    {
        public A Id { get; protected set; }
        public T Grupo { get; protected set; }
        public E SubGrupo { get; protected set; }
        public F Conta { get; protected set; }

        public IEntity(A id,  T grupo, E subgrupo, F conta)
        {
            this.Id = id;
            this.Grupo = grupo;
            this.SubGrupo = subgrupo;
            this.Conta = conta;
        }

        public override string ToString()
        {
            return $"{this.Grupo}.{this.SubGrupo}.{this.Conta}";
        }
    }
}
