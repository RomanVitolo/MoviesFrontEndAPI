using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ServerSettings
{
    public static class HttpClient
    {
        public static async Task<T> Get<T>(string endPoint) => await SendRequest<T>(endPoint);
        public static async Task<T> GetId<T>(string endPoint, int id) => await SendRequest<T>(string.Concat(endPoint, $"/{id}"));

        public static async Task<T> Post<T>(string endPoint, object payload) => await SendRequest<T>(endPoint, RequestType.POST, payload);

        public static async Task<T> Put<T>(string endPoint, int id, object payload) => await SendRequest<T>(string.Concat(endPoint, $"/{id}"), RequestType.PUT, payload);
        public static async Task<T> Delete<T>(string endPoint, int id) => await SendRequest<T>(string.Concat(endPoint, $"/{id}"), RequestType.DELETE);

        private static async Task<T> SendRequest<T>(string path,
            RequestType type = RequestType.GET,
            object data = null)
        {
            try
            {
                var request = CreateRequest(path, type, data);
                await Task.Yield();
                request.SendWebRequest();

                if (!request.isNetworkError && !request.isHttpError)
                    return JsonConvert.DeserializeObject<T>(request.downloadHandler.text);

                Debug.LogError("Network error: " + request.error);
                return default;
            }
            catch (Exception ex)
            {
                Debug.LogError("Error in Post request: " + ex.Message);
                return default;
            }
        }


        private static UnityWebRequest CreateRequest(string path,
            RequestType type = RequestType.GET,
            object data = null)
        {
            var request = new UnityWebRequest(path, type.ToString());

            if (data != null)
            {
                var bodyRaw = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            AttachHeader(request, "Content-Type", "application/json");

            return request;
        }

        private static void AttachHeader(UnityWebRequest request, string key, string value)
        {
            request.SetRequestHeader(key, value);
        }

    }
}

public enum RequestType
{
    GET = 0,
    POST = 1,
    PUT = 2,
    DELETE = 3,
    PATCH = 4
}