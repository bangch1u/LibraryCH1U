using LibraryAPI.Services;
using LibraryData.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _cusService;
        public CustomerController(ICustomerService cusService)
        {
                _cusService = cusService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_cusService.getAll());
        }
        [HttpGet("{id}")]
        public IActionResult getCustomer(Guid id)
        {
            return Ok(_cusService.getById(id)); 
        }
        [HttpPost]
        public IActionResult createCustomer(CustomerVM cus)
        {
            _cusService.createCus(cus);
            return StatusCode(201, cus);
        }
        [HttpPut("{id}")]
        public IActionResult updateCustomer(Guid id, CustomerVM cus)
        {
            _cusService.updateCus(id, cus);
            return Ok(cus);
        }
    }
}
