using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.DTO;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly RealEstateContext _context;

        public CustomersController(RealEstateContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromForm] CustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var newCustomer = new Customer
            {
                name = request.Name,
                code = request.Code,
                phoneNumber1 = request.PhoneNumber1,
                phoneNumber2 = request.PhoneNumber2,
                phoneNumber3 = request.PhoneNumber3,
                email = request.Email,
                address1 = request.Address1,
                relativesPhoneNumber = request.RelativesPhoneNumber,
                relatedDelegates = request.RelatedDelegates,
                relatedUnit = request.RelatedUnit,
                FilePath = "", // Handle file path appropriately
                FileName = request.Attachments?.FileName // Handle file name appropriately
            };

            // Handle file upload
            if (request.Attachments != null && request.Attachments.Length > 0)
            {
                var filePath = Path.Combine("Uploads", request.Attachments.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Attachments.CopyToAsync(stream);
                }
                newCustomer.FilePath = filePath;
                newCustomer.FileName = request.Attachments.FileName;
            }

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return Ok(newCustomer);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }


        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<Customer>>> SearchCustomers([FromBody] SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrEmpty(criteria.Query) || string.IsNullOrEmpty(criteria.SearchBy))
            {
                return BadRequest("Query and SearchBy parameters are required.");
            }

            IQueryable<Customer> queryable = _context.Customers;

            string query = criteria.Query.Trim().ToLower();
            string searchBy = criteria.SearchBy.Trim().ToLower();

            queryable = searchBy switch
            {
                "name" => queryable.Where(c => c.name.ToLower().Contains(query)),
                "code" => queryable.Where(c => c.code.ToLower().Contains(query)),
                "email" => queryable.Where(c => c.email.ToLower().Contains(query)),
                "phone" => queryable.Where(c => c.phoneNumber1.ToLower().Contains(query) ||
                                                c.phoneNumber2.ToLower().Contains(query) ||
                                                c.phoneNumber3.ToLower().Contains(query)),
                "address" => queryable.Where(c => c.address1.ToLower().Contains(query)),
                "relatedunit" => queryable.Where(c => c.relatedUnit.ToLower().Contains(query)),
                "relateddelegates" => queryable.Where(c => c.relatedDelegates.ToLower().Contains(query)),
                _ => queryable
            };

            var results = await queryable.ToListAsync();

            return Ok(results);
        }
    }
}
