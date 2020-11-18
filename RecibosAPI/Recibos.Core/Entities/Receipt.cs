using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Core.Entities
{
    public class Receipt : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int SupplierId { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
    }
}
