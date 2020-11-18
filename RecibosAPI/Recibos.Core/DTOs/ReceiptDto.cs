using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Core.DTOs
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int SupplierId { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
    }
}
