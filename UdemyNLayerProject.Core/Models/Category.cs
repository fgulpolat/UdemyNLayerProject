using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayerProject.Core.Models
{
   public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
