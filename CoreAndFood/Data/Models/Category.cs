using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
    public class Category
    {
        [Key]
        public int CatgoryID { get; set; }
        [Required(ErrorMessage ="category Name Not Empty ")]
        public string CatgoryName { get; set; }
        public string CatgoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
