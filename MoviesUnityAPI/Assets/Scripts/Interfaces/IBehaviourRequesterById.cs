using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviourRequesterById
    {
        public Task CallRequestMethodById(string idType = null);
    }
}