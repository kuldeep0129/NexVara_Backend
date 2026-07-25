using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.Interface.Common
{
    public interface IUnitofWork
    {
        Task SaveChangesAsync();
    }
}
