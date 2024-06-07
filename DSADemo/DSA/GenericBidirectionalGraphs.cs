using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSADemo.DSA
{
    internal class GenericGraphNode<T>
    {
        T NodeValue;
        List<GenericGraphNode<T>> _neighbours;
        public GenericGraphNode(T _nodevalue)
        {
            NodeValue = _nodevalue;
            _neighbours = new List<GenericGraphNode<T>>();
        }

        internal T GetNodeValue
         {
            get { return NodeValue; }
         }

       internal List<GenericGraphNode<T>> Neighbours
        {
            get { return _neighbours; }
        }

        internal void TraverseGenericGraphNode()
        {

            foreach(GenericGraphNode<T> node in Neighbours)
            {
                Console.Write(" -> " + node.GetNodeValue.ToString());
            }
            Console.Write(" ] ");
        }

         

    }
    internal class GenericBidirectionalGraphs<T>
    {
        List<GenericGraphNode<T>> nodes = new List<GenericGraphNode<T>>();

        public GenericBidirectionalGraphs()
        {

        }

        internal Boolean AddVertex(T _nodevalue)
        {
            GenericGraphNode<T> g1 = FindNode(_nodevalue);
            if (!(g1 == null))
            {
                return false;
            }
            else
            {
                GenericGraphNode<T> g = new GenericGraphNode<T>(_nodevalue);
                nodes.Add(g);
                return true;
            }

        }

        internal Boolean RemoveVertex(T _nodevalue)
        {
            GenericGraphNode<T> g1 = FindNode(_nodevalue);
            if (g1 == null)
            {
                return false;
            }
            else
            {

                nodes.Remove(g1);

                foreach (GenericGraphNode<T> node in nodes)
                {
                    node.Neighbours.Remove(g1);
                }
                return true;
            }

        }

        protected GenericGraphNode<T> FindNode(T _NodeValue)
        {

            foreach (GenericGraphNode<T> node in nodes)
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

            GenericGraphNode<T> g1 = FindNode(_nodevalue1);
            GenericGraphNode<T> g2 = FindNode(_nodevalue2);

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

            GenericGraphNode<T> g1 = FindNode(_nodevalue1);
            GenericGraphNode<T> g2 = FindNode(_nodevalue2);

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

        internal void TraverseGenericGraph()
        {
            Console.WriteLine("========== GENERIC GRAPH TRAVERSAL============");
            foreach (GenericGraphNode<T> node in nodes)
            {
                Console.WriteLine(" Neighbours of " + node.GetNodeValue.ToString() + " [");
                node.TraverseGenericGraphNode();

            }
        }


    }
}
