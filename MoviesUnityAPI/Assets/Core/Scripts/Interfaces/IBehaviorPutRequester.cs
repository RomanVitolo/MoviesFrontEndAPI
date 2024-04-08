using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorPutRequester
    {
        public Task CallRequestMethod(string apiController, string typeId, object bodyClass);
        public event Action<string> OnGetResult;
    }         
}