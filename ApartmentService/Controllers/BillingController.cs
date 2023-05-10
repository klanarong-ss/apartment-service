using ApartmentService.Business.InterfaceServices;
using ApartmentService.DataAccess.ComplexModels;
using ApartmentService.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;
        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet]
        [Route("GenerateBillingCurrentMonth")]
        public async Task<IActionResult> GenerateBillingCurrentMonth()
        {
            var result = await _billingService.GenerateBillingCurrentMonth();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(DateTime currentDate)
        {
            var result = await _billingService.GetAllBilling(currentDate);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Billing billing)
        {
            var result = await _billingService.UpdateBilling(billing);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdatePaid")]
        public async Task<IActionResult> UpdatePaid(List<BillingDetail> billingList)
        {
            var result = await _billingService.UpdatePaid(billingList);
            return Ok(result);
        }
    }
}
