using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CountriesDTO
    {
        public int id { get; set; }


        public string? country_calculated { get; set; }

        public string? city { get; set; }

        public string? CreatedAt { get; set; }

       
        public double? TotalFees { get; set; } = 0;

        public double? TotalIncome { get; set; } = 0;

        public double? SharingBMInt { get; set; } = 0;

        public double? SharingCountry { get; set; } = 0;

        public double? SharingTeachers { get; set; } = 0;

        public int? TotalStudents { get; set; } = 0;

        public int? TotalCourses { get; set; } = 0;
        public int? TotalTeachers { get; set; } 

    }
}
