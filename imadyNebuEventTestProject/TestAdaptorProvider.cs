using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imady.NebuEventTestProject
{
    internal class TestAdaptorProvider : NebuEventAdaptorObjectBaseExsample, INebuProvider<TestMessage>
    {
        public override TestAdaptorProvider? AddEventManager(NebuEventManager eventSystem)
        {
            return base.AddEventManager(eventSystem) as TestAdaptorProvider;
        }

        public void Notify()
        {
            var message = new TestMessage();
            base.NotifyObservers(message);
        }
    }
}
