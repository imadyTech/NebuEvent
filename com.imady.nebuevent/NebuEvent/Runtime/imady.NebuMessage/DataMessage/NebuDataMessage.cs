using Newtonsoft.Json;

namespace imady.NebuEvent
{
    /// <summary>
    /// Messages from DataService 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NebuDataMessage<T> : NebuMessageBase 
    {
        public virtual T messageBody { get; set; }


        public NebuDataMessage() { }

        public NebuDataMessage(T messageBody)
        {
            this.messageBody = messageBody;
        }
    }

}
