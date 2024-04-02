using System.Collections;
using Interfaces;    
using TMPro;
using UnityEngine;               
using UnityEngine.UI;         

namespace Genres
{    
    internal class GenreGetView : MonoBehaviour
    {     
        [SerializeField] private TMP_InputField _IdInput; 
        [SerializeField] private TextMeshProUGUI _responseText; 
        
        private Button _button;                   
        private IBehaviorRequesterById _behaviorRequesterById;     
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
            _behaviorRequesterById.CallRequestMethodById(_IdInput.text);      
        }        
        private void WaitResponse(string showMessage) => _responseText.text = showMessage;

        private void GetResponse(string obj)
        {
            WaitResponse(obj);         
            _button.interactable = true;
        }   
    }
}