using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FeesDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; } // datetime2


        public double? Price { get; set; }

        public bool? Paid { get; set; }
        public bool? Validate { get; set; }  // nvarchar(1)
        public string? ProductTitle { get; set; } // nvarchar(100)

        public long ProductId { get; set; }
    
        public int? IdTeacher { get; set; }

        public virtual ICollection<ReceiptImageDTO> FeesReceipt { get; set; }

        public List<string> ImageUrls { get; set; }

    }
}
