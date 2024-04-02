using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Genres
{
    internal class GenrePutView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _genreName; 
        [SerializeField] private TMP_InputField _IdInput;
        [SerializeField] private TextMeshProUGUI _responseText; 
        
        private GenreModel _genreModel;      
        private Button _button;                   
        private IBehaviorPutRequester _behaviorPutRequester;
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
        private void WaitResponse(string showMessage) => _responseText.text = showMessage;     
        private void GetResponse(string obj) => WaitResponse(obj);        
        private void SendRequest() => _behaviorPutRequester.CallRequestMethod(_IdInput.text, GenreModel());  
        private object GenreModel()
        {
            _genreModel = new GenreModel(_genreName.text);
            return _genreModel;
        } 
    }
}