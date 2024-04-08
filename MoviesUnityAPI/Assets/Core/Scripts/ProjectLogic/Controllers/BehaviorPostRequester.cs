using System;
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;     

namespace Controllers
{
    internal class BehaviorPostRequester : IBehaviorPostRequester
    {
        public event Action<string> OnGetResult;       
       
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethod(string apiController, object genreModel)
        {
            _httpRequester = new HttpClient();
            await _httpRequester.Post<ICreateGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, apiController),
              genreModel);          
            OnGetResult?.Invoke(_httpRequester.GetServerResponse);
        }                      
    }
}