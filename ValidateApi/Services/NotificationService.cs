using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidateApi.Configs;
using ValidateApi.Controllers;
using ValidateApi.DTO;
using ValidateApi.Exceptions;

namespace ValidateApi.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationServiceConfig _config;

        public NotificationService(NotificationServiceConfig config)
        {
            _config = config;
        }

        public Task<bool> SendNotificationAsync(SendNotificationRequest request)
        {
            //
            // Add the notification service logic in here
            //
            return Task.FromResult(true);
        }
    }
}
