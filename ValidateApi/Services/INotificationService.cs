using System.Threading.Tasks;
using ValidateApi.Controllers;
using ValidateApi.DTO;

namespace ValidateApi.Services
{
    public interface INotificationService
    {
        Task<bool> SendNotificationAsync(SendNotificationRequest request);
    }
}