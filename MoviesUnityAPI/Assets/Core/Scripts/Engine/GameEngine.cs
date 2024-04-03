namespace ServerSettings
{                     
    public class GameEngine : GenericSingleton<GameEngine>
    {        
        public string ServerEndpoint { get; } = $"https://localhost:7124/api/";
    }
}

