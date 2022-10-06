using Xunit.Abstractions;

namespace imady.NebuEventTestProject
{
    public class NebuEventInterfacObjectTest
    {
        //output the console.writeline result
        private readonly ITestOutputHelper _testOutputHelper;
        public NebuEventInterfacObjectTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        [Fact]
        public void ParameterLessTest()
        {
            //Instantiate a event manager; Please note this manager is only be used at the time of mapping providers/observers;
            //After that, providers are sending messages to the observers directly without manager's intervene.
            var manager = new NebuEventManager();

            //Providers and observers must use the AddEventManager method to register mapping.
            //However the eventManager will NOT be referred by the providers (of course you may change this if you like to).
            var provider = new TestProvider()
                .AddEventManager(manager);
            var observer = new TestObserver()
                .AddEventManager(manager);

            //There will be one-off mapping after all providers/observers registered to the manager.
            //This could be a drawback if additional providers/observers are instantiated after the application initialization.
            //You may definitely improve that!
            manager.MappingEventObjectsByInterfaces();

            //If the observer instance is subscribed to the provider, the observer.testResult should has a value of true.
            provider?.Notify();

            Assert.True(observer?.testResult);
        }

        [Fact]
        public void WithParameterTest()
        {
            var manager = new NebuEventManager();

            var provider = new TestProvider()
                .AddEventManager(manager);
            var observer = new TestObserver()
                .AddEventManager(manager);

            manager.MappingEventObjectsByInterfaces();

            //If the observer instance is subscribed to the provider, the observer.testResult should has a value of true.
            provider?.NotifyObservers(new TestMessage()
            {
                senderName = "WithParameterTest"
            });

            Assert.Equal("WithParameterTest", observer?.testMessage);

        }

        [Fact]
        public void AdpatorPatternTest()
        {
            var manager = new NebuEventManager();

            var provider = new TestAdaptorProvider()
                .AddEventManager(manager);
            Assert.NotNull(provider);   
            var observer = new TestAdaptorObserver()
                .AddEventManager(manager);
            Assert.NotNull(observer);

            manager.MappingEventObjectsByInterfaces();

            //If the observer instance is subscribed to the provider, the observer.testResult should has a value of true.
            provider?.NotifyObservers(new TestMessage()
            {
                senderName = "WithParameterTest"
            });

            Assert.Equal("WithParameterTest", observer?.testMessage);

        }
    }
}