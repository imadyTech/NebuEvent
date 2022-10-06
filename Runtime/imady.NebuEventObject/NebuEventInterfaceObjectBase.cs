using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace imady.NebuEvent
{
    /// <summary>
    /// 消息系统物体的基类（以对象的IProvider/IObserver接口来判断是否监听某种类型的消息）。
    /// The base of eventObjects implemented through object's INebuProvider/INebuObserver interfaces.
    /// Alternative 1: You may also implenment the INebuEventObjectBase interface by maintaining a provider/observer collection inside a certain eventObject.
    /// Alternative 2: You may also implenment the INebuEventObjectBase interface by reading certain attributes (e.g. ObservingMessage).
    /// </summary>
    public class NebuEventInterfaceObjectBase : INebuEventObjectBase
    {
        /// <summary>
        /// The historical log of subscriptions from any observers to providers.
        /// </summary>
        public static string SubscribeLog = string.Empty;

        //public static string MessageLog = string.Empty;

        /// <summary>
        /// This parameter is used in providing/observing relationship mapping.
        /// It will use GetType() method to acquire this parameter when an eventObject is parameterless constructed;
        /// Otherwisse the contructive parameter is used.
        /// </summary>
        public Type eventObjectType { get; }

        protected List<INebuEventObjectBase> observers;

        /// <summary>
        /// The case your provider/observer inheritates from NebuEventInterfaceObjectBase: Do nothing.
        /// </summary>
        public NebuEventInterfaceObjectBase()
        {
            observers = new List<INebuEventObjectBase>();
            eventObjectType = this.GetType();
        }

        /// <summary>
        /// The case your provider/observer does NOT inheritate from NebuEventInterfaceObjectBase: 
        /// You need implement your class with adaptor pattern and pass in a type parameter,
        /// or simply implement the INebuEventObjectBase interface by yourself and ignore this implementation.
        /// </summary>
        /// <param name="type"></param>
        public NebuEventInterfaceObjectBase(Type type)
        {
            observers = new List<INebuEventObjectBase>();
            eventObjectType = type;
        }



        #region IEVENTSYSTEM METHODS IMPLEMENTATION
        //--------------------------------

        public virtual INebuEventObjectBase AddEventManager(NebuEventManager eventSystem)
        {
            eventSystem.Register(this);
            return this;
        }

        /// <summary>
        /// Unsubscriber实际上还没实现
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected class Unsubscriber<T> : IDisposable where T : INebuEventObjectBase
        {
            private List<T> _observers;
            private T _observer;

            public Unsubscriber(List<T> observers, T observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
        #endregion


        #region IMdyEventObjectBase supporting features 
        public bool isProvider => providerInterfaces.Count() > 0;

        public bool isObserver => observerInterfaces.Count() > 0;

        public IEnumerable<Type> providerInterfaces => eventObjectType.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INebuProvider<>));

        public IEnumerable<Type> observerInterfaces => eventObjectType.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INebuObserver<>));

        public Func<Type, bool> providerTester => new Func<Type, bool>(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(INebuProvider<>));

        public Func<Type, bool> observerTester => new Func<Type, bool>(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(INebuObserver<>));

        public bool isObservingMessage(Type observingMessageType)
        {
            var result = observerInterfaces.SelectMany(i => i.GetGenericArguments()).Contains(observingMessageType);
            return result;
        }
        #endregion


        #region IMdyEventObjectBase Subscribe/Notify
        /// <summary>
        /// Subscribe a new observer.
        /// </summary>
        /// <param name="observer"></param>
        public void Subscribe(INebuEventObjectBase observer)
        {
            //遍历自己的providers
            foreach (var providerInterface in providerInterfaces.SelectMany(i => i.GetGenericArguments()))
            {
                if (observer.isObservingMessage(providerInterface) && !observers.Contains(observer))
                {
                    SubscribeLog += ($"[Subscribe]: {this.ToString()}: {providerInterface.Name} <--> {observer.GetType().Name}\n");
                    //Add to the observer list if true
                    this.observers.Add(observer);
                }
            }
        }

        /// <summary>
        /// 通知消息所有的相关监听者（等同于观察者模式的OnCompleted）; 
        /// Notify all the observers;
        /// TODO: 设计MessagePool以提升运行效率。
        /// TODO: the methodInfo from reflection very likely reduced the performance. Modify the design of the obervers List to improve.
        /// TODO: the message instance is not disposed in current implementation. In the case of large volume application, You need either GC the messages
        /// or use a message pooling design for improvement.
        /// </summary>
        /// <param name="message"></param>
        public virtual void NotifyObservers(NebuMessageBase message)
        {
            Type messaggeType = message.GetType();
            var prospectedObservers = observers.Where(o => o.isObservingMessage(messaggeType)).ToList();

            foreach (var observer in prospectedObservers)
            {
                MethodInfo methodinfo = observer.GetType().GetMethod("OnNext", new Type[] { messaggeType });
                if (methodinfo != null)
                    methodinfo.Invoke(observer, new object[] { message });
            }
        }
        #endregion
    }
}