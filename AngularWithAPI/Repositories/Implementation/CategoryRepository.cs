using AngularWithAPI.Data;
using AngularWithAPI.Models.Domain;
using AngularWithAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AngularWithAPI.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext _dbcontext)
        {
            dbContext = _dbcontext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }
    }
}
