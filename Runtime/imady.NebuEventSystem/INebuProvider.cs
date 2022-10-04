
using imady.NebuEvent;

namespace imady.NebuEvent
{
    public interface INebuProvider<T> : INebuEventObjectBase where T : NebuMessageBase
    {
        new void Subscribe(INebuEventObjectBase observer);

    }

}