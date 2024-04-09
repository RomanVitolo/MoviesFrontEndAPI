using System.Threading.Tasks;

namespace Assets.Core.Scripts.Interfaces
{
    internal interface IHttpRequester
    {     
        public Task<T> Get<T>(string endPoint);
        public Task<T> GetId<T>(string endPoint, int id);
        public Task<T> Post<T>(string endPoint, object payload);
        public Task<T> Put<T>(string endPoint, int id, object payload);
        public Task<T> Delete<T>(string endPoint, int id);     
    }     
}
