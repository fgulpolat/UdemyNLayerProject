using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private  AppDbContext appDbContext { get => _dbContext as AppDbContext; }

        

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
           // appDbContext =  dbContext;
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await appDbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
