
namespace imadyNebuEventTestProject
{
    internal class TestObserver: NebuEventInterfaceObjectBase, INebuObserver<TestMessage>
    {
        internal bool testResult = false;
        internal string? testMessage;

        public override TestObserver? AddEventManager(NebuEventManager eventSystem)
        {
            return base.AddEventManager(eventSystem) as TestObserver;
        }

        public void OnNext(TestMessage message)
        {
            testResult = true;
            testMessage = message.senderName;
        }
        
    }
}
