using System;
using Controllers;
using Interfaces;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Authentication
{
    public class LoginView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _userEmail;
        [SerializeField] private TMP_InputField _userPassword;
        [SerializeField] private TextMeshProUGUI _responseText;
        
        private Button _button;
        private LoginModel _loginModel;
        private IBehaviorPostRequester _behaviorPostRequester;

        private const string _apiController = "accounts/login";  
        
        private void Awake()
        {
            _button = GetComponent<Button>();     
            _behaviorPostRequester = new BehaviorPostRequester();
        }
        
        private void OnEnable()
        {
            _button.onClick.AddListener(SendRequest);   
            _behaviorPostRequester.OnGetResult += GetResponse;  
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
            _behaviorPostRequester.OnGetResult -= GetResponse;  
        } 
        private void WaitResponse(string showMessage) => _responseText.text = showMessage;     
        private void GetResponse(string obj) => WaitResponse(obj);             
        private void SendRequest() => _behaviorPostRequester.CallRequestMethod( _apiController, GenreModel());
        
        private object GenreModel()
        {
            _loginModel = new LoginModel(_userEmail.text, _userPassword.text);
            return _loginModel;
        }
    }
}