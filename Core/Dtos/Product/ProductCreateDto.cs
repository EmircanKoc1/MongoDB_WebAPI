using Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Product
{
    public class ProductCreateDto  : BaseDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
        public string Name { get; set; }
    }

}
