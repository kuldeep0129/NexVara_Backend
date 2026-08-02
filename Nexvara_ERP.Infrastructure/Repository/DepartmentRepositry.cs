using Microsoft.EntityFrameworkCore;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Core;
using Nexvara_ERP.Domain.Data;
using Nexvara_ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Repository
{
    public class DepartmentRepositry :IDepartmentRepositry
    {
        private readonly AppDbContext _context;
        public DepartmentRepositry(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Department?> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Departments.FirstOrDefaultAsync(x=>x.DepartmentId == departmentId && x.IsActive==true);
        }
        public async Task<PaginationResponseDto<Department>> GetListDepartmentAsync(RequestStatusResponse response)
        {
            IQueryable<Department> query = _context.Departments.AsNoTracking();
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
            List<Department> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<Department>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }
        public async Task SaveAsync(Department department)
        {
             await _context.Departments.AddAsync(department);
        }
        public async Task<Department?> UpdateAsync(int departmentId)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
        }
    }
}
