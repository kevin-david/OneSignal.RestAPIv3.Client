using Newtonsoft.Json;
using OneSignal.RestAPIv3.Client.Resources;
using OneSignal.RestAPIv3.Client.Resources.Notifications;
using System;
using System.Collections.Generic;

namespace OneSignal.RestAPIv3.Client.Sample.ConsoleApp.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
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

            var result = client.Notifications.Create(options);

            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.ReadLine();
        }
    }
}
