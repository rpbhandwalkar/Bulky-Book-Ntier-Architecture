using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("List Price")]
        public double ListPrice { get; set; }
        [Range(1, 1000)]

        [DisplayName("Price for 1 - 50")]
        public double Price { get; set; }
        [Range(1, 1000)]

        [DisplayName("Price for 50 - 100")]
        public double Price50 { get; set; }
        [Range(1, 1000)]

        [DisplayName("Price for 100+")]
        public double Price100 { get; set; }
        [ValidateNever]

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }

        //for setting foregin key relation with table category
        [Required]

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        //Only requried if the CategoryId is not appended with ID for example CategoryType 
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        //for setting foregin key relation with table covertype
        [Required]
        [DisplayName("Cover Type")]
        public int CoverTypeId { get; set; }
        [ValidateNever]
        public CoverType CoverType { get; set; }


    }
}
