using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Controllers;
using Models;
using SharedLibrary.Interfaces.Entities;

namespace Views.Genres
{
    internal class GenrePostView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _genreName; 
        [SerializeField] private TextMeshProUGUI _responseText;
        
        private IGenreDTO _genrePostModel;      
        private Button _button;                   
        private IBehaviorPostRequester _behaviorPostRequester;

        private const string _apiController = "genres";
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
            var genre = (GenreModel) showMessage;
            _responseText.text = $"Id: {genre.Id}\n\nName: {genre.Name}";
        }     
        private void GetResponse(object obj) => WaitResponse(obj);  
        private void SendRequest() => _behaviorPostRequester.CallRequestMethod<GenreModel>( _apiController, GenreModel());    
        
        private object GenreModel()
        {
            _genrePostModel = new GenreModel(_genreName.text);
            return _genrePostModel;
        }
    }
}