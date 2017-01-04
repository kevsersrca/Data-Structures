using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYL07122016
{
    class Vertex<T>
    {
        T vertexValue;

        public T VertexValue
        {
            get { return vertexValue; }
            set { vertexValue = value; }
        }


        Vertex<T> nextVertex;

        public Vertex<T> NextVertex
        {
            get { return nextVertex; }
            set { nextVertex = value; }
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
        public Vertex(T val)
        {
            vertexValue = val;
            nextEdge = null;
            nextVertex = null;
            visited = false;
        }
        public override string ToString()
        {
            return Convert.ToString(vertexValue);
        }
    }
}
