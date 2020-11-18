using System;
using System.Collections.Generic;

namespace Recibos.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Receipts = new HashSet<Receipt>();
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
