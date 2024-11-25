using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums
{
    public enum SaleStatus
    {
        Unknown = 0,
        Pending = 1,
        Cancelled = 2,
        Finish = 3
    }
}
