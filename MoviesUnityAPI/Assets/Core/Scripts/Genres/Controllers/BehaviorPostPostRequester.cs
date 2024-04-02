using System;
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;     

namespace Genres
{
    internal class BehaviorPostPostRequester : IBehaviorPostRequester
    {
        public event Action<string> OnGetResult;
        
        private const string _apiController = "genres";
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethod(object genreModel)
        {
            _httpRequester = new HttpClient();
            await _httpRequester.Post<ICreateGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController),
              genreModel);          
            OnGetResult?.Invoke(_httpRequester.GetServerResponse);
        }                      
    }
}