using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CoursesDTO
    {
        public int Id { get; set; }
        public string? CreatedAt { get; set; }
        public string? OrderName { get; set; }
        public string? ProductTitle { get; set; }
        public long ProductId { get; set; }
        public string? LineItemTitle { get; set; }
        public long? LineItemId { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; }
        public string? newcomer { get; set; }
        public string? country { get; set; }
        public string? sku { get; set; }
        public double? LineItemPrice { get; set; }
        public byte? Quantity { get; set; }
        public string? Refunded { get; set; }
        public string? SalesChannel { get; set; }
        public string? DateTimeAdded { get; set; }
        public string? Store { get; set; }
        public string? consent { get; set; }
        public double? TotalLineItemPriceSku { get; set; } = 0;

        public double? TotalLineItemPrice { get; set; } = 0;

        public int? TotalStudents { get; set; } = 0;
        public int? TotalStudentsSku { get; set; } = 0;

        public List<string>? SkuUnici { get; set; }

        public double? FeesAmount { get; set; }

        public int? IdTeacher { get; set; }

        public bool? Paid { get; set; }


    }
}
