using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidateApi.DTO;
using ValidateApi.Services;

namespace ValidateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SendNotificationRequest request)
        {
            var result = await _notificationService.SendNotificationAsync(request).ConfigureAwait(false);
            if (result)
            {
                return Ok("All good!");
            }

            return StatusCode((int) HttpStatusCode.InternalServerError, "Couldn't send the notification");
        }
    }
}