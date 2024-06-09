// See https://aka.ms/new-console-template for more information


using DSADemo.DSA;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;



Console.WriteLine("Demonstration of : ");
Console.WriteLine(" 1. Dictionary");
Console.WriteLine(" 2. Double Linked List");
Console.WriteLine(" 3. Basic Graphs");
Console.WriteLine(" 4. Standard Graphs");
Console.WriteLine(" 5. Generic Graphs");
Console.WriteLine("Enter the required demo sl.no : ");

string selecteddemo = Console.ReadLine();

switch(selecteddemo)
{
    case "1":
        Console.WriteLine("Select the language");
        string langkey = Console.ReadLine();

        DictionaryDemo dc = new DictionaryDemo();
        string selectedlang = dc.PrintDictionary(langkey);

        PrintMsg("You have selected : " + selectedlang);
        void PrintMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        break;
    case "2":
        DoubleLinkedList ddlist = new DoubleLinkedList();
        //Console.WriteLine("no of values you want to enter");
        //string llsize = Console.readline();
        //Convert.ToInt64(llsize)

        Node head = null;
        int[] arraylist = new int[]   {8,4,4,6,4,8,4,10,12,12};

        for (int i = 0;i< arraylist.Length; i++)
        {
            head = ddlist.InsertNode(head, arraylist[i]);
        }

        head = ddlist.removeduplicates(head);
        Console.WriteLine("After removing duplicates : ");
        ddlist.printlist(head);

        break;
    case "3":
   

        Console.WriteLine("enter no of vertices");
        int n = Convert.ToInt32(Console.ReadLine());
        int e = n;  


        Graphs g = new Graphs(n,e);
        for (int i = 0; i < e; i++)
        {
            Console.WriteLine("Map edges : ");
            int edgev = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" to ");
            int adjv = Convert.ToInt32(Console.ReadLine());
            g.addEdge(edgev, adjv);
            
        }

        g.TraverseGraph();

        Console.WriteLine("DFS start node : ");
        int startvertex = Convert.ToInt32(Console.ReadLine());
        g.DFS(startvertex);
        g.BFS(startvertex);



        break;
    case "4":

        Console.WriteLine("enter no of vertices");       
         int Vno = Convert.ToInt32(Console.ReadLine());

        StandardGraph sg = new StandardGraph();

        for (int i = 0; i < Vno; i++)
        {
            Console.WriteLine("Value of Vertex : ");
            String _Vvalue = Console.ReadLine();
            
            sg.AddVertex(_Vvalue);

        }

        Console.WriteLine("enter no of edges");
        int Eno = Convert.ToInt32(Console.ReadLine());

        String _value, _value1;
        int _Edgeweight;
        bool _IsEdgeWeighted = false;

        GraphMethods<StandardGraph> sgm = new GraphMethods<StandardGraph>();
        

        for (int i = 0; i < Eno; i++)
        {
            sgm.EdgeCapture(out _value, out _value1,out _Edgeweight,_IsEdgeWeighted);
            sg.AddEdge(_value, _value1);

        }

        do
        {
            _value = ""; _value1 = "";

            Console.WriteLine(" a. Traverse Graph");
            Console.WriteLine(" b. Remove vertex");
            Console.WriteLine(" c. Clear Graph");
            Console.WriteLine(" d. Add vertex");
            Console.WriteLine(" e. Add Edge");
            Console.WriteLine(" f. Clear Edge");
            Console.WriteLine(" -- select activity -- ");
            String _graphactivity = Console.ReadLine();

            switch (_graphactivity)
            {
                case "a":
                    sg.TraverseGraph();
                    break;
                case "b":
                    Console.WriteLine("enter value to remove");
                    sg.RemoveVertex(Console.ReadLine());
                    break;
                case "c":
                    sg.Clear();
                    break;
                case "d":
                    Console.WriteLine("enter value to add vertex");
                    sg.AddVertex(Console.ReadLine());
                    break;
                case "e":
                    sgm.EdgeCapture(out _value, out _value1, out _Edgeweight, _IsEdgeWeighted);
                    sg.AddEdge(_value, _value1);
                    break;
                case "f":
                    sgm.EdgeCapture(out _value, out _value1, out _Edgeweight, _IsEdgeWeighted);
                    sg.RemoveEdge(_value, _value1);
                    break;
                default:
                    Console.WriteLine("Incorrect value selected");
                    break;
            }

            Console.WriteLine("do you want to continue (Y/N)");
            

        } while (Console.ReadLine().ToUpper() == "Y");



        break;
    case "5":
        Console.WriteLine("========== GENERIC GRAPH ACTIVITIES============");

        Console.WriteLine("0. Non Weighted");
        Console.WriteLine("1. Weighted");
        bool IsWeighted = false;
        if (Convert.ToInt32(Console.ReadLine()) == 1)
        {
            IsWeighted = true;
        }



        GraphMethods<GenericBidirectionalGraphs<String>> gm = new GraphMethods<GenericBidirectionalGraphs<String>>();
        gm.GraphDetailsCapture(IsWeighted);

        break;
        
    default:
        Console.WriteLine("Incorrect demo no entered");
        break;

}

internal class GraphMethods<T>
{

    internal void EdgeCapture(out String _value, out String _value1, out int weight, bool isweighted = false)
    {
        Console.WriteLine("Edge  b/w Vertex 1 : ");
        _value = Console.ReadLine();
        Console.WriteLine(" to Vertex 2 : ");
        _value1 = Console.ReadLine();
        if (isweighted)
        {
            Console.WriteLine("Enter weight of edge between " + _value + " and " + _value1);
            weight = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            weight = 0;
        }

    }

    internal void GraphDetailsCapture(bool IsWeighted)
    {

        Console.WriteLine("enter no of vertices");
        int GVno = Convert.ToInt32(Console.ReadLine());

       
        GenericBidirectionalGraphs<String> Gsg = new GenericBidirectionalGraphs<String>();
        

        for (int i = 0; i < GVno; i++)
        {
            Console.WriteLine("Value of Vertex : ");
            String _Vvalue = Console.ReadLine();

            Gsg.AddVertex(_Vvalue);

        }

        Console.WriteLine("enter no of edges");
        int GEno = Convert.ToInt32(Console.ReadLine());

        String _Gvalue, _Gvalue1;
        int _weight;

        for (int i = 0; i < GEno; i++)
        {
            EdgeCapture(out _Gvalue, out _Gvalue1, out _weight, IsWeighted);
            Gsg.AddEdge(_Gvalue, _Gvalue1);

        }

        do
        {
            _Gvalue = ""; _Gvalue1 = "";

            Console.WriteLine(" a. Traverse Graph");
            Console.WriteLine(" b. Remove vertex");
            Console.WriteLine(" c. Clear Graph");
            Console.WriteLine(" d. Add vertex");
            Console.WriteLine(" e. Add Edge");
            Console.WriteLine(" f. Clear Edge");
            Console.WriteLine(" -- select activity -- ");
            String _graphactivity = Console.ReadLine();

            switch (_graphactivity)
            {
                case "a":
                    Gsg.TraverseGraph();
                    break;
                case "b":
                    Console.WriteLine("enter value to remove");
                    Gsg.RemoveVertex(Console.ReadLine());
                    break;
                case "c":
                    Gsg.Clear();
                    break;
                case "d":
                    Console.WriteLine("enter value to add vertex");
                    Gsg.AddVertex(Console.ReadLine());
                    break;
                case "e":
                    EdgeCapture(out _Gvalue, out _Gvalue1, out _weight, IsWeighted);
                    Gsg.AddEdge(_Gvalue, _Gvalue1);
                    break;
                case "f":
                    EdgeCapture(out _Gvalue, out _Gvalue1, out _weight, IsWeighted);
                    Gsg.RemoveEdge(_Gvalue, _Gvalue1);
                    break;
                default:
                    Console.WriteLine("Incorrect value selected");
                    break;
            }

            Console.WriteLine("do you want to continue (Y/N)");


        } while (Console.ReadLine().ToUpper() == "Y");


    }
}






