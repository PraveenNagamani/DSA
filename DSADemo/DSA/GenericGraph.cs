

using System.Text;
using System.Xml.Linq;

namespace DSADemo.DSA
{
    internal class GenericGraphNode<T>
    {
        T _NodeValue;
        internal int index { get; set; }
        List<GenericGraphNode<T>> _neighbours ;
        internal List<GenericGraphEdge<T>> Edges { get; set; } = new List<GenericGraphEdge<T>>() ;
  
        public GenericGraphNode(T _value)
        {
            _NodeValue = _value;
            _neighbours = new List<GenericGraphNode<T>>();
        }

        

        internal T NodeValue
        {
            get { return _NodeValue; }
        }

        internal List<GenericGraphNode<T>> Neighbours
        {
            get { return _neighbours; }
        }

        internal bool AddNeighbour(GenericGraphNode<T> _neighbour)
        {
            if (_neighbours.Contains(_neighbour)) { return false; }
            else
            {
                _neighbours.Add(_neighbour);
                return true;
            }
        }
     

    }

    internal class GenericGraphEdge<T>
    {
        int _EdgeWeight;
        GenericGraphNode<T> _parentnode;
        GenericGraphNode<T> _childnode;

        public GenericGraphEdge(int _weight,GenericGraphNode<T> ParentVetex,GenericGraphNode<T> ChildVertex )
        {
            _EdgeWeight = _weight;
            _parentnode = ParentVetex;
            _childnode = ChildVertex;
        }

        internal int EdgeWeight
        {
            get { return _EdgeWeight; }
        }
        internal GenericGraphNode<T> Parent
        {
            get { return _parentnode; }
        }

        internal GenericGraphNode<T> Child
        {
            get { return _childnode; }
        }



    }
    internal class GenericGraph<T>
    {
        bool isdirectional;
        bool isWeighted;
        List<GenericGraphNode<T>> _nodes = new List<GenericGraphNode<T>> ();
        List<GenericGraphEdge<T>> _weights = new List<GenericGraphEdge<T>>();
        List<GenericGraphNode<T>> visited = new List<GenericGraphNode<T>>();

        protected int Count
        {
            get { return _nodes.Count;  }
        }
        public GenericGraph(bool _isdirectional, bool _isWeighted)
        {
            isdirectional = _isdirectional;
            isWeighted = _isWeighted;
        }
        
        internal bool AddVertex(T _value)
        {
            GenericGraphNode<T> g = FindNode(_value,_nodes);

            if (g != null)
            {
                return false;
            }
            else
            {
                GenericGraphNode<T> g1 = new GenericGraphNode<T>(_value);
                _nodes.Add(g1);
                UpdateIndices();
                return true;
            }

        }

        protected void UpdateIndices()
        {
            foreach(GenericGraphNode<T> node in _nodes)
            {
                node.index++;
            }
        }

        protected GenericGraphNode<T> FindNode(T _value,List<GenericGraphNode<T>> NodeList)
        {

            foreach(GenericGraphNode<T> node in NodeList)
            {
                if (node.NodeValue.Equals(_value))
                {
                    return node;
                }
               
            }
            
             return null;
           
        }

        internal bool AddEdge(T _from, T _to, int weight)
        {
            
            GenericGraphNode<T> g1  =FindNode(_from, _nodes);
            GenericGraphNode<T> g2 = FindNode(_to, _nodes);
         

            if (g1.Neighbours.Contains(g2))
            {
                return false;
            }
            if(g1 != null && g2 != null)
            {
                
                if (g1.AddNeighbour(g2))
                {
                                      
                    
                    if (isWeighted)
                    {
                        
                        GenericGraphEdge<T> e1 = new GenericGraphEdge<T>(weight, g1, g2);
                        g1.Edges.Add(e1);
                        _weights.Add(e1);
                    }
                }
                else { return false; }

                if (!isdirectional)
                {
                    
                    if (g2.AddNeighbour(g1))
                    {
                        if (isWeighted)
                        {
                           
                            GenericGraphEdge<T> e2 = new GenericGraphEdge<T>(weight, g1, g2);
                            g2.Edges.Add(e2);
                            _weights.Add(e2);
                        }
                    }
                    else { return false; }
                }

                return true;
            }
            return false;
        }

        protected int FindEdgeWeight(GenericGraphNode<T> _parent, GenericGraphNode<T> _child)
        {

            foreach (GenericGraphEdge<T> weight in _parent.Edges)
            {
                if ((weight.Parent.Equals(_parent) && weight.Child.Equals(_child)) || (weight.Parent.Equals(_child) && weight.Child.Equals(_parent)))
                {
                    return weight.EdgeWeight;
                }

            }

            return -1;



        }

         

        internal void TraverseGraph()
        {
            StringBuilder sb = new StringBuilder();
           
            foreach (GenericGraphNode<T> from in _nodes)
            {
              
                sb.Append(" Neighbours of " + from.NodeValue + " [ ");
                foreach (GenericGraphNode<T> to in from.Neighbours)
                {
                    sb.Append( " = ( weight of " + FindEdgeWeight(from,to) + ") -> to " + to.NodeValue + " , " );
                    
                }
                sb.AppendLine(" ] ");
                
            }
            Console.WriteLine( sb.ToString() );
        }

      
        internal void KruskalsMST()
        {
            _weights.Sort((a, b) => a.EdgeWeight.CompareTo(b.EdgeWeight));
           
            GenericGraph<T> mst = new GenericGraph<T>(isdirectional, isWeighted);
      
            int i = 0;
            foreach(GenericGraphEdge<T> edge in _weights)
            {
                
                mst.AddVertex(edge.Parent.NodeValue);
                mst.AddVertex(edge.Child.NodeValue);

                GenericGraphNode<T> _parentnode = FindNode(edge.Parent.NodeValue, mst._nodes);
                GenericGraphNode<T> _childnode = FindNode(edge.Child.NodeValue, mst._nodes);

                if (!FindCycle(_parentnode, _childnode, mst))
                {
                    mst.AddEdge(edge.Parent.NodeValue, edge.Child.NodeValue, edge.EdgeWeight);
                    if (!isdirectional)
                    {
                        mst.AddEdge(edge.Child.NodeValue, edge.Parent.NodeValue, edge.EdgeWeight);
                    }

                }
                visited.Clear();
                i++;
            }


            StringBuilder sb = new StringBuilder();

            foreach (GenericGraphNode<T> from in mst._nodes)
            {

                sb.Append(" Neighbours of " + from.NodeValue + " [ ");
                foreach (GenericGraphNode<T> to in from.Neighbours)
                {
                    sb.Append(" = ( weight of " + FindEdgeWeight(from, to) + ") -> to " + to.NodeValue + " , ");

                }
                sb.AppendLine(" ] ");

            }
            Console.WriteLine(sb.ToString());

        }

        private Boolean FindCycle(GenericGraphNode<T> from , GenericGraphNode<T> to, GenericGraph<T> g)
        {
            if(from.Neighbours.Count == 0) {  return false; }
           visited.Add(from);
            
            foreach(GenericGraphNode<T> nnode in from.Neighbours)
            {
                if (visited.Contains(nnode)) { continue; }
                if (nnode.NodeValue.Equals(to.NodeValue)) { visited.Clear();  return true; }
                
                if(FindCycle(nnode, to, g)) { return true; }
            }

            
            return false;
        }


    }
}
