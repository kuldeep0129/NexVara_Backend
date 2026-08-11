using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Core;
using Nexvara_ERP.Domain.Data;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly AppDbContext _context;
        public RolesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department?> GetByIdDepartmentAsync(int id)
        {
            return await _context.Department.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        public async Task<Designation?> GetByIdDesignationAsync(int id)
        {
            return await _context.Designation.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        public async Task<string> GetLastIdDepartmentAsync()
        {
            return await _context.Department.AsNoTracking().OrderByDescending(x => x.Id).Select(x => x.DepartmentCode).FirstOrDefaultAsync();

        }

        public async Task<string> GetLastIdDesignationAsync()
        {
            return await _context.Designation.AsNoTracking().OrderByDescending(x => x.Id).Select(x => x.DesignationCode).FirstOrDefaultAsync();

        }

        public async Task<PaginationResponseDto<Department>> GetListDepartmentAsync(RequestStatusResponse response)
        {

            IQueryable<Department> query = _context.Department.AsNoTracking();

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

        public async Task<PaginationResponseDto<Designation>> GetListDesignationAsync(RequestStatusResponse response)
        {

            IQueryable<Designation> query = _context.Designation.AsNoTracking();

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
            List<Designation> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<Designation>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }

        public async Task SaveDepartmentAsync(Department source)
        {
            await _context.Department.AddAsync(source);
        }

        public async Task SaveDesignationAsync(Designation source)
        {
            await _context.Designation.AddAsync(source);
        }

        public async Task<Department?> UpdateDepartmentAsync(int id)
        {
            return await _context.Department.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Designation?> UpdateDesignationAsync(int id)
        {
            return await _context.Designation.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
