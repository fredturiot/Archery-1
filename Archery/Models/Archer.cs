﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Archer:User
    {
        [Required]
        [Display(Name = "Numéro de Licence")]
        public string LicenseNumber { get; set; }


       //[Range(9, 80,ErrorMessage ="Le Tireur doit avoir entre {1} et {2} ans")]
       // public double Age
       // {
       //     get
       //     {
       //         double age = 0;
       //         age = DateTime.Now.Subtract(BirthDate).TotalDays / 365;
       //         return age;
       //     }
       // }
        
    }
}