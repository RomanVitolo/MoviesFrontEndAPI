using Interfaces;
using TMPro;
using UnityEngine;     
using UnityEngine.UI;

namespace Genres
{
    internal class GenreDeleteView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _IdInput;
        [SerializeField] private TextMeshProUGUI _responseText;
        
        private Button _button;                   
        private IBehaviorRequesterById _behaviorRequesterById;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorRequesterById = new BehaviorDeleteRequester();         
            _button.onClick.AddListener(SendRequest);   
        }              
        private void SendRequest()
        {    
             //TODO CREATE A VALIDATION
            if(_IdInput.text != null)
             _behaviorRequesterById.CallRequestMethodById(_IdInput.text);  
            else
                Debug.Log("An AgentId is required");
        } 
        
        private void OnEnable() =>  _behaviorRequesterById.OnGetResult += GetResponse;  
        private void OnDisable() => _behaviorRequesterById.OnGetResult -= GetResponse;  
        private void WaitResponse(string showMessage) => _responseText.text = showMessage;     
        private void GetResponse(string obj) => WaitResponse(obj);  
    }
}