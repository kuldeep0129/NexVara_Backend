using Microsoft.EntityFrameworkCore;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Core;
using Nexvara_ERP.Domain.Data;
using Nexvara_ERP.Domain.Entity.Master;

namespace Nexvara_ERP.Infrastructure.Repository
{
    public class LeadSourcesRepository : ILeadSourcesRepository
    {
        private readonly AppDbContext _context;
        public LeadSourcesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LeadSources?> GetByIdLeadSourcesAsync(int id)
        {
            return await _context.LeadSources.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        public async Task<PaginationResponseDto<LeadSources>> GetListLeadSourcesAsync(RequestStatusResponse response)
        {
            IQueryable<LeadSources> query = _context.LeadSources.AsNoTracking();

            switch (response.status)
            {
                case EntityStatusType.Active:
                    query = query.Where(x => x.IsActive);
                    break;

                case EntityStatusType.InActive:
                    query = query.Where(x => !x.IsActive);
                    break;

                case EntityStatusType.All:
                default:
                    break;
            }
            int totalCount = await query.CountAsync();
            List<LeadSources> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<LeadSources>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }

        public async Task SaveAsync(LeadSources source)
        {
            await _context.LeadSources.AddAsync(source);
        }

        public async Task<LeadSources?> UpdateAsync(int id)
        {
            return await _context.LeadSources.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
