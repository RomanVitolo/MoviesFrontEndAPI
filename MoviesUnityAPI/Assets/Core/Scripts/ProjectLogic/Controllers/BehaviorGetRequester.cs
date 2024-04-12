using System;       
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;       

namespace Controllers
{
    internal class BehaviorGetRequester : IBehaviorRequesterById
    {  
        public event Action<object> OnGetResult;     
        
        private IHttpRequester _httpRequester;         
        public async Task CallRequestMethodById<T>(string apiController, string typeId)
        {
            _httpRequester = new HttpClient();
            if (!string.IsNullOrEmpty(typeId))
            {   
                var request = await _httpRequester.GetId<T>(
                    string.Concat(GameEngine.Instance.ServerEndpoint, apiController),
                    GameEngine.Instance.BearerToken,int.Parse(typeId));    
                OnGetResult?.Invoke(request);    
            }    
            else
            {
                var request = await _httpRequester.Get<T>(string.Concat(GameEngine.Instance.ServerEndpoint, apiController), GameEngine.Instance.BearerToken);    
                OnGetResult?.Invoke(request);     
            }                
        }       
    }
}