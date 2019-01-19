using System;

namespace ValidateApi.Configs
{
    public class NotificationServiceConfig : IValidateConfig
    {
        public string Url { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(Url) &&
                                 Uri.TryCreate(Url, UriKind.Absolute, out var uri) &&
                                 (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}