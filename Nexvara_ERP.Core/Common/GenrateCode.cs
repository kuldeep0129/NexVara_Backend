using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexvara_ERP.Core.Common
{
    public class GenrateCode
    {
        public static string GenerateDepartmentCode(string departmentName, int lastSequence)
        {
            if (string.IsNullOrWhiteSpace(departmentName))
                throw new ArgumentException("Department name is required.");

            var words = departmentName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string prefix;
            if (words.Length == 1)
            {
                prefix = words[0].Length >= 2
                    ? words[0].Substring(0, 2)
                    : words[0];
            }
            else
            {
                prefix = string.Concat(words.Select(x => x[0]));
            }
            prefix = prefix.ToUpper();
            int nextSequence = lastSequence + 1;
            return $"{prefix}{nextSequence:D3}";
        }
    }
}
