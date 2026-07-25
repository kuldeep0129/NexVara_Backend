using Nexvara_ERP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Application.DTOs.Common
{
    public class RequestStatusResponse : PaginationDto
    {
        public EntityStatusType status { get; set; } = EntityStatusType.All;
    }
}
