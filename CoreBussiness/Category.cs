using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBussiness
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        // ef core的导航属性
        public List<Product> Products { get; set; }
    }
}
