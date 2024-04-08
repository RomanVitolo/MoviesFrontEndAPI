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
        public event Action<string> OnGetResult;     
        
        private IHttpRequester _httpRequester;         
        public async Task CallRequestMethodById(string apiController, string typeId)
        {
            _httpRequester = new HttpClient();
            if (!string.IsNullOrEmpty(typeId))
            {   
                await _httpRequester.GetId<IGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, apiController), int.Parse(typeId));     
                OnGetResult?.Invoke(_httpRequester.GetServerResponse);    
            }    
            else
            {
                await _httpRequester.Get<IGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, apiController));            
                OnGetResult?.Invoke(_httpRequester.GetServerResponse);     
            }                
        }       
    }
}