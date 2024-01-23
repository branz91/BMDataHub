using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReceiptImageDTO
    {
        public int IdKey { get; set; }
        public int? FeeId { get; set; }

        public string? ReceiptImageUrl { get; set; }

    }
}
