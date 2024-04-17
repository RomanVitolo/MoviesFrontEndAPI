using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Controllers;
using Models;

namespace Views.Genres
{
    internal class GenrePutView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _genreName; 
        [SerializeField] private TMP_InputField _IdInput;
        [SerializeField] private TextMeshProUGUI _responseText; 
        
        private GenreModel _genreModel;      
        private Button _button;                   
        private IBehaviorPutRequester _behaviorPutRequester;
        
        private const string _apiController = "genres";
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorPutRequester = new BehaviorPutRequester();      
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(SendRequest);  
            _behaviorPutRequester.OnGetResult += GetResponse;   
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
            _behaviorPutRequester.OnGetResult -= GetResponse;   
        }

        private void WaitResponse(object showMessage)
        {
            var response = (MessageResponse) showMessage;
            _responseText.text = response.Message;
        }     
        private void GetResponse(object obj) => WaitResponse(obj);

        private void SendRequest()
        {
            _behaviorPutRequester.CallRequestMethod<MessageResponse>(_apiController, _IdInput.text, GenreModel());
            ClearUI(); 
        } 
        private object GenreModel()
        {
            _genreModel = new GenreModel(_genreName.text);
            return _genreModel;
        } 
        
        private void ClearUI()
        {
            _genreName.text = string.Empty;
            _IdInput.text = string.Empty;
            _responseText.text = string.Empty;
        }
    }
}