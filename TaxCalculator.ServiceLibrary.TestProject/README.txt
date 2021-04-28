The API Authentication key for the Tax Jar is empty by default.

Open the TaxCalculator.API/appsettings.json and paste the Auth key in the ProviderAuthKey property

Also the Unit Test Project have the same setting under DependencyInjector.ccs class, you will see the following on the class  ProviderAuthKey = "YOUR API KEY GOES HERE"