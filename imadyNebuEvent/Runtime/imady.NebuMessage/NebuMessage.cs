
namespace imady.NebuEvent
{
    public class NebuMessage<T> : NebuMessageBase where T : class
    {
        public virtual T messageBody { get; set; }

        public NebuMessage(T message)
        {
            messageBody = message;
        }
    }
}

