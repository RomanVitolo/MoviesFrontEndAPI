using System.Globalization;
using Controllers;
using Interfaces;
using Models;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Views.Authentication
{
    public class AuthenticationView : MonoBehaviour
    {
        [SerializeField] private ApiControllerSettings _apiController;
        
        [SerializeField] private TMP_InputField _userEmail;
        [SerializeField] private TMP_InputField _userPassword;
        [SerializeField] private TextMeshProUGUI _tokenText;
        [SerializeField] private TextMeshProUGUI _expirationTokenText;
        [SerializeField] private Button _loginButton;
        [SerializeField] private Button _copyButton;
        [SerializeField] private Button _pasteButton;

        private IUserInfo _loginModel;  
        private IBehaviorPostRequester _behaviorPostRequester;

        private void Awake()
        {
            _behaviorPostRequester = new BehaviorPostRequester();

            _copyButton.interactable = false;
            _pasteButton.interactable = false;
        }
        
        private void OnEnable()
        {
            _loginButton.onClick.AddListener(SendRequest);   
            _copyButton.onClick.AddListener(CopyTextButton);   
            _pasteButton.onClick.AddListener(PasteTextButton);   
            _behaviorPostRequester.OnGetResult += GetResponse;  
        }

        private void OnDisable()
        {
            _loginButton.onClick.RemoveAllListeners();
            _copyButton.onClick.RemoveAllListeners();
            _pasteButton.onClick.RemoveAllListeners();
            _behaviorPostRequester.OnGetResult -= GetResponse;  
        }          
        
        private void CopyTextButton()
        {
            var text = _tokenText.text;
            ExtensionUtilityClass.CopyText(text);
            _pasteButton.interactable = true;
        }
        
        private void PasteTextButton()
        {
            ExtensionUtilityClass.PasteText();
        }
        
        private void WaitResponse(object showMessage)
        {
            if (showMessage != null)
            {
                var userToken = (UserToken) showMessage;
                _tokenText.text = "Token: " + userToken.Token;
                _expirationTokenText.text = "Expiration Token: " + userToken.Expiration.ToString(CultureInfo.InvariantCulture);
                _copyButton.interactable = true;
            }
          
        }  
        private void GetResponse(object obj) => WaitResponse(obj);

        private void SendRequest()
        {
            _behaviorPostRequester.CallRequestMethod<UserToken>( _apiController.ApiControllerCMD, LoginModel());
            ClearUI();
        } 
        private object LoginModel()
        {
            _loginModel = new UserInfoModel(_userEmail.text, _userPassword.text);
            return _loginModel;
        }

        private void ClearUI()
        {
            _userEmail.text = string.Empty;
            _userPassword.text = string.Empty;
            _tokenText.text = string.Empty;
            _expirationTokenText.text = string.Empty;
            _copyButton.interactable = false;
        }
    }
}