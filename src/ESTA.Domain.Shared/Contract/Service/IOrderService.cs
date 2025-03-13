using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTA.Domain.Shared.Contract.Service
{
    public interface IOrderService
    {
        Task EnrichmentOrderAsync(Guid OrderId);
    }
}
