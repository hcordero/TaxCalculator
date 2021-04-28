using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.API.InfrastructureLibrary.Settings;

namespace TaxCalculator.ServiceLibrary.Settings
{
    public interface IApplicationSettingsService
    {
        ApplicationSettings ApplicationSettings { get; }
    }
}
