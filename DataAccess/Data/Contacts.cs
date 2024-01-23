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
    public class Contacts
    {
        [Key]
        public int id { get; set; }
        public string? email { get; set; }
        public string? lastname { get; set; }
        public string? firstname { get; set; }
        public string? spiritual_name { get; set; }
        public string? country_of_residence { get; set; }
        public string? country_calculated { get; set; }
        public string? zip { get; set; }
        public string? profession { get; set; }
        public string? city { get; set; }
        public string? hs_language { get; set; }
        public string? do_you_speak_english_ { get; set; }
        public string? comments { get; set; }
        public string? gender__ { get; set; }
        public string? date_of_birth_date_picker { get; set; }
        public string? mobilephone { get; set; }
        public string? phone { get; set; }
        public string? verified_art_teacher { get; set; }
        public string? verified_knowledge_teachers { get; set; }
        public string? verified_music { get; set; }
        public string? verified_rituals_teacher { get; set; }
        public string? verified_yoga_and_meditation_teachers { get; set; }
        public string? verified_aky_teacher { get; set; }

        public double? TotalFees { get; set; }

        public double? TotalIncome { get; set; }

        public double? SharingBMInt { get; set; }

        public double? SharingCountry { get; set; }

        public double? SharingTeachers { get; set; }


        public int? TotalStudents { get; set; }

        public int? TotalCourses { get; set; }
        //public virtual ICollection<ReceiptImage> FeesReaceipt { get; set; }

    }
}
