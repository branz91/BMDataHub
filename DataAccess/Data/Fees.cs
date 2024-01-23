using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Data
{
    public class Fees
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; } // datetime2

        public double? Price { get; set; }

        public bool? Paid { get; set; }

        public bool? Validate { get; set; } 

        public string? ProductTitle { get; set; } // nvarchar(100)

        public long ProductId { get; set; }

     
        public int? IdTeacher { get; set; }

       public virtual ICollection<ReceiptImage> FeesReceipt { get; set; }

    }
}
