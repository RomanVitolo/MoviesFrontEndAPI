using System.Threading.Tasks;

namespace Assets.Core.Scripts.Interfaces
{
    internal interface IHttpRequester
    {     
        public Task<T> Get<T>(string endPoint, string jwtToken);
        public Task<T> GetId<T>(string endPoint, string jwtToken, int id);
        public Task<T> Post<T>(string endPoint, string jwtToken, object payload);
        public Task<T> Put<T>(string endPoint, string jwtToken, int id, object payload);
        public Task<T> Delete<T>(string endPoint, string jwtToken, int id);     
    }     
}
