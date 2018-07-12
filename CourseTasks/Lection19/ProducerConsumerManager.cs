using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lection19
{
    public class ProducerConsumerManager
    {
        private List<string> warehouse = new List<string>(10);
        private object obj = new object();
        private const int CAPACITY = 5;
        private const int PRODUCER_COUNT = 2;
        private const int CONSUMER_COUNT = 2;

        public void Run()
        {
            for (int i = 1; i <= PRODUCER_COUNT; ++i)
            {
                Thread producer = new Thread(new Producer(this).Produce);
                producer.Start();
            }

            for (int i = 1; i <= CONSUMER_COUNT; ++i)
            {
                Thread consumer = new Thread(new Consumer(this).Consume);
                consumer.Start();
            }
        }

        public void AddItem(string item)
        {
            lock(obj)
            {
                while (warehouse.Count >= CAPACITY)
                {
                    Monitor.Wait(obj);
                }

                warehouse.Add(item);
                Monitor.PulseAll(obj);
            }
        }

        public string GetItem()
        {
            lock(obj)
            {
                while (warehouse.Count <= 0)
                {
                    Monitor.Wait(obj);
                }

                string item = warehouse[warehouse.Count - 1];
                warehouse.RemoveAt(warehouse.Count - 1);
                Monitor.PulseAll(obj);

                return item;
            }
        }
    }
}
