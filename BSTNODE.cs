using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class BSTNODE<T> where T:IComparable
    {
        /*    ___ ___________ ____
         *   |   |           |    | 
         *   |   |           |    |
         *   |   |           |    |
         *   |   |           |    |
         *   |   |  BSTNODE  |    |
         *   |   |           |    |
         *   |   |           |    |
         *   |___|___________|____|
         *   LEFT    VALUE    RIGHT  
         *   
         */
        T value;
        BSTNODE<T> left, right;
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
        internal BSTNODE<T> Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }
        internal BSTNODE<T> Right
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }
        public BSTNODE(T value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
}
