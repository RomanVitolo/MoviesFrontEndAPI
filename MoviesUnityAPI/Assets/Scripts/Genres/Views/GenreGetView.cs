using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;         

namespace Genres
{    
    internal class GenreGetView : MonoBehaviour
    {     
        [SerializeField] private TMP_InputField _agentIdInput; 
        
        private Button _button;                   
        private IBehaviorRequesterById _behaviorRequesterById;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorRequesterById = new BehaviorGetRequester();
            if (_agentIdInput == null) FindObjectOfType<TMP_InputField>();     
            _button.onClick.AddListener(SendRequest);   
        }              
        private void SendRequest()
        {     
            Debug.Log("Do Something");
            _behaviorRequesterById.CallRequestMethodById(_agentIdInput.text);          
        }
    }
}