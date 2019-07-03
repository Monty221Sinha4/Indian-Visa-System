using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Indian_Visa_System.Models
{
    public class Applicant
    {
        public int AppID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public int VisaID { get; set; }
        public int StatusID { get; set; }
    }
}