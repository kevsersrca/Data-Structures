using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class CQueue<T> where T:IComparable
    {
        T[] values;
        int front=-1, rear=-1;

        public CQueue(int size)
        {
            values = new T[size];
        }
        public int size()
        {
            return values.Length;
        }
        public bool isEmpty()
        {
            return front == rear;
        }
        public bool isFull()
        {
            return (rear + 1) % size() == front;
        }
        public void enQueue(T val)
        {
            if (isFull())
            {
                Console.WriteLine("Queue ıs full");
                return;
            }
            values[++rear % size()] = val;
        }
        public T deQueue()
        {
            if (isEmpty())
                throw new Exception("Queue ıs empty");

            return values[++front % size()];
        }
        public void display()
        {
            if (!isEmpty())
            {
                int i = (front + 1) % size();

                while (i != (rear + 1) % size())
                {
                    Console.WriteLine(values[i]);
                    i = (i + 1) % size();
                }

            }

        }
    }
}
