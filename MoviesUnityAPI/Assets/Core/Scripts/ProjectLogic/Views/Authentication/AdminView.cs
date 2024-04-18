using System.Globalization;
using Controllers;
using Interfaces;
using Models;
using ServerSettings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Authentication
{
    public class AdminView : MonoBehaviour
    {
        [SerializeField] private ApiControllerSettings _apiController; 
        
        [SerializeField] private TMP_InputField _userId;
        [SerializeField] private TMP_InputField _roleName;
        [SerializeField] private TextMeshProUGUI _messageResponse;
        private Button _giveRoleButton;
      

        private EditRolModel _editRolModel;  
        private IBehaviorPostRequester _behaviorPostRequester;

        private void Awake()
        {
            _behaviorPostRequester = new BehaviorPostRequester();

            _giveRoleButton = GetComponent<Button>();
        }
        
        private void OnEnable()
        {
            _giveRoleButton.onClick.AddListener(SendRequest);
            _behaviorPostRequester.OnGetResult += GetResponse;  
        }

        private void OnDisable()
        {
            _giveRoleButton.onClick.RemoveAllListeners();
            _behaviorPostRequester.OnGetResult -= GetResponse;  
        }          
       
        private void WaitResponse(object showMessage)
        {
            if (showMessage != null)
            {
                var response = (MessageResponseModel) showMessage;
                _messageResponse.text = response.Message;
                _giveRoleButton.interactable = true;
            }
          
        }  
        private void GetResponse(object obj) => WaitResponse(obj);

        private void SendRequest()
        {
            _behaviorPostRequester.CallRequestMethod<MessageResponseModel>( _apiController.ApiControllerCMD,
                EditRolModel());
            ClearUI();
            _giveRoleButton.interactable = false;
        } 
        private object EditRolModel()
        {
            _editRolModel = new EditRolModel(_userId.text, _roleName.text);
            return _editRolModel;
        }

        private void ClearUI()
        {
            _userId.text = string.Empty;
            _roleName.text = string.Empty;
            _messageResponse.text = string.Empty;
        }
    }
}