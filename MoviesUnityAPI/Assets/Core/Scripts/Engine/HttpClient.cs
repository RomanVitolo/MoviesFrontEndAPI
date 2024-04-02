using Assets.Core.Scripts.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text;    
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ServerSettings
{
    public class HttpClient : IHttpRequester
    {
        public string GetServerResponse { get; set; }
        public async Task<T> Get<T>(string endPoint) => await SendRequest<T>(endPoint);
        public async Task<T> GetId<T>(string endPoint, int id) => await SendRequest<T>(string.Concat(endPoint, $"/{id}"));

        public async Task<T> Post<T>(string endPoint, object payload) => await SendRequest<T>(endPoint, RequestType.POST, payload);

        public async Task<T> Put<T>(string endPoint, int id, object payload) => await SendRequest<T>(string.Concat(endPoint, $"/{id}"), RequestType.PUT, payload);
        public async Task<T> Delete<T>(string endPoint, int id) => await SendRequest<T>(string.Concat(endPoint, $"/{id}"), RequestType.DELETE);          

        private async Task<T> SendRequest<T>(string path,
            RequestType type = RequestType.GET,
            object data = null)
        {   
            try
            {
                var request = CreateRequest(path, type, data);   
                await Task.CompletedTask; 
                request.SendWebRequest();     
                var result = JsonConvert.DeserializeObject<T>(request.downloadHandler.text);
                await Task.Delay(1000);
                GetServerResponse = request.downloadHandler.text; 
                return result;
            }
            catch (Exception ex)
            {
                Debug.LogError("Request error: " + ex.Message);
                return default;
            }
        }            

        private UnityWebRequest CreateRequest(string path,
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

        private void AttachHeader(UnityWebRequest request, string key, string value)
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