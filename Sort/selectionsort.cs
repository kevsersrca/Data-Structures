public void selectionSort()
        {
            DNode<T> iterator=head,min=head;

            while (min.Next != null)
            {
                iterator = min;
                while(iterator.Next!=null)
                {
                    if(iterator.Value.CompareTo(min.Value)==-1)
                    {
                        iterator.Next.Prev = iterator.Prev;
                        iterator.Prev.Next = iterator.Next;
                        iterator.Next = head;
                        head.Prev = iterator;
                        head = iterator;
                    }
                    iterator = iterator.Next;
                }
                min = min.Next;
            }
        }
