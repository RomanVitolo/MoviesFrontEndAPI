using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Genres
{
    internal class GenrePostView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _genreName; 
        
        private GenreModel _genreModel;      
        private Button _button;                   
        private IBehaviorPostRequester _behaviorPostRequester;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorPostRequester = new BehaviorPostPostRequester();
            if (_genreName == null) FindObjectOfType<TMP_InputField>();     
            _button.onClick.AddListener(SendRequest);   
        }              
        private void SendRequest()
        {
            _behaviorPostRequester.CallRequestMethod(GenreModel());          
        }

        private object GenreModel()
        {
            _genreModel = new GenreModel(_genreName.text);
            return _genreModel;
        }
    }
}