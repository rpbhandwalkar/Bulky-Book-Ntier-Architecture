using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models.ViewModel
{
    public class ProductVM
    {
        public Product product { get; set; }

        //To create dropdown select list
        [ValidateNever]
        //create dropdown list
        public IEnumerable<SelectListItem> categoryList { get; set; }
        [ValidateNever]
        //To create dropdown select list
        public IEnumerable<SelectListItem> coverTypeList { get; set; }
    }
}
