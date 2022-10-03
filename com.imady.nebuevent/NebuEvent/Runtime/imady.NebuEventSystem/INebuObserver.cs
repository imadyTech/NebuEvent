using System;

namespace imady.NebuEvent
{
    public interface INebuObserver<T> : INebuEventObjectBase where T : NebuMessageBase
    {
        void OnCompleted();

        void OnError(Exception ex);

        void OnNext(T message);
    }
}
