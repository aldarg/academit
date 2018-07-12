using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lection19
{
    public class Producer
    {
        private readonly ProducerConsumerManager manager;

        public Producer(ProducerConsumerManager manager)
        {
            this.manager = manager;
        }

        public void Produce()
        {
            int itemNumber = 1;

            while (true)
            {
                Thread.Sleep(1500);
                manager.AddItem("item" + itemNumber);
                Console.WriteLine("+item" + itemNumber);
                ++itemNumber;
            }
        }
    }
}
