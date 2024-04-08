using System;
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;          

namespace Controllers
{
    internal class BehaviorDeleteRequester : IBehaviorRequesterById
    { 
        public event Action<string> OnGetResult;     
       
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethodById(string apiController, string typeId)
        { 
            _httpRequester = new HttpClient();
           await _httpRequester.Delete<IIdDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, apiController),
                int.Parse(typeId));              
           OnGetResult?.Invoke($"Entity has been removed with id {typeId}");
        }        
    }
}