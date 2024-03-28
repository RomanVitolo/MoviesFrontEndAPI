using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Genres
{
    internal class GenrePutView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _genreName; 
        [SerializeField] private TMP_InputField _genreId; 
        
        private GenreModel _genreModel;      
        private Button _button;                   
        private IBehaviorPutRequester _behaviorPutRequester;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _behaviorPutRequester = new BehaviorPutRequester();
            if (_genreName == null) FindObjectOfType<TMP_InputField>();     
            _button.onClick.AddListener(SendRequest);   
        }              
        private void SendRequest()
        {
            _behaviorPutRequester.CallRequestMethod(_genreId.text, GenreModel());          
        }

        private object GenreModel()
        {
            _genreModel = new GenreModel(_genreName.text);
            return _genreModel;
        } 
    }
}