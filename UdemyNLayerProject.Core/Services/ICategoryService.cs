using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Core.Services
{
    public interface ICategoryService: IService<Category>
    {
        Task<Category> GetWithProductsById(int categoryId); 
    }
}
