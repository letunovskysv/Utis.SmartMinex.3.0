using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Interfaces.Business
{
    public interface IDataValidator<T> where T : CatalogBase
    {
        IContractResult Validate(T division, string clientId = null);
    }

}
