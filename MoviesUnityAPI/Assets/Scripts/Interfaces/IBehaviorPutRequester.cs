using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorPutRequester
    {
        public Task CallRequestMethod(string typeId, object bodyClass);
    }         
}