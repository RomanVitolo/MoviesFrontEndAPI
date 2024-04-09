using System;
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;

namespace Controllers
{
    internal class BehaviorPutRequester : IBehaviorPutRequester
    {
        public event Action<object> OnGetResult;          
      
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethod<T>(string apiController, string typeId, object bodyClass)
        { 
            _httpRequester = new HttpClient();
           var request = await _httpRequester.Put<T>(string.Concat(GameEngine.Instance.ServerEndpoint,
               apiController), int.Parse(typeId), bodyClass);                   
           OnGetResult?.Invoke(request);
        }                        
    }
}