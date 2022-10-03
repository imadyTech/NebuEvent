namespace imady.NebuEvent
{
    public class NebuServiceMsg : NebuServiceMsgBase<object>
    {
        public NebuServiceMsg()
        {
            base.msg = "";
            base.msgBody = null;
            base.success = false;
        }

        public NebuServiceMsg(bool success): this()
        {
            base.success = success;
        }
        public NebuServiceMsg(string msg) : this()
        {
            base.msg = msg;
        }
        public NebuServiceMsg(string msg, bool success): this(msg)
        {
            base.success = success;
        }

        public NebuServiceMsg(object value) : this()
        {
            base.msgBody = value;
            base.success = true;
        }

        public NebuServiceMsg(object value, string msg) : this(msg)
        {
            base.msgBody = value;
            base.success = true;
        }

    }
}
