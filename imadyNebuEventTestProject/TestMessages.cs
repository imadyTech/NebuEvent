
namespace imadyNebuEventTestProject
{
    internal class TestMessage : NebuMessageBase
    {
        public TestMessage()
        {
            base.senderName = this.GetType().Name;
            base.timeSend = DateTime.Now;
        }
    }
}
