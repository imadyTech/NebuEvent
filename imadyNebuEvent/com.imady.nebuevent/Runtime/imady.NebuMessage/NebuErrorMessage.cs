
namespace imady.NebuEvent
{
    public class NebuErrorMessage<T> : NebuMessageBase where T : class
    {
        public T messageBody { get; set; }

        public NebuErrorMessage(T message)
        {
            messageBody = message;
        }
    }
}
