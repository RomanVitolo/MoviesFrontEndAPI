using System;
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
            ClearText();
            if (string.IsNullOrEmpty(_idInput.text))   
                _behaviorRequesterById.CallRequestMethodById<GenreModel[]>(_apiController, _idInput.text);
            else                                  
            _behaviorRequesterById.CallRequestMethodById<GenreModel>(_apiController, _idInput.text);
        }        

        private void WaitResponse(object showMessage)
        {
            if (showMessage is GenreModel resultModel)
            {
                _idText.text = "\nId: " + resultModel.Id;
                _nameText.text = "\n" + resultModel.Name; 
            }
            else
            {
                var responseModel = (GenreModel[]) showMessage;
                foreach (var response in responseModel)
                {
                    _idText.text += "\nId: " + response.Id;
                    _nameText.text += "\n" + response.Name; 
                } 
            }      
        } 

        private void GetResponse(object obj)
        {
            if (obj != null)
            {
                _button.interactable = true;
                WaitResponse(obj);  
            }
            else
            {
                _button.interactable = true;
                Debug.Log("Try again");
                return;
            }
        }            
        
        private void ClearText()
        {       
            _idText.text = string.Empty;
            _nameText.text = string.Empty;
        }
    }
}     