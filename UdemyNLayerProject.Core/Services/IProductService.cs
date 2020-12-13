using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Core.Services
{
   public interface IProductService: IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync (int productId);

    }
}
