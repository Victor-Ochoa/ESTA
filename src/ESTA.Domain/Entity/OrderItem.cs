using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTA.Domain.Entity;

public class OrderItem: Base.Entity
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice => Quantity * Price;
}
