
namespace imady.NebuEvent
{
    public class NebuServiceMsgBase<T> 
    {
        public bool success { get; set; }

        public T msgBody { get; set; }

        public string msg { get; set; }
    }

}
