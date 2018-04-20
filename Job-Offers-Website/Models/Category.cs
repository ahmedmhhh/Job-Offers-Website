using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Offers_Website.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Type of Job")]
        public string categoryName { get; set; }
        [Required]
        [Display(Name ="Category Description")]
        public string categoryDescription { get; set; }
        public virtual ICollection<Job> Job { get; set; }
    }
}