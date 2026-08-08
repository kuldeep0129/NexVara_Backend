using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Core;
using Nexvara_ERP.Domain.Data;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private readonly AppDbContext _context;
        public MasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Address?> GetByIdAddressAsync(int id)
        {
            return await _context.Address.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<Citys?> GetByIdCityAsync(int id)
        {
            return await _context.Citys.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<Country?> GetByIdCountryAsync(int id)
        {
            return await _context.Country.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<CustomerType?> GetByIdCustomerTypeAsync(int id)
        {
            return await _context.CustomerType.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<IndustryType?> GetByIdIndustryTypeAsync(int id)
        {
            return await _context.IndustryType.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<State?> GetByIdStateAsync(int id)
        {
            return await _context.State.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<PaginationResponseDto<Address>> GetListAddressAsync(RequestStatusResponse response)
        {

            IQueryable<Address> query = _context.Address.AsNoTracking();

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
            List<Address> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<Address>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }
        public async Task<PaginationResponseDto<Citys>> GetListCityAsync(RequestStatusResponse response)
        {


            IQueryable<Citys> query = _context.Citys.Include(x=> x.State).AsNoTracking();

            //Citys res;
            if(response.Id > 0)
            {
                query = query.Where(x=> x.StateId == response.Id);
            }

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
            List<Citys> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<Citys>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }

        public async Task<PaginationResponseDto<Country>> GetListCountryAsync(RequestStatusResponse response)
        {

            IQueryable<Country> query = _context.Country.AsNoTracking();

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
            List<Country> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<Country>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }

        public async Task<PaginationResponseDto<CustomerType>> GetListCustomerTypeAsync(RequestStatusResponse response)
        {

            IQueryable<CustomerType> query = _context.CustomerType.AsNoTracking();

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
            List<CustomerType> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<CustomerType>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }

        public async Task<PaginationResponseDto<IndustryType>> GetListIndustryTypeAsync(RequestStatusResponse response)
        {
            IQueryable<IndustryType> query = _context.IndustryType.AsNoTracking();

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
            List<IndustryType> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<IndustryType>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }

        public async Task<PaginationResponseDto<State>> GetListStateAsync(RequestStatusResponse response)
        {

            IQueryable<State> query = _context.State.Include(x=>x.Country).AsNoTracking();

            if (response.Id > 0)
            {
                query = query.Where(x => x.CountryId == response.Id);
            }
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
            List<State> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<State>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }

        public async Task SaveAddressAsync(Address address)
        {
            await _context.Address.AddAsync(address);
        }

        public async Task SaveCityAsync(Citys city)
        {
            await _context.Citys.AddAsync(city);
        }

        public async Task SaveCountryAsync(Country country)
        {
            await _context.Country.AddAsync(country);
        }

        public async Task SaveCustomerTypeAsync(CustomerType type)
        {
            await _context.CustomerType.AddAsync(type);
        }

        public async Task SaveIndustryTypeAsync(IndustryType type)
        {
            await _context.IndustryType.AddAsync(type);
        }

        public async Task SaveStateAsync(State state)
        {
            await _context.State.AddAsync(state);
        }

        public async Task<Address?> UpdateAddressAsync(int id)
        {
            return await _context.Address.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Citys?> UpdateCityAsync(int id)
        {
            return await _context.Citys.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Country?> UpdateCountryAsync(int id)
        {
            return await _context.Country.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CustomerType?> UpdateCustomerTypeAsync(int id)
        {
            return await _context.CustomerType.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IndustryType?> UpdateIndustryTypeAsync(int id)
        {

            return await _context.IndustryType.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<State?> UpdateStateAsync(int id)
        {
            return await _context.State.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
