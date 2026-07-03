using Asp.Versioning;
using BankManagementSystem.DTOs;
using BankManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BankManagementSystem.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BankController : ControllerBase
    {
        private IBankService service;

        public BankController(IBankService service)
        {
            this.service = service;
        }

        [HttpGet("SearchByName")]
        public IActionResult SearchByName(string name)
        {
            return Ok(service.SearchByName(name));
        }

        [HttpGet("SearchByAccountNumber")]
        public IActionResult SearchByAccountNumber(string AccountNumber)
        {
            return Ok(service.SearchAccountNumber(AccountNumber));
        }

        [HttpPost("deposit")]
        [SwaggerOperation(Summary = "Deposit Money",Description = "Deposit money into an existing bank account.")]
        public IActionResult Deposit(DepositRequestDTO dto)
        {
            service.Deposit(dto);

            return Ok("Amount Deposited Successfully.");
        }

        [HttpPost("withdraw")]
        [SwaggerOperation(Summary = "Withdraw Money",Description = "Withdraw money from an existing bank account.")]
        public IActionResult Withdraw(WithdrawRequestDTO dto)
        {
            service.Withdraw(dto);

            return Ok("Amount Withdrawn Successfully.");
        }

        [HttpPost("transfer")]
        [SwaggerOperation(Summary = "Transfer Money",Description = "Transfer money from one account to another account.")]
        public IActionResult Transfer(TransferRequestDTO dto)
        {
            service.Transfer(dto);

            return Ok("Amount Transferred Successfully.");
        }

    }
}
