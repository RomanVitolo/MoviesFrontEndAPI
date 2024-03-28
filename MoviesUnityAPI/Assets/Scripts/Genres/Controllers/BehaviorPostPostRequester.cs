using System.Threading.Tasks;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;     

namespace Genres
{
    internal class BehaviorPostPostRequester : IBehaviorPostRequester
    {
        private const string _apiController = "genres";        
              
        public async Task CallRequestMethod(object genreModel)
        {
            await HttpClient.Post<ICreateGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController),
                genreModel);    
        }          
    }
}