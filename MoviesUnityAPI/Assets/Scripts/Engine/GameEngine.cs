using SharedLibrary.Interfaces.Entities;
using System;
using TMPro;
using UnityEngine;

namespace ServerSettings
{                     
    public class GameEngine : MonoBehaviour
    {
        private static GameEngine _instance;    
        public static GameEngine Instance
        {
            get
            {          
                if (_instance == null) {
                 
                    _instance = FindObjectOfType<GameEngine>();    
                   
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject("MiSingleton");
                        _instance = singletonObject.AddComponent<GameEngine>();
                    }
                }

                return _instance;
            }
        }

        private void Awake()
        {      
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return; 
            }                 
           
            DontDestroyOnLoad(this.gameObject);
        }           

        public string ServerEndpoint { get; set; } = $"https://localhost:7124/api/";  
    }
}

