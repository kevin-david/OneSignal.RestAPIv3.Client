using System;
using System.Threading.Tasks;
using OneSignal.RestAPIv3.Client.Serializers;
using RestSharp;

namespace OneSignal.RestAPIv3.Client.Resources.Devices
{
    /// <summary>
    /// Implementation of BaseResource, used to help client add or edit device.
    /// </summary>
    public class DevicesResource : BaseResource, IDevicesResource
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiKey">Your OneSignal API key</param>
        /// <param name="apiUri">API uri (https://onesignal.com/api/v1/notifications)</param>
        public DevicesResource(string apiKey, string apiUri) : base(apiKey, apiUri)
        {
        }

        /// <summary>
        /// Adds new device into OneSignal App.
        /// </summary>
        /// <param name="options">Here you can specify options used to add new device.</param>
        /// <returns>Result of device add operation.</returns>
        public DeviceAddResult Add(DeviceAddOptions options)
        {
            var restRequest = CreateRestRequest("players", Method.POST);
            restRequest.AddJsonBody(options);
            var restResponse = base.RestClient.Execute<DeviceAddResult>(restRequest);
            ThrowIfError(restResponse);
            return restResponse.Data;
        }

        /// <summary>
        /// Adds new device into OneSignal App. Async version
        /// </summary>
        /// <param name="options">Here you can specify options used to add new device.</param>
        /// <returns>Result of device add operation.</returns>
        public async Task<DeviceAddResult> AddAsync(DeviceAddOptions options)
        {
            var restRequest = CreateRestRequest("players", Method.POST);
            restRequest.AddJsonBody(options);
            var restResponse = await base.RestClient.ExecuteTaskAsync<DeviceAddResult>(restRequest);
            ThrowIfError(restResponse);
            return restResponse.Data;
        }

        /// <summary>
        /// Edits existing device defined in OneSignal App.
        /// </summary>
        /// <param name="id">Id of the device</param>
        /// <param name="options">Options used to modify attributes of the device.</param>
        /// <exception cref="Exception"></exception>
        public void Edit(string id, DeviceEditOptions options)
        {
            RestRequest restRequest = CreateRestRequest("players/{id}", Method.PUT);
            restRequest.AddUrlSegment("id", id);
            restRequest.AddJsonBody(options);
            IRestResponse restResponse = base.RestClient.Execute(restRequest);
            ThrowIfError(restResponse);
        }

        /// <summary>
        /// Edits existing device defined in OneSignal App. Async version
        /// </summary>
        /// <param name="id">Id of the device</param>
        /// <param name="options">Options used to modify attributes of the device.</param>
        /// <exception cref="Exception"></exception>
        public async Task EditAsync(string id, DeviceEditOptions options)
        {
            RestRequest restRequest = CreateRestRequest("players/{id}", Method.PUT);
            restRequest.AddUrlSegment("id", id);
            restRequest.AddJsonBody(options);
            IRestResponse restResponse = await base.RestClient.ExecuteTaskAsync(restRequest);
            ThrowIfError(restResponse);
        }

        private RestRequest CreateRestRequest(string url, Method method)
        {
            RestRequest restRequest = new RestRequest(url, method);
            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new NewtonsoftJsonSerializer();
            return restRequest;
        }

        private void ThrowIfError(IRestResponse restResponse)
        {
            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }
        }
    }
}
