using Nexvara_ERP.Application.Interface.Common;
using Nexvara_ERP.Domain.Data;

namespace Nexvara_ERP.Infrastructure.common
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;

        public UnitofWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
