# Validate API

This repository shows few implementations about how to validate your configurations in an ASP.NET Core 2.1 application.

## Approaches

The below branches show the approaches taken to validate configurations.

* feature/Config_Validation_At_Startup
  * Validation will not occur in the start up. Meaning the validation will happen only when the first request to the `NotificationsController` receives.
  
* feature/Config_Validation_Using_IStartupFilter
* feature/Config_Validation_Using_Nuget

I have created a nuget package with these findings and you can use it following the instructions below.

* Install the nuget package.

* Register your configurations.