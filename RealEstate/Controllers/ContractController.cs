using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.DTO;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public ContractController(RealEstateContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Contract>> CreateContract([FromBody] ContractRequest dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var newContract = new Contract
            {
                unit = dto.unit,
                client = dto.client,
                date = dto.date,
                rentalValue = dto.rentalValue,
               deposit = dto.deposit,
               insuranceValue = dto.insuranceValue,
               rentalStartDate = dto.rentalStartDate,
               rentalEndDate = dto.rentalEndDate
            };

            _context.Contracts.Add(newContract);
            await _context.SaveChangesAsync();

            return Ok(newContract);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetAllContracts()
        {
            var contracts = await _context.Contracts.ToListAsync();
            return Ok(contracts);
        }

        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<Contract>>> SearchContracts([FromBody] SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrEmpty(criteria.Query) || string.IsNullOrEmpty(criteria.SearchBy))
            {
                return BadRequest("Query and SearchBy parameters are required.");
            }

            IQueryable<Contract> queryable = _context.Contracts;

            string query = criteria.Query.Trim().ToLower();
            string searchBy = criteria.SearchBy.Trim().ToLower();

            queryable = searchBy switch
            {
                "unit" => queryable.Where(c => c.unit.ToLower().Contains(query)),
                "client" => queryable.Where(c => c.client.ToLower().Contains(query)),
                "rentalvalue" => queryable.Where(u => u.rentalValue.ToString().Contains(query)),
                "deposit" => queryable.Where(u => u.deposit.ToString().Contains(query)),
                "insurancevalue" => queryable.Where(u => u.insuranceValue.ToString().Contains(query)),
                "rentalstartdate" => DateTime.TryParse(query, out var rentalStartDate) ? queryable.Where(c => c.rentalStartDate.Date == rentalStartDate.Date) : queryable,
                "rentalenddate" => DateTime.TryParse(query, out var rentalEndDate) ? queryable.Where(c => c.rentalEndDate.Date == rentalEndDate.Date) : queryable,
                "date" => DateTime.TryParse(query, out var date) ? queryable.Where(c => c.date.Date == date.Date) : queryable,
                _ => queryable
            };

            var results = await queryable.ToListAsync();
            return Ok(results);
        }



    }
}
