![OneSignal Logo](https://onesignal.com/assets/common/logo_onesignal_color.png)
# OneSignal.RestApiv3.Client
A General purpose REST Api Client written in C# language for the OneSignal API v3

[![Build status](https://ci.appveyor.com/api/projects/status/f8vnbla1mef503sr/branch/master?svg=true)](https://ci.appveyor.com/project/MundiPagg/onesignal-csharp-sdk/branch/master)

## Install via NuGet

```powershell
PM> Install-Package OneSignal.RestAPIv3.Client
```

[OneSignal.RestApiv3.Client package](https://www.nuget.org/packages/OneSignal.RestAPIv3.Client/) targets both .NET standard 2.0 and .NET Framework 4.5.2.

## How to use

```csharp
var client = new OneSignalClient(""); // Use your Api Key

            var options = new NotificationCreateOptions
            {
                AppId = new Guid(""),   // Use your AppId
                IncludePlayerIds = new List<string>()
            {
                "00000000-0000-0000-0000-000000000000" // Use your playerId
            }
            };
            options.Headings.Add(LanguageCodes.English, "New Notification!");
            options.Contents.Add(LanguageCodes.English, "This will push a real notification directly to your device.");

            client.Notifications.Create(options);
```

## OneSignal Api Oficial Documentation
[OneSignal Server API Documentation](https://documentation.onesignal.com/reference)

## Contributing
For additional support for .Net Core 1 or additionnal .Net framework platforms, feel free to fork this repository and submit a merge request!! :)




This is a fork of [mundipagg](https://github.com/mundipagg) [**OneSignal-CSharp-SDK**](https://github.com/mundipagg/OneSignal-CSharp-SDK) repository.