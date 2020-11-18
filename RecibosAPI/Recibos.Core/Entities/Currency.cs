using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Core.Entities
{
    public class Currency : BaseEntity
    {
        public Currency()
        {
            Receipts = new HashSet<Receipt>();
        }

        public string Acronym { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
