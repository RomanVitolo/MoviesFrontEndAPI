using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorRequesterById
    {
        public Task CallRequestMethodById<T>(string apiController, string idType = null);
        public event Action<object> OnGetResult;  
    }            
}