using Microsoft.EntityFrameworkCore;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.DTOs.Sales;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Core;
using Nexvara_ERP.Domain.Data;
using Nexvara_ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Nexvara_ERP.Infrastructure.Repository
{
    public class companiesRepositry : ICompaniesRepositry
    {
        private readonly AppDbContext _context;
        public companiesRepositry(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Company?> GetByCompanyIdAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(x=>x.Id == id & x.IsActive==true);
        }
        public async Task<PaginationResponseDto<Company>> GetListCompaniesAsync(RequestStatusResponse response)
        {
            IQueryable<Company> query = _context.Companies.AsNoTracking();
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
            List<Company> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<Company>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        
        }
        public async Task SaveAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<Company?> UpdateAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
