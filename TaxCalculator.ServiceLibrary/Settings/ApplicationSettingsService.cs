using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.API.InfrastructureLibrary.Settings;

namespace TaxCalculator.ServiceLibrary.Settings
{
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        public ApplicationSettingsService(ApplicationSettings applicationSettings)
        {
            this.ApplicationSettings = applicationSettings;
        }

        public ApplicationSettings ApplicationSettings { get; private set; }
    }
}
