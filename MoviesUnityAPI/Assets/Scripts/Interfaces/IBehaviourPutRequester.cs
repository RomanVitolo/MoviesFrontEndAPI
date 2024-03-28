using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviourPutRequester
    {
        public Task CallRequestMethod(int id, object bodyClass);
    }         
}