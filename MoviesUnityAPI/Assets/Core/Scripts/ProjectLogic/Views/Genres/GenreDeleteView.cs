using Controllers;
using Interfaces;
using Models;        
using TMPro;
using UnityEngine;     
using UnityEngine.UI;

namespace Views.Genres
{
    internal class GenreDeleteView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _IdInput;
        [SerializeField] private TextMeshProUGUI _responseText;
        
        private Button _button;  
        private IBehaviorRequesterById _behaviorRequesterById;
        
        private const string _apiController = "genres";
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
             _behaviorRequesterById.CallRequestMethodById<MessageResponse>(_apiController, _IdInput.text);  
            else
                Debug.Log("An AgentId is required");
        } 
        
        private void OnEnable() =>  _behaviorRequesterById.OnGetResult += GetResponse;  
        private void OnDisable() => _behaviorRequesterById.OnGetResult -= GetResponse;

        private void WaitResponse(object showMessage)
        {
            var response = (MessageResponse) showMessage;
            _responseText.text = response.Message;   
        }    
        private void GetResponse(object obj) => WaitResponse(obj);     
    }   
}