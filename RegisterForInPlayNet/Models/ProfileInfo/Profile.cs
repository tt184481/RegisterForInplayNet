using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterForInPlayNet.Models.ProfileInfo
{
    public class Profile
    {
        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string firstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string lastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public string dateOfBirth { get; set; }

        [Required]
        public string resident { get; set; }

        [Required]
        public string privateId { get; set; }

        [Required]
        public string registrationDate { get; set; }

        [Required]
        public string registrationIp { get; set; }

        [Required]
        public string language { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter mail in valid format")]
        public string mail { get; set; }

        [Required]
        public string number { get; set; }

        [Required]
        public Address address { get; set; }
       
    }
}