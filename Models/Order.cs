using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace SpreadSheetReader.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public long Code { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }

    }
}
