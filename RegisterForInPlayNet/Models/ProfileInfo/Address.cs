using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterForInPlayNet.Models.ProfileInfo
{
    public class Address
    {
        [Required]
        public string country { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string addressOne { get; set; }

        [Required]
        public string addressTwo { get; set; }

        [Required]
        public string postalCode { get; set; }
    }
}