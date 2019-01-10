using System;
using System.Collections.Generic;
using System.Text;

namespace KeySystems.ERP.ContasAPagar.Core.DomainModel
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}
