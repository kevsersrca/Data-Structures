using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYL07122016
{
    class Graph<T> where T : IComparable
    {
        Vertex<T> vertexHead;
        //Vertex oluşturma
        private Vertex<T> createVertex(T val)
        {
            return new Vertex<T>(val);
        }
        //Edge oluşturma
        private Edge<T> createEdge(T val)
        {
            return new Edge<T>(val);
        }
        //Vertex ekleme
        public void addVertex(T val)
        {
            if (vertexHead == null)
                vertexHead = createVertex(val);
            else
            {
                Vertex<T> iterator = vertexHead;
                while (iterator.NextVertex != null)
                    iterator = iterator.NextVertex;
                iterator.NextVertex = createVertex(val);
            }
        }
        //Arama methodu
        public Vertex<T> search(T val)
        {
            Vertex<T> iterator = vertexHead;
            while (iterator != null && iterator.VertexValue.CompareTo(val) != 0)
                iterator = iterator.NextVertex;
            return iterator;
        }
        //Edge ekleme
        public void addEdge(T vertexVal, T edgeVal)
        {
            if (vertexHead == null)
                Console.WriteLine("Önce vertex eklemelisiniz.");
            else
            {
                Vertex<T> iterator = search(vertexVal);
                if (iterator != null && search(edgeVal)!=null)
                {
                    if (iterator.NextEdge == null)
                        iterator.NextEdge = createEdge(edgeVal);
                    else
                    {
                        Edge<T> iteratorEdge = iterator.NextEdge;
                        while (iteratorEdge.NextEdge != null)
                            iteratorEdge = iteratorEdge.NextEdge;
                        iteratorEdge.NextEdge = createEdge(edgeVal);
                    }
                }
                else
                    Console.WriteLine("Vertex bulunamadı");
            }
        }
        //Görüntüleme
        public void display()
        {
            Vertex<T> iterator = vertexHead;
            while (iterator != null)
            {
                Console.Write(iterator.ToString() + " --> ");
                Edge<T> iteratorEdge = iterator.NextEdge;
                while (iteratorEdge != null)
                {
                    Console.Write(iteratorEdge.ToString() + " ");
                    iteratorEdge = iteratorEdge.NextEdge;
                }
                Console.WriteLine();
                iterator = iterator.NextVertex;
            }
            Console.WriteLine();
        }
        //Vertex Sayisi
        public int vertexCount()
        {
            Vertex<T> iterator = vertexHead;
            int count = 0;
            while (iterator != null)
            {
                count++;
                iterator = iterator.NextVertex;
            }
            return count;
        }
       //Edge üzerinden gezilip gezilmediğini kontrol etme
        public void visited(T val)
        {
            Vertex<T> iterator = vertexHead;
            Edge<T> iteratorE = null;
            while (iterator != null)
            {
                if (iterator.VertexValue.CompareTo(val) == 0)
                    iterator.Visited = true;
                iteratorE = iterator.NextEdge;
                while (iteratorE != null)
                {
                    if (iteratorE.EdgeValue.CompareTo(val) == 0)
                        iteratorE.Visited = true;
                    iteratorE = iteratorE.NextEdge;
                }
                iterator = iterator.NextVertex;
            }
        }
        //Graph kopyalama
        public Graph<T> copyGraph()
        {
            Graph<T> newGraph = new Graph<T>();
            Vertex<T> vertexIterator = vertexHead;
            Edge<T> edgeIterator;

            while (vertexIterator != null)
            {
                newGraph.addVertex(vertexIterator.VertexValue);
                vertexIterator = vertexIterator.NextVertex;
            }

            vertexIterator = vertexHead;

            while (vertexIterator != null)
            {
                edgeIterator = vertexIterator.NextEdge;
                while (edgeIterator != null)
                {
                    newGraph.addEdge(vertexIterator.VertexValue, edgeIterator.EdgeValue);
                    edgeIterator = edgeIterator.NextEdge;
                }
                vertexIterator = vertexIterator.NextVertex;
            }
            return newGraph;
        }
        //Vertex Silme
        public void deleteVertex(T val)
        {
            if (search(val) == null)
                return;
            Vertex<T> vertexIterator = vertexHead;
            Edge<T> edgeIterator,prevEdge;
            while (vertexIterator != null) //gelen edgeleri siler
            {
                edgeIterator = vertexIterator.NextEdge;
                prevEdge = edgeIterator;
                if (edgeIterator!=null && vertexIterator.NextEdge.EdgeValue.CompareTo(val) == 0)//edge head olma durumu
                    vertexIterator.NextEdge = edgeIterator.NextEdge;
                while (edgeIterator != null)//edge headde degilse
                {
                    if (edgeIterator.EdgeValue.CompareTo(val) == 0)
                        prevEdge.NextEdge = edgeIterator.NextEdge;

                    prevEdge = edgeIterator;
                    edgeIterator = edgeIterator.NextEdge;
                }
                vertexIterator = vertexIterator.NextVertex;
            }
            //vertexi silme
            if (vertexHead.VertexValue.CompareTo(val) == 0)
                vertexHead = vertexHead.NextVertex;
            else
            {
                vertexIterator = vertexHead;
                while (vertexIterator.NextVertex.VertexValue.CompareTo(val) != 0)//while sonrası iterator previousu gosterir
                    vertexIterator = vertexIterator.NextVertex;
                vertexIterator.NextVertex = vertexIterator.NextVertex.NextVertex;
            }
        }
        //indegree bulma
        public int indegree(T val)
        {
            if (search(val) == null)
                return -1;

            Vertex<T> vertexIterator = vertexHead;
            Edge<T> edgeIterator;
            int count = 0;

            while (vertexIterator != null)
            {
                edgeIterator = vertexIterator.NextEdge;
                while (edgeIterator != null)
                {
                    if (edgeIterator.EdgeValue.CompareTo(val) == 0)
                        count++;
                    edgeIterator = edgeIterator.NextEdge;
                }
                vertexIterator = vertexIterator.NextVertex;
            }
            return count;
        }
        //İndegresi bir olanı bulma
        public Vertex<T> findZeroIndegree()
        {
            Vertex<T> vertexIterator = vertexHead;

            while (vertexIterator != null)
            {
                if (indegree(vertexIterator.VertexValue) == 0)
                    return vertexIterator;

                vertexIterator = vertexIterator.NextVertex;
            }
            return null;
        }
        //Topological Sorting işlemi
        public void TopologicalSorting()
        {
            Vertex<T> temp;

            Graph<T> g = copyGraph();
            while (g.vertexHead != null)
            {
                temp = g.findZeroIndegree();
                if (temp == null)
                {
                    Console.WriteLine("Graph DAG degil");
                    return;
                }
                Console.WriteLine(temp.VertexValue);
                g.deleteVertex(temp.VertexValue);
            }
        }
    }
}
