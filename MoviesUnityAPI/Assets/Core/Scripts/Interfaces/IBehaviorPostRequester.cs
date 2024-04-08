using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorPostRequester
    {
        public Task CallRequestMethod(string apiController, object bodyClass);
        public event Action<string> OnGetResult;
    }
}