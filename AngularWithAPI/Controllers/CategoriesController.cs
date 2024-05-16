using AngularWithAPI.Data;
using AngularWithAPI.Models.Domain;
using AngularWithAPI.Models.DTO;
using AngularWithAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithAPI.Controllers
{
    // https://localhost:XXXX/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO requestDTO)
        {
            // Map DTO to Domain Model
            var Category = new Category
            {
                Name = requestDTO.Name,
                UrlHandle = requestDTO.UrlHandle,
            };

            await categoryRepository.CreateAsync(Category);

            var response = new CategoryDTO
            {
                Id = Category.Id,
                Name = requestDTO.Name,
                UrlHandle = requestDTO.UrlHandle,
            };
            return Ok(response);
        }
    }
}
