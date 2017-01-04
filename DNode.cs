using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class DNode<T> where T:IComparable
    {
        T value;
        DNode<T> next;
        DNode<T> prev;

        public DNode(T value)
        {
            this.value = value;
            this.next = null;
            this.prev = null;
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

        internal DNode<T> Next
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

        internal DNode<T> Prev
        {
            get
            {
                return prev;
            }

            set
            {
                prev = value;
            }
        }
    }
}
