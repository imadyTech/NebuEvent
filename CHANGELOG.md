## Changelog

### Recent Updates - 2024-04-19:

*   **INebuObserver Interface:**
    *   Added `OnNextAsync` method: Introduced a new asynchronous method, `OnNextAsync`, to the `INebuObserver` interface, allowing observers to handle notifications asynchronously. This addition supports non-blocking execution of observer methods.
*   **NebuEventInterfaceObjectBase Class:**
    *   Added `NotifyObserversAsync` method: Implemented a new virtual async method, `NotifyObserversAsync`, to facilitate asynchronous notification of observers. This method parallels the existing `NotifyObservers` method but invokes `OnNextAsync` on observers, enhancing the system's responsiveness.
*   **NebuEventAdaptorObjectBaseExsample Class:**
    *   Added `NotifyObserversAsync` method: Implemented the `NotifyObserversAsync` method in the `NebuEventAdaptorObjectBaseExsample` class, enabling adapted objects to use asynchronous notifications. This method delegates the call to the internal `interfaceEventObject` instance's `NotifyObserversAsync` method.
*   **README.md Update**
    *    Added a new section to explain the project's core concepts, including its relation to Reactive Programming, Event Aggregator/Mediator, Pub/Sub, Message Bus, and its unique features like automatic interface mapping, direct communication, and lightweight design. I also added the aim of supporting Asynchronous, real-time re-mapping, notification filters, unsubscribe, OnError and OnComplete functions.