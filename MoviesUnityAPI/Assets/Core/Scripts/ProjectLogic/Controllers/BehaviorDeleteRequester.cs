using System;   
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;         

namespace Controllers
{
    internal class BehaviorDeleteRequester : IBehaviorRequesterById
    { 
        public event Action<object> OnGetResult;     
       
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethodById<T>(string apiController, string typeId)
        { 
            _httpRequester = new HttpClient();
           var request = await _httpRequester.Delete<T>(string.Concat(GameEngine.Instance.ServerEndpoint, apiController),
                int.Parse(typeId));           
           OnGetResult?.Invoke(request);
        }        
    }
}