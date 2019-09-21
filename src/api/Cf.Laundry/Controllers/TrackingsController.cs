using Cf.Libs.Service.Dtos.Tracking;
using Cf.Libs.Service.Trackings;
using Microsoft.AspNetCore.Mvc;

namespace Cf.Laundry.Controllers
{
    [Route("api/trackings")]
    [ApiController]
    public class TrackingsController : ControllerBase
    {
        private readonly ITrackingService _trackingService;

        public TrackingsController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpGet]
        [Route("order/{phone}/{code}")]
        public OrderHistoryDto Order(string phone, string code)
        {
            return _trackingService.Order(phone, code);
        }
    }
}