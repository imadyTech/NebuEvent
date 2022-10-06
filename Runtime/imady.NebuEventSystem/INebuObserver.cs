using System;

namespace imady.NebuEvent
{
    public interface INebuObserver<T> : INebuEventObjectBase where T : NebuMessageBase
    {
        void OnNext(T message);
    }
}
