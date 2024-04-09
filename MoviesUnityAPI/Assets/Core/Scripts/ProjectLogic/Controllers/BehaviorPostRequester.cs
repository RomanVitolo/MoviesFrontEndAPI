using System;
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;       

namespace Controllers
{
    internal class BehaviorPostRequester : IBehaviorPostRequester
    {
        public event Action<object> OnGetResult;       
       
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethod<T>(string apiController, object genreModel)
        {
            _httpRequester = new HttpClient();
            var request = await _httpRequester.Post<T>(string.Concat(GameEngine.Instance.ServerEndpoint, apiController),
              genreModel);          
            OnGetResult?.Invoke(request);
        }                      
    }
}