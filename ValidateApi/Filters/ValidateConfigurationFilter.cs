using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using ValidateApi.Configs;
using ValidateApi.Exceptions;

namespace ValidateApi.Filters
{
    public class ValidateConfigurationFilter : IStartupFilter
    {
        private readonly IEnumerable<IValidateConfig> _configsToValidate;

        public ValidateConfigurationFilter(IEnumerable<IValidateConfig> configsToValidate)
        {
            _configsToValidate = configsToValidate?.ToList() ?? new List<IValidateConfig>();

        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            if (_configsToValidate.Any())
            {
                foreach (var config in _configsToValidate)
                {
                    var validationResults = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(config, new ValidationContext(config), validationResults);
                    if (isValid)
                    {
                        continue;
                    }

                    var errorMessage = string.Join(Environment.NewLine, validationResults.Select(x => x.ErrorMessage));
                    throw new InvalidConfigurationException(config.GetType(), errorMessage);
                }
            }

            return next;
        }
    }
}
