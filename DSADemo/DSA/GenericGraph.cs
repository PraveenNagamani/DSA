

namespace DSADemo.DSA
{
    internal class GenericGraphNode<T>
    {
        T _NodeValue;
        List<GenericGraphNode<T>> _neighbours;
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

     


    }

    internal class GenericGraphEdge
    {
        int _EdgeWeight;

        public GenericGraphEdge(int _weight)
        {
            _EdgeWeight = _weight;
        }

    }
    internal class GenericGraph<T>
    {
        bool isBidirectional;
        bool isWeighted;
        List<GenericGraphNode<T>> _nodes = new List<GenericGraphNode<T>> ();

        protected int Count
        {
            get { return _nodes.Count;  }
        }
        public GenericGraph(bool _isBidirectional, bool _isWeighted)
        {
            isBidirectional = _isBidirectional;
            isWeighted = _isWeighted;
        }
        
        internal bool AddVertex(T _value)
        {
            GenericGraphNode<T> g = FindNode(_value);

            if (g != null)
            {
                return false;
            }
            else
            {
                GenericGraphNode<T> g1 = new GenericGraphNode<T>(_value);
                return true;
            }

        }

        protected GenericGraphNode<T> FindNode(T _value)
        {

            foreach(GenericGraphNode<T> node in _nodes)
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
            
            GenericGraphNode<T> g1  =FindNode(_from);
            GenericGraphNode<T> g2 = FindNode(_to);

            if(g1 != null && g2 != null)
            {
                GenericGraphEdge e = new GenericGraphEdge(weight);


                return true;
            }
            return false;
        }

    }
}
