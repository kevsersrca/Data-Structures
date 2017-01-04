using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYL07122016
{
    class Edge<T>
    {
        T edgeValue;

        public T EdgeValue
        {
            get { return edgeValue; }
            set { edgeValue = value; }
        }
        Edge<T> nextEdge;

        public Edge<T> NextEdge
        {
            get { return nextEdge; }
            set { nextEdge = value; }
        }
        bool visited;

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }
        public Edge(T val)
        {
            edgeValue = val;
            nextEdge = null;
            visited = false;
        }
        public override string ToString()
        {
            return edgeValue + " "; //+ weight.ToString();
        }
    }
}
