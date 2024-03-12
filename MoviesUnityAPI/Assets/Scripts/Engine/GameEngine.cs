using SharedLibrary.DTOs;
using System;
using TMPro;
using UnityEngine;

namespace ServerSettings
{
    [Serializable]
    public class AgentStat
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public float Health { get; set; }

        public AgentStat(int id, int level, float health)
        {
            Id = id;
            Level = level;
            Health = health;
        }
    }

    public class GameEngine : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _agentIdInput;

        private AgentStat _agentStat;
        private readonly string _serverEndpoint = "https://localhost:7140/agent";


        private void Awake()
        {
            _agentStat = new AgentStat(250, 150, 150);
            if (_agentIdInput == null) FindObjectOfType<TMP_InputField>();
        }

        public async void OnGet()
        {
            var response = await HttpClient.GetId<TestDTO>(_serverEndpoint, int.Parse(_agentIdInput.text));
        }

        public async void OnPost()
        {
            var response = await HttpClient.Post<TestDTO>(_serverEndpoint, _agentStat);
        }

        public async void OnPut()
        {
            var response = await HttpClient.Put<TestDTO>(_serverEndpoint, int.Parse(_agentIdInput.text), _agentStat);
        }
    }
}

