using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBehaviorPostRequester
    {
        public Task CallRequestMethod(object bodyClass);
    }
}