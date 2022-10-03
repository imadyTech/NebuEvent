namespace imadyNebuEventTestProject
{
    public class NebuEventInterfacObjectTest
    {
        [Fact]
        public void ParameterLessTest()
        {
            var manager  = new NebuEventManager();

            var provider = new TestProvider()
                .AddEventManager(manager);
            var observer = new TestObserver()
                .AddEventManager(manager);

            manager.MappingEventObjectsByInterfaces();

            //If the observer instance is subscribed to the provider, the observer.testResult should has a value of true.
            provider?.Notify();

            Assert.True(observer?.testResult);
        }

        [Fact]
        public void WithParameterTest()
        {
            var manager  = new NebuEventManager();

            var provider = new TestProvider()
                .AddEventManager(manager);
            var observer = new TestObserver()
                .AddEventManager(manager);

            manager.MappingEventObjectsByInterfaces();

            //If the observer instance is subscribed to the provider, the observer.testResult should has a value of true.
            provider?.NotifyObservers(new TestMessage()
            {
                 senderName= "WithParameterTest"
            });

            Assert.Equal("WithParameterTest", observer?.testMessage);

        }
    }
}