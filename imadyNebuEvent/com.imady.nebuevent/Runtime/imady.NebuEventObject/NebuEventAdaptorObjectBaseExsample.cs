using System;
using System.Collections.Generic;
using System.Text;

namespace imady.NebuEvent
{
    public class SomeBaseClass
    {

    }

    /// <summary>
    /// In case your class is not able to inheritate from an INebuEventObjectBase class 
    /// (e.g. for an Unity gameObject that inheritates MonoBehaviour),
    /// you may still implement your NebuEventObject with the adaptor pattern.
    /// </summary>
    public class NebuEventAdaptorObjectBaseExsample : SomeBaseClass, INebuEventObjectBase
    {
        NebuEventInterfaceObjectBase interfaceEventObject;

        public NebuEventAdaptorObjectBaseExsample()
        {
            this.interfaceEventObject = new NebuEventInterfaceObjectBase(this.GetType());
        }

        public bool isProvider => interfaceEventObject.isProvider;

        public bool isObserver => interfaceEventObject.isObserver;

        public IEnumerable<Type> providerInterfaces => interfaceEventObject.providerInterfaces;

        public IEnumerable<Type> observerInterfaces => interfaceEventObject.observerInterfaces;

        /// <summary>
        /// Some difference to 
        /// </summary>
        /// <param name="eventSystem"></param>
        /// <returns></returns>
        public virtual INebuEventObjectBase AddEventManager(NebuEventManager eventSystem)
        {
            eventSystem.Register(this);
            return this;
        }

        public bool isObservingMessage(Type interfaceType)=> interfaceEventObject.isObservingMessage(interfaceType);

        public void NotifyObservers(NebuMessageBase message) => interfaceEventObject.NotifyObservers(message);

        public void Subscribe(INebuEventObjectBase observer) => interfaceEventObject.Subscribe(observer);
    }
}
