using ApiProjeKampi.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProjeKampi.WebApi.Entites;

namespace ApiProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        public CategoriesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id); //id den gelen değeri bul
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori silindi");
        }

       [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            return Ok(category);
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            if (category == null || category.CategoryId < 0 )
            {
                return BadRequest("Geçersiz kategori verisi");
            }
            
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori güncellendi");
        }
        
    }
}
