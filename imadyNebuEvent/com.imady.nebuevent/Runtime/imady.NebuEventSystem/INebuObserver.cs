using System.Threading.Tasks;

namespace imady.NebuEvent
{
    public interface INebuObserver<T> : INebuEventObjectBase where T : NebuMessageBase
    {
        void OnNext(T message);
        Task OnNextAsync(T message);
    }
}
