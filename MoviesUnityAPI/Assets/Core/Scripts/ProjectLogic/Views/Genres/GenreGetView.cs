using Controllers;
using Interfaces;
using Models;
using TMPro;
using UnityEngine;       
using UnityEngine.UI;         

namespace Views.Genres
{    
    internal class GenreGetView : MonoBehaviour
    {     
        [SerializeField] private TMP_InputField _idInput; 
        [SerializeField] private TextMeshProUGUI _idText; 
        [SerializeField] private TextMeshProUGUI _nameText; 
        
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
            _behaviorRequesterById.CallRequestMethodById<GenreModel>(_apiController, _idInput.text);      
        }

        private void WaitResponse(object showMessage)
        {
            var responseModel = (GenreModel) showMessage;
            _idText.text = "Id: " + responseModel.Id;
            _nameText.text = "Name: " + responseModel.Name;
        } 

        private void GetResponse(object obj)
        {
            WaitResponse(obj);         
            _button.interactable = true;
        }   
    }
}