using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await getCategoryQueryHandler.Handle();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await createCategoryCommandHandler.Handle(command);
            return Ok("Kategori Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandler.Handle(command);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute]int id)
        {
            var value = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
    }
}
