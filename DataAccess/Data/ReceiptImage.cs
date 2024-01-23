using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Data
{
    public class ReceiptImage
    {
        [Key]
        public int IdKey { get; set; }
        public int? FeeId { get; set; }
	    public string? ReceiptImageUrl { get; set; }

        [ForeignKey("FeeId")]
        public virtual Fees ContactsFeesList { get; set; }
    }
}
