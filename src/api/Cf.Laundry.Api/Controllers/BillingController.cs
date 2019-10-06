using Cf.Libs.Service.Billing;
using Cf.Libs.Service.Dtos.Billing;
using Microsoft.AspNetCore.Mvc;

namespace Cf.Laundry.Api.Controllers
{
    [Route("api/billing")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public BillDto GetOrders(int id)
        {
            return _billingService.Get(id);
        }

        [HttpPost]
        [Route("publish")]
        public BillDto Publish([FromBody] string orderId)
        {
            return _billingService.Publish(orderId);
        }

        [HttpPost]
        [Route("unpublish")]
        public bool UnPublish(string orderId)
        {
            return _billingService.UnPublish(orderId);
        }
    }
}