using ESTA.Domain.Order.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTA.Domain.Order.Event;

public record OrderEnrichment : Shared.Base.Event
{
    public Guid Id { get; set; }
    public IList<OrderItem> OrderItems { get; set; } = [];
}
