
namespace imady.NebuEventTestProject
{
    internal class TestProvider: NebuEventInterfaceObjectBase, INebuProvider<TestMessage>
    {
        public override TestProvider? AddEventManager(NebuEventManager eventSystem)
        {
            return base.AddEventManager(eventSystem) as TestProvider;
        }

        public void Notify()
        {
            var message  = new TestMessage();
            base.NotifyObservers(message);
        }
    }
}
