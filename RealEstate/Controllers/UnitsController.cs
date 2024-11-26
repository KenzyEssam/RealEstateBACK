using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.DTO;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public UnitsController(RealEstateContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<InvestmentUnit>> CreateInvestmentUnit([FromBody] InvestmentUnitRequest dto)
        {
            if (dto == null)
            {
                return BadRequest("Unit is null.");
            }

            var newUnit = new InvestmentUnit
            {
                UnitCode = dto.UnitCode,
                UnitDescription = dto.UnitDescription,
                LowestCategory = dto.LowestCategory,
                UnitArea = dto.UnitArea,
                PricePerMeter = dto.PricePerMeter,
                TotalUnitValue = dto.TotalUnitValue,
                MaintenancePercentage = dto.MaintenancePercentage,
                MaintenanceValue = dto.MaintenanceValue
            };

            _context.InvestmentUnits.Add(newUnit);
            await _context.SaveChangesAsync();

            return Ok(newUnit);

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<InvestmentUnit>>> GetAllInvestmentUnits()
        {
            var units = await _context.InvestmentUnits.ToListAsync();
            return Ok(units);
        }

        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<InvestmentUnit>>> SearchInvestmentUnits([FromBody] SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrEmpty(criteria.Query) || string.IsNullOrEmpty(criteria.SearchBy))
            {
                return BadRequest("Query and SearchBy parameters are required.");
            }

            IQueryable<InvestmentUnit> queryable = _context.InvestmentUnits;

            string query = criteria.Query.Trim().ToLower();
            string searchBy = criteria.SearchBy.Trim().ToLower();

            queryable = searchBy switch
            {
                "unitcode" => queryable.Where(u => u.UnitCode.ToLower().Contains(query)),
                "unitdescription" => queryable.Where(u => u.UnitDescription.ToLower().Contains(query)),
                "lowestcategory" => queryable.Where(u => u.LowestCategory.ToLower().Contains(query)),
                "unitarea" => queryable.Where(u => u.UnitArea.ToString().Contains(query)),
                "pricepermeter" => queryable.Where(u => u.PricePerMeter.ToString().Contains(query)),
                "totalunitvalue" => queryable.Where(u => u.TotalUnitValue.ToString().Contains(query)),
                "maintenancepercentage" => queryable.Where(u => u.MaintenancePercentage.ToString().Contains(query)),
                "maintenancevalue" => queryable.Where(u => u.MaintenanceValue.ToString().Contains(query)),
                _ => queryable
            };

            var results = await queryable.ToListAsync();

            return Ok(results);
        }


        [HttpPost("CreateRental")]
        public async Task<ActionResult<RentalUnit>> CreateRentalUnit([FromBody] RentalUnitRequest dto)
        {
            if (dto == null)
            {
                return BadRequest("Rental unit is null.");
            }

            var newUnit = new RentalUnit
            {
                UnitCode = dto.UnitCode,
                UnitDescription = dto.UnitDescription,
                UnitAddress = dto.UnitAddress,
                LowestCategory = dto.LowestCategory,
                RentalValue = dto.RentalValue,
                UnitContents = dto.UnitContents,
                RenterName = dto.RenterName,
                RenterCode = dto.RenterCode,
                UnitStatus = dto.UnitStatus
            };

            _context.RentalUnits.Add(newUnit);
            await _context.SaveChangesAsync();

            return Ok(newUnit);
        }

        [HttpGet("GetAllRentals")]
        public async Task<ActionResult<IEnumerable<RentalUnit>>> GetAllRentalUnits()
        {
            var units = await _context.RentalUnits.ToListAsync();
            return Ok(units);
        }

        [HttpPost("SearchRentals")]
        public async Task<ActionResult<IEnumerable<RentalUnit>>> SearchRentalUnits([FromBody] SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrEmpty(criteria.Query) || string.IsNullOrEmpty(criteria.SearchBy))
            {
                return BadRequest("Query and SearchBy parameters are required.");
            }

            IQueryable<RentalUnit> queryable = _context.RentalUnits;

            string query = criteria.Query.Trim().ToLower();
            string searchBy = criteria.SearchBy.Trim().ToLower();

            queryable = searchBy switch
            {
                "unitcode" => queryable.Where(u => u.UnitCode.ToLower().Contains(query)),
                "unitdescription" => queryable.Where(u => u.UnitDescription.ToLower().Contains(query)),
                "unitaddress" => queryable.Where(u => u.UnitAddress.ToLower().Contains(query)),
                "lowestcategory" => queryable.Where(u => u.LowestCategory.ToLower().Contains(query)),
                "rentalvalue" => queryable.Where(u => u.RentalValue.ToString().Contains(query)),
                "unitcontents" => queryable.Where(u => u.UnitContents.ToLower().Contains(query)),
                "rentername" => queryable.Where(u => u.RenterName.ToLower().Contains(query)),
                "rentercode" => queryable.Where(u => u.RenterCode.ToLower().Contains(query)),
                "unitstatus" => queryable.Where(u => u.UnitStatus.ToLower().Contains(query)),
                _ => queryable
            };

            var results = await queryable.ToListAsync();

            return Ok(results);
        }

    }
}
