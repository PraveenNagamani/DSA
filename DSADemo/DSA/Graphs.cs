using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSADemo.DSA
{

    internal class Graphs
    {
        private int Vertices;
        private int edgecount;
        private LinkedList<int>[] edge;
        public Graphs(int n, int e)
        {
            Vertices = n;
            edge = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                edge[i] = new LinkedList<int>();
            }

            //edgecount = e;
        }
        public void addEdge(int v, int adjv)
        {
            edge[v].AddLast(adjv);
        }

        public void TraverseGraph()
        {
            Console.WriteLine("============ GRAPHS TRAVERSAL ================");
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < edge.Length; i++)
            {
                sb.Append(i);
                foreach(int e in edge[i])
                {
                   sb.Append(" -> " +  e);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        public void DFS(int v)
        {
            Console.WriteLine("============ GRAPHS DFS ================");

            bool[] visited = new bool[Vertices];

            Stack<int> st = new Stack<int>();
            st.Push(v);
            
            visited[v] = true;
            Console.WriteLine(" DFS start with : " + v);
            Console.WriteLine(" -> " + v);
            while (st.Count != 0)
            {

                int popv = st.Peek();

                innerDFS(ref st,popv,ref visited);

                int popv2 = st.Pop();

            }

            
        }

        public void innerDFS(ref Stack<int> st,int popv, ref bool[] visited)
        {
            foreach (int i in edge[popv])
            {
                if (!visited[i])
                {
                    st.Push(i);
                    Console.WriteLine(" -> " + i);
                    visited[i] = true;
                    innerDFS(ref st, i, ref visited);
                }
            }
        }

        public void BFS(int v)
        {
            Console.WriteLine("============ GRAPHS BFS ================");

            bool[] visited = new bool[Vertices];

            Queue<int> q = new Queue<int>();
            q.Enqueue(v);
            

            visited[v] = true;
            Console.WriteLine(" BFS start with : " + v);

            while (q.Count != 0)
            {
                int popv = q.Dequeue();
               
                 Console.WriteLine(" -> " + popv);
                
                    
                innerBFS(ref q, popv, ref visited);
  
            }
        }

        public void innerBFS(ref Queue<int> q, int deq, ref bool[] visited)
        {
            foreach (int i in edge[deq])
            {
                if (!visited[i])
                {
                    q.Enqueue(i);
                    visited[i] = true;
                }
            }
        }

    }
}
