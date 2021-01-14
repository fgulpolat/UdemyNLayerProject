using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.API.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
       public ICollection<ProductDto> Products { get; set; }
    }
}
