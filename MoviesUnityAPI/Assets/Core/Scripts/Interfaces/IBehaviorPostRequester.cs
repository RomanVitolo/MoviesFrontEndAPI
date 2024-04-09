using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorPostRequester
    {
        public Task CallRequestMethod<T>(string apiController, object bodyClass);
        public event Action<object> OnGetResult;
    }
}