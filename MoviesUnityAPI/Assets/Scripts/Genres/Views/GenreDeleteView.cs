using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Genres
{
    internal class GenreDeleteView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _agentIdInput; 
        
        private Button _button;                   
        private IBehaviorRequesterById _behaviorRequesterById;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorRequesterById = new BehaviorDeleteRequester();
            if (_agentIdInput == null) FindObjectOfType<TMP_InputField>();     
            _button.onClick.AddListener(SendRequest);   
        }              
        private void SendRequest()
        {     
            Debug.Log("Do Something");
            //TODO CREATE A VALIDATION
            if(_agentIdInput.text != null)
             _behaviorRequesterById.CallRequestMethodById(_agentIdInput.text);  
            else
                Debug.Log("An AgentId is required");
        } 
    }
}