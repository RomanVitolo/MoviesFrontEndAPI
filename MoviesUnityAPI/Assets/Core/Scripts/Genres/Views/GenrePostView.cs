using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Genres
{
    internal class GenrePostView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _genreName; 
        [SerializeField] private TextMeshProUGUI _responseText;
        
        private GenreModel _genreModel;      
        private Button _button;                   
        private IBehaviorPostRequester _behaviorPostRequester;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorPostRequester = new BehaviorPostPostRequester();    
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
        private void SendRequest() => _behaviorPostRequester.CallRequestMethod(GenreModel());    
        
        private object GenreModel()
        {
            _genreModel = new GenreModel(_genreName.text);
            return _genreModel;
        }
    }
}