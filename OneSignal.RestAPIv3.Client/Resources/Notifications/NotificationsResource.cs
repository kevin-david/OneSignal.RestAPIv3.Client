using System;
using System.Net;
using System.Threading.Tasks;
using OneSignal.RestAPIv3.Client.Serializers;
using RestSharp;

namespace OneSignal.RestAPIv3.Client.Resources.Notifications
{
    /// <summary>
    /// Class used to define resources needed for client to manage notifications.
    /// </summary>
    public class NotificationsResource : BaseResource, INotificationsResource
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiKey">Your OneSignal API key</param>
        /// <param name="apiUri">API uri (https://onesignal.com/api/v1/notifications)</param>
        public NotificationsResource(string apiKey, string apiUri) : base(apiKey, apiUri)
        {
        }

        /// <summary>
        /// Creates new notification to be sent by OneSignal system.
        /// </summary>
        /// <param name="options">Options used for notification create operation.</param>
        /// <returns></returns>
        public NotificationCreateResult Create(NotificationCreateOptions options)
        {
            RestRequest restRequest = CreateRestRequest("notifications", Method.POST);
            restRequest.AddJsonBody(options);
            IRestResponse<NotificationCreateResult> restResponse = base.RestClient.Execute<NotificationCreateResult>(restRequest);
            return GetResponseData(restResponse);
        }

        /// <summary>
        /// Creates new notification to be sent by OneSignal system. Async version
        /// </summary>
        /// <param name="options">Options used for notification create operation.</param>
        /// <returns></returns>
        public async Task<NotificationCreateResult> CreateAsync(NotificationCreateOptions options)
        {
            RestRequest restRequest = CreateRestRequest("notifications", Method.POST);
            restRequest.AddJsonBody(options);
            IRestResponse<NotificationCreateResult> restResponse = await base.RestClient.ExecuteTaskAsync<NotificationCreateResult>(restRequest);
            return GetResponseData(restResponse);
        }

        /// <summary>
        /// Get delivery and convert report about single notification.
        /// </summary>
        /// <param name="options">Options used for getting delivery and convert report about single notification.</param>
        /// <returns></returns>
        public NotificationViewResult View(NotificationViewOptions options)
        {
            var baseRequestPath = "notifications/{0}?app_id={1}";
            RestRequest restRequest = CreateRestRequest(string.Format(baseRequestPath, options.Id, options.AppId), Method.GET);
            var restResponse = base.RestClient.Execute<NotificationViewResult>(restRequest);
            return GetResponseData(restResponse);
        }

        /// <summary>
        /// Get delivery and convert report about single notification. Async version
        /// </summary>
        /// <param name="options">Options used for getting delivery and convert report about single notification.</param>
        /// <returns></returns>
        public async Task<NotificationViewResult> ViewAsync(NotificationViewOptions options)
        {
            var baseRequestPath = "notifications/{0}?app_id={1}";
            RestRequest restRequest = CreateRestRequest(string.Format(baseRequestPath, options.Id, options.AppId), Method.GET);
            var restResponse = await base.RestClient.ExecuteTaskAsync<NotificationViewResult>(restRequest);
            return GetResponseData(restResponse);
        }

        /// <summary>
        /// Cancel a notification scheduled by the OneSignal system
        /// </summary>
        /// <param name="options">Options used for notification cancel operation.</param>
        /// <returns></returns>
        public NotificationCancelResult Cancel(NotificationCancelOptions options)
        {
            RestRequest restRequest = CreateRestRequest("notifications/" + options.Id, Method.DELETE);
            restRequest.AddParameter("app_id", options.AppId);

            IRestResponse<NotificationCancelResult> restResponse = base.RestClient.Execute<NotificationCancelResult>(restRequest);
            ThrowIfError(restResponse);

            return restResponse.Data;
        }

        /// <summary>
        /// Cancel a notification scheduled by the OneSignal system. Async version
        /// </summary>
        /// <param name="options">Options used for notification cancel operation.</param>
        /// <returns></returns>
        public async Task<NotificationCancelResult> CancelAsync(NotificationCancelOptions options)
        {
            RestRequest restRequest = CreateRestRequest("notifications/" + options.Id, Method.DELETE);
            restRequest.AddParameter("app_id", options.AppId);

            IRestResponse<NotificationCancelResult> restResponse = await base.RestClient.ExecuteTaskAsync<NotificationCancelResult>(restRequest);
            ThrowIfError(restResponse);

            return restResponse.Data;
        }

        private T GetResponseData<T>(IRestResponse<T> restResponse) {
            if (!(restResponse.StatusCode != HttpStatusCode.Created || restResponse.StatusCode != HttpStatusCode.OK))
            {
                ThrowIfError(restResponse);
            }
            return restResponse.Data;
        }

        private void ThrowIfError<T>(IRestResponse<T> restResponse) {
            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }
            else if (restResponse.StatusCode != HttpStatusCode.OK && restResponse.Content != null)
            {
                throw new Exception(restResponse.Content);
            }
        }

        private RestRequest CreateRestRequest(string url, Method method) {
            RestRequest restRequest = new RestRequest(url, method);
            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new NewtonsoftJsonSerializer();
            return restRequest;
        }
    }
}
