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
        public event Action<string> OnGetResult;          
      
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethod(string apiController, string typeId, object bodyClass)
        { 
            _httpRequester = new HttpClient();
           await _httpRequester.Put<ICreateGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint,
               apiController), int.Parse(typeId), bodyClass);                   
           OnGetResult?.Invoke("Entity Updated");
        }                        
    }
}