using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ValidateConfig;

namespace ValidateApi.Configs
{
    public class NotificationServiceConfig : IValidatableObject, IValidateConfig
    {
        public string Url { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var isValid = !string.IsNullOrEmpty(Url) &&
                Uri.TryCreate(Url, UriKind.Absolute, out var uri) &&
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);

            if (!isValid)
            {
                return new List<ValidationResult>
                {
                    new ValidationResult("Url is invalid")
                };
            }

            return Enumerable.Empty<ValidationResult>();

        }
    }


}