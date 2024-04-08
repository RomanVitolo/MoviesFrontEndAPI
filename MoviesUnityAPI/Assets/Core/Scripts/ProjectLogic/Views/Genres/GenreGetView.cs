using System.Collections;
using Controllers;
using Interfaces;    
using TMPro;
using UnityEngine;               
using UnityEngine.UI;         

namespace Views.Genres
{    
    internal class GenreGetView : MonoBehaviour
    {     
        [SerializeField] private TMP_InputField _IdInput; 
        [SerializeField] private TextMeshProUGUI _responseText; 
        
        private Button _button;                   
        private IBehaviorRequesterById _behaviorRequesterById;   
        
        private const string _apiController = "genres";
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorRequesterById = new BehaviorGetRequester();   
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(SendRequest);
            _behaviorRequesterById.OnGetResult += GetResponse;
        }  

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
            _behaviorRequesterById.OnGetResult -= GetResponse;   
        }              

        private void SendRequest()
        {
            _button.interactable = false;    
            _behaviorRequesterById.CallRequestMethodById(_apiController, _IdInput.text);      
        }        
        private void WaitResponse(string showMessage) => _responseText.text = showMessage;

        private void GetResponse(string obj)
        {
            WaitResponse(obj);         
            _button.interactable = true;
        }   
    }
}