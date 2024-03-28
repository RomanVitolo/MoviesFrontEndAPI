using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviourPostRequester
    {
        public Task CallRequestMethod(object bodyClass);
    }
}