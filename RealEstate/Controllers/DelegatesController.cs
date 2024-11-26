using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.DTO;
using RealEstate.Models;
using Delegate = RealEstate.Models.Delegate;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegatesController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public DelegatesController(RealEstateContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Delegate>> CreateDelegate([FromBody] DelegateRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var newDelegate = new Delegate
            {
                name = request.name,
                code = request.code,
                phoneNumber = request.phoneNumber,
                address = request.address,
                commissionPercent = request.commissionPercent
            };

            _context.Delegates.Add(newDelegate);
            await _context.SaveChangesAsync();

            return Ok(newDelegate);

        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Delegate>>> GetAllDelegates()
        {
            var delegates = await _context.Delegates.ToListAsync();
            return Ok(delegates);
        }


        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<Delegate>>> SearchDelegates([FromBody] SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrEmpty(criteria.Query) || string.IsNullOrEmpty(criteria.SearchBy))
            {
                return BadRequest("Query and SearchBy parameters are required.");
            }

            IQueryable<Delegate> queryable = _context.Delegates;

            string query = criteria.Query.Trim().ToLower();
            string searchBy = criteria.SearchBy.Trim().ToLower();

            queryable = searchBy switch
            {
                "name" => queryable.Where(d => d.name.ToLower().Contains(query)),
                "percent" => queryable.Where(d => d.commissionPercent.ToLower().Contains(query)),
                "code" => queryable.Where(d => d.code.ToLower().Contains(query)),
                "address" => queryable.Where(d => d.address.ToLower().Contains(query)),
                "phonenumber" =>
                    queryable.Where(d => d.phoneNumber.ToString().Contains(query)),
                _ => queryable
            };

            var results = await queryable.ToListAsync();

            return Ok(results);
        }

    }
}
