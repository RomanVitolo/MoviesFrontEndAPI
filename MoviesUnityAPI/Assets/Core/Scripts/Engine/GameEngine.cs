using UnityEngine;

namespace ServerSettings
{                     
    public class GameEngine : GenericSingleton<GameEngine>
    {        
        public string ServerEndpoint { get; } = $"https://localhost:7124/api/";
        [field: SerializeField] public string BearerToken { get; set; }
    }
}

