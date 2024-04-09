using System.Globalization;
using Controllers;
using Interfaces;
using Models;    
using SharedLibrary.Interfaces.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Authentication
{
    public class LoginView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _userEmail;
        [SerializeField] private TMP_InputField _userPassword;
        [SerializeField] private TextMeshProUGUI _tokenText;
        [SerializeField] private TextMeshProUGUI _expirationTokenText;
        
        private Button _button;
        private IUserInfo _loginModel;  
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
        
        private void WaitResponse(object showMessage)
        {    
            var userToken = (UserToken) showMessage;
            _tokenText.text = "Token: " + userToken.Token;
            _expirationTokenText.text = "Expiration Token: " + userToken.Expiration.ToString(CultureInfo.InvariantCulture);
        }  
        private void GetResponse(object obj) => WaitResponse(obj);

        private void SendRequest()
        {
            _behaviorPostRequester.CallRequestMethod<UserToken>( _apiController, LoginModel());  
        } 
        private object LoginModel()
        {
            _loginModel = new LoginModel(_userEmail.text, _userPassword.text);
            return _loginModel;
        }
    }
}