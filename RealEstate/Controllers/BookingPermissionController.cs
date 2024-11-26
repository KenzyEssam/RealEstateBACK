using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.DTO;
using RealEstate.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingPermissionController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public BookingPermissionController(RealEstateContext context)
        {
            _context = context;
        }

        // POST: api/BookingPermission/Create
        [HttpPost("Create")]
        public async Task<ActionResult<BookingPermission>> CreateBookingPermission([FromBody] BookingPermissionRequest dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var newBookingPermission = new BookingPermission
            {
                ClientCode = dto.ClientCode,
                ClientName = dto.ClientName,
                Date = dto.Date,
                Delegate = dto.Delegate,
                PaymentPlan = dto.PaymentPlan,
                Unit = dto.Unit,
                UnitValue = dto.UnitValue,
                BookingType = dto.BookingType,
                ValidityPeriod = dto.ValidityPeriod
            };

            _context.BookingPermissions.Add(newBookingPermission);
            await _context.SaveChangesAsync();

            return Ok(newBookingPermission);
        }

        // GET: api/BookingPermission/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BookingPermission>>> GetAllBookingPermissions()
        {
            var bookingPermissions = await _context.BookingPermissions.ToListAsync();
            return Ok(bookingPermissions);
        }

        // POST: api/BookingPermission/Search
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<BookingPermission>>> SearchBookingPermissions([FromBody] SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrEmpty(criteria.Query) || string.IsNullOrEmpty(criteria.SearchBy))
            {
                return BadRequest("Query and SearchBy parameters are required.");
            }

            IQueryable<BookingPermission> queryable = _context.BookingPermissions;

            string query = criteria.Query.Trim().ToLower();
            string searchBy = criteria.SearchBy.Trim().ToLower();

            queryable = searchBy switch
            {
                "clientcode" => queryable.Where(bp => bp.ClientCode.ToLower().Contains(query)),
                "clientname" => queryable.Where(bp => bp.ClientName.ToLower().Contains(query)),
                "date" => queryable.Where(bp => bp.Date.ToString().ToLower().Contains(query)),
                "delegate" => queryable.Where(bp => bp.Delegate.ToLower().Contains(query)),
                "paymentplan" => queryable.Where(bp => bp.PaymentPlan.ToLower().Contains(query)),
                "unit" => queryable.Where(bp => bp.Unit.ToLower().Contains(query)),
                "unitvalue" => queryable.Where(bp => bp.UnitValue.ToString().ToLower().Contains(query)),
                "bookingtype" => queryable.Where(bp => bp.BookingType.ToLower().Contains(query)),
                "validityperiod" => queryable.Where(bp => bp.ValidityPeriod.ToLower().Contains(query)),
                _ => queryable
            };

            var results = await queryable.ToListAsync();

            return Ok(results);
        }
    }
}
