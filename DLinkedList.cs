using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class DLinkedList<T> where T:IComparable
    {
        DNode<T> head;
        public void AddToFront(T val)
        {
            DNode<T> newNode = new DNode<T>(val);

            if (head == null)
                head = newNode;
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
        }
        public void AddToEnd(T val)
        {
            DNode<T> newNode = new DNode<T>(val);
            DNode<T> iterator = head;

            if (head == null)
                head = newNode;
            else
            {
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = newNode;
                newNode.Prev = iterator;
            }
        }
        public void DeleteLast()
        {
            DNode<T> iterator = head;

            if (head == null || head.Next == null)
                head = null;
            else
            {
                while (iterator.Next != null)
                    iterator = iterator.Next;
                iterator.Prev.Next = null;
                iterator.Prev = null;
                iterator = null;
            }
        }
        public bool Search(T val)
        {
            DNode<T> iterator = head;
            if (head == null)
                return false;
            else
            {
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) == 0)
                    {
                        return true;
                    }
                    iterator = iterator.Next;
                }
                return false;
            }
        }
        public void Display()
        {
            DNode<T> iterator = head;
            while (iterator != null)
            {
                Console.Write(iterator.Value + " ");
                iterator = iterator.Next;
            }
            Console.WriteLine();
        }
        public void DisplayReverse()
        {
            if (head == null)
                return;
            DNode<T> iterator = head;
            while (iterator.Next != null)
            {
                iterator = iterator.Next;
            }

            while (iterator != null)
            {
                Console.Write(iterator.Value + " ");
                iterator = iterator.Prev;
            }

            Console.WriteLine();
        }
        public void AddToOrderedList(T val)
        {
            DNode<T> newNode = new DNode<T>(val);
            DNode<T> iterator = head;
            if (head == null)
                head = newNode;
            else
            {
                if (head.Value.CompareTo(val) > 0)
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
                else
                {
                    while (iterator.Next != null && iterator.Next.Value.CompareTo(val) <= 0)
                    {
                        iterator = iterator.Next;
                    }

                    newNode.Next = iterator.Next;
                    if (iterator.Next != null)
                        iterator.Next.Prev = newNode;
                    iterator.Next = newNode;
                    newNode.Prev = iterator;
                }
            }
        }
        public void Delete(T val)
        {
            DNode<T> iterator = head;
            if (head == null)
                Console.WriteLine("This linked list is empty!!!");
            else
            {
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) == 0)
                    {
                        if (iterator.Prev == null && iterator.Next == null)//tek elemanlıysa
                        {
                            head = null;
                        }
                        else if (iterator.Prev == null)// head ise ve tek degılse
                        {
                            head = iterator.Next;
                            head.Prev = null;
                        }
                        else if (iterator.Next == null)// son elemansa
                        {
                            iterator.Prev.Next = null;
                        }
                        else//ara elemansa
                        {
                            iterator.Prev.Next = iterator.Next;
                            iterator.Next.Prev = iterator.Prev;
                        }
                        break;
                    }
                    else
                        iterator = iterator.Next;
                }
            }
        }
    }
}
