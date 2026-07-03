using Asp.Versioning;
using BankManagementSystem.DTOs;
using BankManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BankController : ControllerBase
    {
        private IBankService service;

        public BankController(IBankService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult Add(BankAccountRequestDTO dto)
        {
            service.Add(dto);
            return Ok("Bank Account Created Successfully");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetBYId(int id)
        {
            return Ok(service.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok("Bank Account Deleted.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,BankAccountRequestDTO dto)
        {
            service.Update(id, dto);
            return Ok("Bank Account Deleted.");
        }
    }
}
