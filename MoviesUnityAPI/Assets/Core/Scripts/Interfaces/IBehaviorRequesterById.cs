using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorRequesterById
    {
        public Task CallRequestMethodById(string idType = null);
        public event Action<string> OnGetResult;  
    }
}