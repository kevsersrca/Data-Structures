using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExample
{
    class StackOperation<T> where T:IComparable
    {
        public bool isPalindrome(string s)
        {
            Stack<string> stk = new Stack<string>(s.Length);
            Queue<string> que = new Queue<string>(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                stk.push(s[i].ToString());
                que.enQueue(s[i].ToString());
            }
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (stk.pop() != que.deQueue())
                    return false;
            }
            return true;
        }

        public float doubleAverage(Stack<int> stk)
        {
            Stack<int> yedekStk = new Stack<int>(stk.size());
            float toplam = 0;
            int count = 0;
            while (!stk.isEmpty())
            {
                int popped = stk.pop();
                yedekStk.push(popped);
                if (popped % 2 == 0)
                {
                    toplam += popped;
                    count++;
                }
            }
            while (!yedekStk.isEmpty())
            {
                stk.push(yedekStk.pop());
            }
            return toplam / count;
        }
    }
}
