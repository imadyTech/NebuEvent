# imady NebuEvent System
A Message-Orientated mini event system (Sync) for small size applications.

## Core Concept

NebuEvent is an implementation of Reactive Programming, and shares characteristics with several established event and messaging systems. It is most closely aligned with the **Event Aggregator/Mediator pattern**, **Pub/Sub systems**, and the concept of **Message Bus**, but it has its own unique flavor with the automatic interface mapping.

**Key factors of the core:**

*   **Direct Communication:** Providers and observers communicate directly without a central messaging hub after the initial setup.
*   **Automatic Interface-Based Mapping:**  Interfaces are automatically used to map providers to their corresponding observers.
*   **Central Manager for Setup:** A central manager is used to define and establish the mappings between providers and observers.
*   **Lightweight:** The system is designed to be lightweight with minimal overhead.
*   **No Dependency Injection (but similar effect):**  It achieves the benefits of dependency injection without requiring a full dependency injection framework.
*   **Reduced Complexity and Maintenance:** It aims to reduce project complexity and the associated maintenance costs.

**Future Goals:**

*   **Asynchronous Support:**  Extending the system to support asynchronous communication.
*   **Real-time Re-mapping:** Allowing for mappings to be changed dynamically at runtime.
*   **Advanced Features:** Including notification filters, unsubscribe mechanisms, and OnError/OnComplete functions.
--------------
You may refer to the sample code in the testing project:

            //Instantiate a event manager; Please note this manager is only be used at the time of mapping providers/observers;
            //After that, providers are sending messages to the observers directly without manager's intervene.
            var manager  = new NebuEventManager();

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
-----------------
