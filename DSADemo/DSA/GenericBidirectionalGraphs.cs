//using Microsoft.VisualBasic;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

namespace DSADemo.DSA
{
    internal class GenericBiDirectionalGraphNode<T>
    {
        T NodeValue;
       
        List<GenericBiDirectionalGraphNode<T>> _neighbours;
        public GenericBiDirectionalGraphNode(T _nodevalue)
        {
            NodeValue = _nodevalue;
            _neighbours = new List<GenericBiDirectionalGraphNode<T>>();
            
        }

        internal T GetNodeValue
         {
            get { return NodeValue; }
         }
      
    
       internal List<GenericBiDirectionalGraphNode<T>> Neighbours
        {
            get { return _neighbours; }
        }

        internal void TraverseNeighbours()
        {

            foreach(GenericBiDirectionalGraphNode<T> node in Neighbours)
            {
                Console.Write(" -> " + node.GetNodeValue.ToString());
            }
            Console.WriteLine(" ] ");
            
        }

         

    }
    internal class GenericBidirectionalGraphs<T>
    {
        List<GenericBiDirectionalGraphNode<T>> nodes = new List<GenericBiDirectionalGraphNode<T>>();
        List<int> weight = new List<int>();

        public GenericBidirectionalGraphs()
        {

        }

        internal Boolean AddVertex(T _nodevalue)
        {
            GenericBiDirectionalGraphNode<T> g1 = FindNode(_nodevalue);
            if (!(g1 == null))
            {
                return false;
            }
            else
            {
                GenericBiDirectionalGraphNode<T> g = new GenericBiDirectionalGraphNode<T>(_nodevalue);
                nodes.Add(g);
                return true;
            }

        }

        internal Boolean RemoveVertex(T _nodevalue)
        {
            GenericBiDirectionalGraphNode<T> g1 = FindNode(_nodevalue);
            if (g1 == null)
            {
                return false;
            }
            else
            {

                nodes.Remove(g1);

                foreach (GenericBiDirectionalGraphNode<T> node in nodes)
                {
                    node.Neighbours.Remove(g1);
                }
                return true;
            }

        }

        protected GenericBiDirectionalGraphNode<T> FindNode(T _NodeValue)
        {

            foreach (GenericBiDirectionalGraphNode<T> node in nodes)
            {

                if (node.GetNodeValue.Equals(_NodeValue))
                {
                    return node;
                }

            }
            return null;
        }


        internal Boolean AddEdge(T _nodevalue1, T _nodevalue2)
        {

            GenericBiDirectionalGraphNode<T> g1 = FindNode(_nodevalue1);
            GenericBiDirectionalGraphNode<T> g2 = FindNode(_nodevalue2);

            if (g1 == null || g2 == null)
            {
                return false;
            }
            else if (g1.Neighbours.Contains(g2) || g2.Neighbours.Contains(g1))
            {
                return false;
            }
            else
            {
                g1.Neighbours.Add(g2);
                g2.Neighbours.Add(g1);
              
                return true;

            }

        }

        internal Boolean RemoveEdge(T _nodevalue1, T _nodevalue2)
        {

            GenericBiDirectionalGraphNode<T> g1 = FindNode(_nodevalue1);
            GenericBiDirectionalGraphNode<T> g2 = FindNode(_nodevalue2);

            if (g1 == null || g2 == null)
            {
                return false;
            }
            else if (g1.Neighbours.Contains(g2) || g2.Neighbours.Contains(g1))
            {
                g1.Neighbours.Remove(g2);
                g2.Neighbours.Remove(g1);
                

                return true;

            }
            else
            {
                return false;
            }

        }
        protected int Count
        {
            get { return nodes.Count; }
        }

        internal Boolean Clear()
        {

            for (int i = 0; i < Count;i++)
            {

                nodes[i].Neighbours.Clear();
                nodes.Remove(nodes[i]);
            }
            nodes.Clear();

            return true;
        } 

        internal void TraverseGraph()
        {
            Console.WriteLine("========== GENERIC GRAPH TRAVERSAL============");
            foreach (GenericBiDirectionalGraphNode<T> node in nodes)
            {
                Console.Write(" Neighbours of " + node.GetNodeValue.ToString() + " [");
                node.TraverseNeighbours();

            }

            MatrixForm();
        }

        internal void MatrixForm()
        {
            Console.WriteLine("========== GENERIC GRAPH MATRIX FORM============");
            foreach (GenericBiDirectionalGraphNode<T> node in nodes)
            {

                foreach (GenericBiDirectionalGraphNode<T> _neighbour in nodes)
                {
                    int pathfound;
                    if(node.GetNodeValue.ToString() == _neighbour.GetNodeValue.ToString())
                    {
                        pathfound = -1;
                    }
                    else if (node.Neighbours.Contains(_neighbour))
                    {
                        pathfound = 1;
                    }
                    else
                    {
                        pathfound = 0;
                    }
                    Console.Write(pathfound); ;
                }
                Console.WriteLine();

            }
        }


    }
}
