using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Core.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
