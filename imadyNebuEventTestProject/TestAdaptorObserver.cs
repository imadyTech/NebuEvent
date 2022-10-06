using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imady.NebuEventTestProject
{
    internal class TestAdaptorObserver : NebuEventAdaptorObjectBaseExsample, INebuObserver<TestMessage>
    {
        internal bool testResult = false;
        internal string? testMessage;

        public override TestAdaptorObserver? AddEventManager(NebuEventManager eventSystem)
        {
            return base.AddEventManager(eventSystem) as TestAdaptorObserver;
        }

        public void OnNext(TestMessage message)
        {
            testResult = true;
            testMessage = message.senderName;
        }

    }
}

