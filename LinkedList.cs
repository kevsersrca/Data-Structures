using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class LinkedList<T> where T:IComparable
    {
        Node<T> head;
        //linkedlistin önüne ekleme methodu
        public void addToFront(T val)
        {
            Node<T> newNode = new Node<T>(val);
            newNode.Next = head;
            head = newNode;
        }
        //Linkedlistin sonuna ekleme methodu
        public void addToEnd(T val)
        {
            Node<T> newNode = new Node<T>(val);
            if (head == null)
                head = newNode;
            else
            {
                Node<T> iterator = head;
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = newNode;
            }
        }
        //Son elemanı silme
        public void deleteLast()
        {
            if (head == null || head.Next==null)
                return;
            else
            {
                Node<T> iterator = head, prev = head;
                while (iterator.Next != null)
                {
                    prev = iterator;
                    iterator = iterator.Next;
                }
                prev.Next = null;
            }
        }
        //Linkedlistteki elemanları listeleme
        public void display()
        {
            Node<T> iterator = head;
            while (iterator != null)
            {
                Console.WriteLine(iterator.Value);
                iterator = iterator.Next;
            }
        }
        //Linkedliste eleman arama
        public void search(T val)
        {
            int flag = 0;
            Node<T> iterator = head;
            if (head == null)
                Console.WriteLine("The linked list is empty!!!");
            else
            {
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) == 0)
                    {
                        flag++;
                        break;
                    }
                    else
                        iterator = iterator.Next;
                }
                if (flag != 0)
                    Console.WriteLine("The linked list includes {0}", val);
                else
                    Console.WriteLine("The linked list doesn't include {0}", val);
            }
        }
        //Sıralı olarak ekleme methodu
        public void addToOrderedList(T val)
        {
            Node<T> newNode = new Node<T>(val);
            Node<T> iterator = head;
            if (head == null)
                head = newNode;
            else
            {
                if (head.Value.CompareTo(val) > 0)
                {
                    newNode.Next = head;
                    head = newNode;
                }
                else
                {
                    while (iterator.Next != null && iterator.Next.Value.CompareTo(val) <= 0)
                    {
                        iterator = iterator.Next;
                    }
                    newNode.Next = iterator.Next;
                    iterator.Next = newNode;
                }
            }
        }
        
    }
}
