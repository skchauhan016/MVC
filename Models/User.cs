using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandeeptest.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Remote("CheckEmailInDataBase", "User", AdditionalFields = "previousemail", HttpMethod = "POST", ErrorMessage = "Email is already exist")]
        public string Email { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        [DisplayName("City")]
        [Required]
        public string CityName { get; set; }
        [DisplayName("Country")]
        [Required]
        public string CountryName { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }

    }
}