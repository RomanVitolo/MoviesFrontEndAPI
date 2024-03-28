using System.Threading.Tasks;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;    

namespace Genres
{
    internal class BehaviourGetRequester : IBehaviourRequesterById
    {      
        private const string _apiController = "genres";

        public async Task CallRequestMethodById(string typeId)
        {
            if (!string.IsNullOrEmpty(typeId))  
                await HttpClient.GetId<IGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController), int.Parse(typeId));       
            else    
                await HttpClient.Get<IGenreDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController));
        }                        
    }
}