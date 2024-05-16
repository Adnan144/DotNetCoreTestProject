using AngularWithAPI.Models.Domain;

namespace AngularWithAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}
