using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1,1000)]
        public double ListPrice { get; set; }
        [Range(1, 1000)]
        public double Price { get; set; }
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public string ImageUrl { get; set; }

        //for setting foregin key relation with table category
        [Required]
        public int CategoryId { get; set; }
        //Only requried if the CategoryId is not appended with ID for example CategoryType 
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        //for setting foregin key relation with table covertype
        [Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }


    }
}
