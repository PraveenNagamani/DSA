using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSADemo.DSA
{
    internal class GraphNode
    {
        private readonly String _GraphValue;
        private List<GraphNode> _Neighbour;
        public GraphNode(string value)
        {
            _GraphValue = value;
            _Neighbour = new List<GraphNode>();
        }

        internal String NodeValue
        {
           get
            {
                return _GraphValue;
            }
        }

        internal List<GraphNode> Neighbour
        {
            get
            {
                return _Neighbour;
            }
        }

        internal String TraverseGraphNode()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(  NodeValue + " [ ");
            foreach(GraphNode node in _Neighbour)
            {
                sb.Append(" -> " + node.NodeValue);
            }
            sb.Append(" ] ");
            sb.AppendLine();

            return sb.ToString();
        }

        internal Boolean RemoveNeighbour(GraphNode node)
        {
            if (_Neighbour.Contains(node))
            {
                _Neighbour.Remove(node);
                return true;
            }else
            {
                return false;
            }

        }

        internal Boolean RemoveAll()
        {
            foreach(GraphNode item in _Neighbour)
            {
                _Neighbour.Remove(item);
            }
            return true;

        }


    }
    internal class StandardGraph
    {
       
        List<GraphNode> _myGraphNodes = new List<GraphNode> ();
        public StandardGraph() { }

        internal Boolean AddNode(String value)
        {
            if (FindNode(value) is not null) 
            {
                return false;
            }
            _myGraphNodes.Add( new GraphNode(value));
            return true;
        }

        protected GraphNode FindNode(String value)
        {
            foreach(GraphNode item in _myGraphNodes)
            {
                if (item.NodeValue.Equals(value))
                {
                    return item;
                }
            }
            return null;
        }

        internal Boolean AddNeighbour(String NodeValue1, String NodeValue2)
        {
            GraphNode g1 = FindNode(NodeValue1);
            GraphNode g2 = FindNode(NodeValue2);

            if ( g1 == null && g2 == null)
            {
                return false ;
            }
            else if(g1.Neighbour.Contains(g2))
            {
                return false;
            }
            else
            {
                g1.Neighbour.Add(g2);
                return true;
            }
        }

        internal Boolean RemoveNeighbour(String NodeValue1, String NodeValue2)
        {
            GraphNode g1 = FindNode(NodeValue1);
            GraphNode g2 = FindNode(NodeValue2);

            if (g1 == null && g2 == null)
            {
                return false;
            }
            else if (!g1.Neighbour.Contains(g2))
            {
                return false;
            }
            else
            {
                g1.Neighbour.Remove(g2);
                return true;
            }
        }

        internal void Clear()
        {
            _myGraphNodes.Clear();
        }

        internal Boolean Remove(String _value)
        {
            GraphNode g1 = FindNode(_value);

            if(g1 == null)
            {
                return false;
            }
            else
            {
                foreach(GraphNode node in _myGraphNodes )
                {
                    node.RemoveNeighbour(g1);
                }
               
                 _myGraphNodes.Remove(g1);
               

                return true;
            }

            
        }

        internal void TraverseGraph()
        {
            Console.WriteLine("============ STANDARD GRAPHS TRAVERSAL ================");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _myGraphNodes.Count; i++)
            {
                sb.Append(" Neighbour of : " + _myGraphNodes[i].TraverseGraphNode());
                sb.AppendLine();

            }
            Console.WriteLine(sb.ToString());
        }

    }
}
