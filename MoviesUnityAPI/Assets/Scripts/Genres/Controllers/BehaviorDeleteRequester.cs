using System.Threading.Tasks;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;

namespace Genres
{
    internal class BehaviorDeleteRequester : IBehaviorRequesterById
    {
        private const string _apiController = "genres";
        
        public async Task CallRequestMethodById(string typeId)
        {
            await HttpClient.Delete<IIdDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController),
                int.Parse(typeId));
        }
    }
}