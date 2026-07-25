using Nexvara_ERP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Common
{
    public class PaginationResponseDto<T> : BaseResponse
    {
        public List<T> Data { get; set; } = new();

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public bool HasPrevious => PageNumber > 1;

        public bool HasNext => PageNumber < TotalPages;

    }
}
