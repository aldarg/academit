using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lection19
{
    public class Consumer
    {
        private readonly ProducerConsumerManager manager;

        public Consumer(ProducerConsumerManager manager)
        {
            this.manager = manager;
        }

        public void Consume()
        {
            while (true)
            {
                string item = manager.GetItem();
                Thread.Sleep(2500);
                Console.WriteLine("-" + item);
            }
        }
    }
}
