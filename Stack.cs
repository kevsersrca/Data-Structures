using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class Stack<T>
    {
        T[] values;
        int top;

        public Stack(int size)
        {
            values = new T[size];
            top = -1;
        }
        public void clear()
        {
            top = -1;
        }

        public int size()
        {
            return values.Length;
        }
        public bool isEmpty()
        {
            if (top == -1)
                return true;
            else
                return false;
        }
        public bool isFull()
        {
            if (top == values.Length - 1)
                return true;
            else
                return false;
        }

        public void push(T val)
        {
            if (isFull())
                //throw new Exception("stack is full");
                Console.WriteLine("stack is full");
            else
            {
                values[++top] = val;
            }
        }

        public T pop()
        {
            if (isEmpty())
            {
                throw new Exception("stack is empty");
            }
            else
            {
                top--;
                return values[top + 1];
            }
        }

        public T peek()
        {
            if (top == -1)
                throw new Exception("stack is empty");
            return values[top];

        }

        public void display()
        {
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(values[i]);
            }
            Console.WriteLine();
        }
    }
}
