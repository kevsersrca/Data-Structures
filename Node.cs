using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class Node<T> where T:IComparable
    {
        T value;
        Node<T> next;

        public Node(T val)
        {
            this.value = val;
            this.next = null;
        }

        public T Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        internal Node<T> Next
        {
            get
            {
                return next;
            }

            set
            {
                next = value;
            }
        }
    }
}
