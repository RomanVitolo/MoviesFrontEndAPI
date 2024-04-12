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
        public async Task<T> Get<T>(string endPoint, string jwtToken) => 
            await SendRequest<T>(endPoint, RequestType.GET, jwtToken, null);
        public async Task<T> GetId<T>(string endPoint, string jwtToken, int id) => 
            await SendRequest<T>(string.Concat(endPoint, $"/{id}"), RequestType.GET, jwtToken, null);           
        public async Task<T> Post<T>(string endPoint, string jwtToken, object payload) => 
            await SendRequest<T>(endPoint, RequestType.POST, jwtToken, payload);      
        public async Task<T> Put<T>(string endPoint, string jwtToken, int id, object payload) 
            => await SendRequest<T>(string.Concat(endPoint, $"/{id}"), RequestType.PUT, jwtToken, payload);
        public async Task<T> Delete<T>(string endPoint, string jwtToken, int id) 
            => await SendRequest<T>(string.Concat(endPoint, $"/{id}"), RequestType.DELETE, jwtToken);         

        private async Task<T> SendRequest<T>(string path,
            RequestType type = RequestType.GET, string jwtToken = null,
            object data = null)
        {   
            try
            {
                var request = CreateRequest(path, type, data, jwtToken);
                await Task.CompletedTask;      
                request.SendWebRequest();     
                await Task.Delay(1000);   
                var result = JsonConvert.DeserializeObject<T>(request.downloadHandler.text);      
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
            object data = null, string jwtToken = null)
        {
            var request = new UnityWebRequest(path, type.ToString());

            if (data != null)
            {
                var bodyRaw = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            AttachHeader(request, "Content-Type", "application/json");
            
            if (!string.IsNullOrEmpty(jwtToken))      
                AttachHeader(request, "Authorization", "Bearer " + jwtToken);     

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