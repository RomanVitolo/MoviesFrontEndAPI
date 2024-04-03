using System;
using System.Threading.Tasks;
using Assets.Core.Scripts.Interfaces;
using Interfaces;
using ServerSettings;
using SharedLibrary.Interfaces.Entities;
using UnityEngine;

namespace Genres
{
    internal class BehaviorDeleteRequester : IBehaviorRequesterById
    { 
        public event Action<string> OnGetResult;    

        private const string _apiController = "genres";
        private IHttpRequester _httpRequester;
        public async Task CallRequestMethodById(string typeId)
        { 
            _httpRequester = new HttpClient();
           await _httpRequester.Delete<IIdDTO>(string.Concat(GameEngine.Instance.ServerEndpoint, _apiController),
                int.Parse(typeId));              
           OnGetResult?.Invoke($"Gender has been removed with id {typeId}");
        }        
    }
}