using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Core.Entities
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            Receipts = new HashSet<Receipt>();
        }

        public string Name { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
