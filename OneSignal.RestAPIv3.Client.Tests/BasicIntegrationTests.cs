using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OneSignal.RestAPIv3.Client.Resources.Notifications;
using OneSignal.RestAPIv3.Client.Resources;

namespace OneSignal.RestAPIv3.Client.Tests
{
    [TestClass]
    public class BasicIntegrationTests
    {
        [TestMethod]
        public void TestASimpleCall()
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

            client.Notifications.Create(options);
        }
    }
}
