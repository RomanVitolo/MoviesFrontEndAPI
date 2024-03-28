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
        private IBehaviourRequesterById _behaviourRequesterById;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviourRequesterById = new BehaviourGetRequester();
            if (_agentIdInput == null) FindObjectOfType<TMP_InputField>();     
            _button.onClick.AddListener(SendRequest);   
        }              
        private void SendRequest()
        {     
            Debug.Log("Do Something");
            _behaviourRequesterById.CallRequestMethodById(_agentIdInput.text);          
        }
    }
}