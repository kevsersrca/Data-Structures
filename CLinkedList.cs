    class CLinkedList<T> where T:IComparable
    {
        DNode<T> head;
        DNode<T> tail;
        public void addToFront(T val)
        {
            DNode<T> newNode = new DNode<T>(val);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                head.Prev = tail;
                tail.Next = head;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                head = newNode;
            }
        }
        public void addToEnd(T val)
        {
            if (head == null)
            {
                addToFront(val);
            }
            else
            {
                DNode<T> newNode = new DNode<T>(val);
                newNode.Prev = tail;
                tail.Next = newNode;
                head.Prev = newNode;
                newNode.Next = head;
                tail = newNode;
            }
        }
        public void deleteFirst()
        {
            if (head == null)
                return;
            else if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Prev = tail;
                tail.Next = head;
            }
        }
        public void deleteLast()
        {
            if (head == null)
                return;
            else if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = head;
                head.Prev = tail;
            }
        }
        public int size()
        {
            if (head == null)
                return 0;
            else
            {
                DNode<T> iterator = head;
                int sayac = 1;
                while (iterator != tail)
                {
                    iterator = iterator.Next;
                    sayac++;
                }
                return sayac;
            }
        }
        public void display()
        {
            if (head != null)
            {
                DNode<T> iterator = head;

                while (iterator != tail)
                {
                    Console.Write(iterator.Value + " ");
                    iterator = iterator.Next;
                }

                Console.WriteLine(iterator.Value);
            }
        }
        public void delete(T val)
        {
            if (head == null)
                return;
            else if (head == tail && head.Value.CompareTo(val) == 0)
            {
                head = null;
                tail = null;
            }
            else if (head.Value.CompareTo(val) == 0)
            {
                deleteFirst();
                delete(val);
            }
            else if (tail.Value.CompareTo(val) == 0)
            {
                deleteLast();
                delete(val);
            }
            else
            {
                DNode<T> iterator = head;
                while (iterator != tail)
                {
                    iterator = iterator.Next;
                    if (iterator.Value.CompareTo(val) == 0)
                    {
                        iterator.Prev.Next = iterator.Next;
                        iterator.Next.Prev = iterator.Prev;
                    }
                }
            }
        }
    }