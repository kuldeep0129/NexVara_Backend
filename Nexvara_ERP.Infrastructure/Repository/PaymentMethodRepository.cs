using Microsoft.EntityFrameworkCore;
using Nexvara_ERP.Application.DTOs.Common;
using Nexvara_ERP.Application.Interface.IRepository;
using Nexvara_ERP.Core;
using Nexvara_ERP.Domain.Data;
using Nexvara_ERP.Domain.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Infrastructure.Repository
{
    public class PaymentMethodRepository : IPaymentMethod
    {
        private readonly AppDbContext _context;

        public PaymentMethodRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task SavePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();
        }
        public async Task<PaymentMethod?> GetByIdPaymentMethodAsync(int id)
        {
            return await _context.PaymentMethods.FirstOrDefaultAsync(x=> x.Id == id);
        }
        public async Task<PaymentMethod?> UpdatePaymentMethodAsync(int id)
        {
            return await _context.PaymentMethods.FirstOrDefaultAsync(x=> x.Id == id);
        }
        public async Task<PaginationResponseDto<PaymentMethod>> GetListPaymentMethodAsync(RequestStatusResponse response)
        {
            IQueryable<PaymentMethod> query = _context.PaymentMethods.AsNoTracking();

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
            List<PaymentMethod> data = await query.OrderByDescending(x => x.CreateAt).Skip((response.PageNumber - 1) * response.PageSize)
                .Take(response.PageSize).ToListAsync();
            return new PaginationResponseDto<PaymentMethod>
            {
                Data = data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalRecords = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)response.PageSize)
            };
        }
    }
}
