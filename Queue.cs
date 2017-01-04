using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class Queue<T> where T:IComparable
    {
        T[] values;
        int rear;
        int front;

        public Queue(int size)
        {
            values = new T[size];
            rear = front = -1;
        }
        public int size()
        {
            return values.Length;

        }
        public bool isEmpty()
        {
            return rear == front;
        }
        public bool isFull()
        {
            return rear == values.Length - 1;
        }
        public void enQueue(T val)
        {
            if (isFull())
                Console.WriteLine("queue is full");
            else
            {
                values[++rear] = val;
            }
        }
        public T deQueue()
        {
            if (isEmpty())
                throw new Exception("queue is empty");
            else
            {
                return values[++front];
            }
        }
        public T peek()
        {
            if (isEmpty())
                throw new Exception("queue is empty");
            else
            {
                return values[front + 1];
            }
        }
        public void display()
        {
            if (isEmpty())
                Console.WriteLine("queue is empty");
            else
            {
                for (int i = front + 1; i <= rear; i++)
                {
                    Console.WriteLine(values[i]);
                }
            }
        }
    }
}
