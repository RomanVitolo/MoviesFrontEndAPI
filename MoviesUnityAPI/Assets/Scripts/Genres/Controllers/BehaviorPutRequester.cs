using System.Threading.Tasks;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;

namespace Genres
{
    internal class BehaviorPutRequester : IBehaviorPutRequester
    {
        private const string _apiController = "genres";  
        
        public async Task CallRequestMethod(string typeId, object bodyClass)
        {
            await HttpClient.Put<ICreateGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint,
                _apiController), int.Parse(typeId), bodyClass);
        }
    }
}