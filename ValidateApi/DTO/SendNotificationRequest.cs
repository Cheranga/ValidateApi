using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidateApi.DTO
{
    public class SendNotificationRequest
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
    }
}
