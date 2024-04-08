using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorRequesterById
    {
        public Task CallRequestMethodById(string apiController, string idType = null);
        public event Action<string> OnGetResult;  
    }
}