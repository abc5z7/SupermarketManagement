using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBussiness
{
	public class Product
	{
		public int ProductId { get; set; }
		[Required]
		public int? CategoryId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int? Quantity { get; set; }
		[Required]
		public double? Price { get; set; }

		// ef core的导航属性
		public Category Category { get; set; }
    }
}
