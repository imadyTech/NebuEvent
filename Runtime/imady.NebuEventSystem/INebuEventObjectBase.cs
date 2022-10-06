using System;
using System.Collections.Generic;
using System.Reflection;

namespace imady.NebuEvent
{
    public interface INebuEventObjectBase
    {
        /// <summary>
        /// Indicator of whether an eventObject is PROVIDING any messages.
        /// </summary>
        bool isProvider { get; }

        /// <summary>
        /// Indicator of whether an eventObject is OBSERVING any messages.
        /// </summary>
        bool isObserver { get; }

        /// <summary>
        /// the collection of message types that an eventObject is providing.
        /// </summary>
        IEnumerable<Type> providerInterfaces { get; }

        /// <summary>
        /// the collection of message types that an eventObject is observing.
        /// </summary>
        IEnumerable<Type> observerInterfaces { get; }

        /// <summary>
        /// This is no longer used.
        /// </summary>
        //Func<Type, bool> providerTester { get; }
        /// <summary>
        /// This is no longer used.
        /// </summary>
        //Func<Type, bool> observerTester { get; }



        /// <summary>
        /// Indicates whether this EventObject is observing a certain type message.
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        bool isObservingMessage(Type interfaceType);


        /// <summary>
        /// Subscribe an observer instance for later notification.
        /// 2021-07-22 Update: 改进了过去由dynamic方式执行消息注册的缺陷
        /// </summary>
        /// <param name="observer"></param>
        void Subscribe(INebuEventObjectBase observer);


        /// <summary>
        /// Notify the observers (same as the OnNext function in Microsoft's provider/observer pattern example.)
        /// </summary>
        /// <param name="message"></param>
        void NotifyObservers(NebuMessageBase message);


        /// <summary>
        /// Adding to the EventSystem manager for later batch mapping.
        /// </summary>
        /// <param name="eventSystem"></param>
        /// <returns></returns>
        INebuEventObjectBase AddEventManager(NebuEventManager eventSystem);
    }
}