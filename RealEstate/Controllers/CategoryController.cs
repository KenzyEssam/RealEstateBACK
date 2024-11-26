using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public CategoryController(RealEstateContext context)
        {
            _context = context;
        }

        // Create a new category
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequest categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category
            {
                InvestmentType = categoryRequest.InvestmentType,
                CategoryName = categoryRequest.CategoryName,
                CategoryCode = categoryRequest.CategoryCode
            };

            _context.Categorys.Add(category);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Category created successfully", category });
        }

        // Get all categories
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _context.Categorys.ToListAsync();
            return Ok(categories);
        }

        // Search categories by name or code
        [HttpGet]
    [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<Category>>> SearchCategories([FromBody] SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrEmpty(criteria.Query) || string.IsNullOrEmpty(criteria.SearchBy))
            {
                return BadRequest("Query and SearchBy parameters are required.");
            }

            IQueryable<Category> queryable = _context.Categorys;

            string query = criteria.Query.Trim().ToLower();
            string searchBy = criteria.SearchBy.Trim().ToLower();

            queryable = searchBy switch
            {
                "name" => queryable.Where(c => c.CategoryName.ToLower().Contains(query)),
                "code" => queryable.Where(c => c.CategoryCode.ToLower().Contains(query)),
                "investmenttype" => queryable.Where(c => c.InvestmentType.ToLower().Contains(query)),
                _ => queryable
            };

            var results = await queryable.ToListAsync();

            return Ok(results);
        }
    }
}
