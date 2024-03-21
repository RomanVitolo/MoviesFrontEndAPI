using SharedLibrary.Interfaces.Entities;
using System;
using TMPro;
using UnityEngine;

namespace ServerSettings
{
    [Serializable]
    public class GenreCreation
    {
        public string Name { get; set; }
        
        public GenreCreation(string name)
        {
            Name = name;
        }
    }

    public class GameEngine : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _agentIdInput;
        [SerializeField] private string _apiController = "genres";
        
        private GenreCreation _genreCreation;
        
        private readonly string _serverEndpoint = $"https://localhost:7124/api/";      

        private void Awake()
        {
            _genreCreation = new GenreCreation("Action");
            if (_agentIdInput == null) FindObjectOfType<TMP_InputField>();
        }

        public async void OnGetByID()
        {
            //var response = await HttpClient.GetId<ICreateGenreDTO>(string.Concat(_serverEndpoint, _apiController), int.Parse(_agentIdInput.text));
        }

        public async void OnPost()
        {
            var response = await HttpClient.Post<ICreateGenreDTO>(string.Concat(_serverEndpoint, _apiController), _genreCreation);
        }

        public async void OnPut()
        {
            //var response = await HttpClient.Put<ICreateGenreDTO>(string.Concat(_serverEndpoint, _apiController), int.Parse(_agentIdInput.text), _genreCreation);
        }
    }
}

