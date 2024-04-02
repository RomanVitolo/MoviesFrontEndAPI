using System;       
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;       

namespace Genres
{
    internal class BehaviorGetRequester : IBehaviorRequesterById
    {  
        public event Action<string> OnGetResult;     
        
        private const string _apiController = "genres";
        private IHttpRequester _httpRequester;         
        
        public async Task CallRequestMethodById(string typeId)
        {
            _httpRequester = new HttpClient();
            if (!string.IsNullOrEmpty(typeId))
            {   
                await _httpRequester.GetId<IGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController), int.Parse(typeId));     
                OnGetResult?.Invoke(_httpRequester.GetServerResponse);    
            }    
            else
            {
                await _httpRequester.Get<IGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController));            
                OnGetResult?.Invoke(_httpRequester.GetServerResponse);     
            }                
        }       
    }
}