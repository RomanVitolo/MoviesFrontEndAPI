using System;
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;

namespace Genres
{
    internal class BehaviorPutRequester : IBehaviorPutRequester
    {
        public event Action<string> OnGetResult;
        
        private const string _apiController = "genres";
        private IHttpRequester _httpRequester;
      
        public async Task CallRequestMethod(string typeId, object bodyClass)
        { 
            _httpRequester = new HttpClient();
           await _httpRequester.Put<ICreateGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint,
               _apiController), int.Parse(typeId), bodyClass);                   
           OnGetResult?.Invoke("Genre Updated");
        }                        
    }
}