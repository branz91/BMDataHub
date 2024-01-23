using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Data
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? CreatedAt { get; set; } // datetime2

        [StringLength(50)]
        public string? OrderName { get; set; } // nvarchar(100)

        public string? ProductTitle { get; set; } // nvarchar(100)

        public long ProductId { get; set; }

        public string? LineItemTitle { get; set; } // nvarchar(50)

        public long? LineItemId { get; set; } // bigint

        public string? firstname { get; set; } // nvarchar(50)

        public string? lastname { get; set; } // nvarchar(50)

        [StringLength(50)]
        public string? email { get; set; } // nvarchar(50)

        [StringLength(50)]
        public string? newcomer { get; set; } // nvarchar(1)

        [StringLength(50)]
        public string? country { get; set; } // nvarchar(50)

        [StringLength(50)]
        public string? sku { get; set; } // nvarchar(50)

        public double? LineItemPrice { get; set; } // float

        public byte? Quantity { get; set; } // tinyint

        [StringLength(50)]
        public string? Refunded { get; set; } // nvarchar(1)

        [StringLength(50)]
        public string? SalesChannel { get; set; } // nvarchar(50)

        [StringLength(100)]
        public string? DateTimeAdded { get; set; } // datetime2

        [StringLength(50)]
        public string? Store { get; set; } // nvarchar(50)

        [StringLength(50)]
        public string? consent { get; set; } // nvarchar(50)

        public double? FeesAmount { get; set; }
       
        public int? IdTeacher { get; set; }

        public bool? Paid { get; set; }

    }
}
