﻿// See https://aka.ms/new-console-template for more information


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
Console.WriteLine(" 5. Bi Directional Non Weighted Generic Graphs");
Console.WriteLine(" 6. Generic Graphs");
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
        Console.WriteLine("========== GENERIC BIDIRECTIONAL GRAPH ACTIVITIES============");

        Console.WriteLine("0. Non Weighted");
        Console.WriteLine("1. Weighted");
        bool IsWeighted = false;
        if (Convert.ToInt32(Console.ReadLine()) == 1)
        {
            IsWeighted = true;
        }



        GraphMethods<GenericBidirectionalGraphs<String>> gm = new GraphMethods<GenericBidirectionalGraphs<String>>();
        gm.BiDirectionalGraphDetailsCapture(IsWeighted,false);

        break;
    case "6":
   
        Console.WriteLine("========== GENERIC GRAPH ACTIVITIES============");

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("0. Non Weighted");
        sb.AppendLine("1. Weighted");
        sb.Append("--------------------");
        Console.WriteLine(sb.ToString());
        bool IsEdgeWeighted = false;
        if (Convert.ToInt32(Console.ReadLine()) == 1)
        {
            IsEdgeWeighted = true;
            sb = new StringBuilder(); 
        }

        sb.AppendLine("0. Non Directional");
        sb.AppendLine("1. Directional");
        sb.Append("--------------------");
        Console.WriteLine(sb.ToString());
        sb = null;
        bool IsDirectional = false;
        if (Convert.ToInt32(Console.ReadLine()) == 1)
        {
            IsDirectional = true;
        }

        GraphMethods<GenericGraph<String>> gg = new GraphMethods<GenericGraph<String>>();
        gg.GenericGraphDetailsCapture(IsEdgeWeighted,IsDirectional);

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


    internal void BiDirectionalGraphDetailsCapture(bool IsWeighted, bool IsDirectional)
    {
        Console.WriteLine("Please select a. for Entering Graph Details\n b. System Generated Graph Details");

        String _Gvalue, _Gvalue1;
        int _weight;

        GenericBidirectionalGraphs<String> Gsg = new GenericBidirectionalGraphs<String>();

        if (Console.ReadLine() == "a")
        {
            Console.WriteLine("enter no of vertices");
            int GVno = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < GVno; i++)
            {
                Console.WriteLine("Value of Vertex : ");
                String _Vvalue = Console.ReadLine();

                Gsg.AddVertex(_Vvalue);

            }

            Console.WriteLine("enter no of edges");
            int GEno = Convert.ToInt32(Console.ReadLine());

          

            for (int i = 0; i < GEno; i++)
            {
                EdgeCapture(out _Gvalue, out _Gvalue1, out _weight, IsWeighted);
                Gsg.AddEdge(_Gvalue, _Gvalue1);

            }
            
        }
        else
        {
            Gsg.AddVertex("a");
            Gsg.AddVertex("b");
            Gsg.AddVertex("c");
            Gsg.AddVertex("d");
            Gsg.AddVertex("e");
            Gsg.AddVertex("f");
            Gsg.AddVertex("g");
            Gsg.AddVertex("h");

            Gsg.AddEdge("a", "b");
            Gsg.AddEdge("a", "c");
            Gsg.AddEdge("b", "d");
            Gsg.AddEdge("c", "d");
            Gsg.AddEdge("d", "e");
            Gsg.AddEdge("e", "f");
            Gsg.AddEdge("e", "g");
            Gsg.AddEdge("f", "g");
            Gsg.AddEdge("g", "h");
            Gsg.AddEdge("d", "h");
            Gsg.AddEdge("h", "e");


        }

        Gsg.TraverseGraph();

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

    internal void GenericGraphDetailsCapture(bool IsWeighted, bool IsDirectional)
    {
        Console.WriteLine("Please select a. for Entering Graph Details\n b. System Generated Graph Details");

        String _Gvalue, _Gvalue1;
        int _weight;

        GenericGraph<String> Gsg = new GenericGraph<String>(IsDirectional,IsWeighted);

        if (Console.ReadLine() == "a")
        {
            Console.WriteLine("enter no of vertices");
            int GVno = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < GVno; i++)
            {
                Console.WriteLine("Value of Vertex : ");
                String _Vvalue = Console.ReadLine();

                Gsg.AddVertex(_Vvalue);

            }

            Console.WriteLine("enter no of edges");
            int GEno = Convert.ToInt32(Console.ReadLine());



            for (int i = 0; i < GEno; i++)
            {
                EdgeCapture(out _Gvalue, out _Gvalue1, out _weight, IsWeighted);
                Gsg.AddEdge(_Gvalue, _Gvalue1, _weight);

            }

        }
        else
        {
            Gsg.AddVertex("a");
            Gsg.AddVertex("b");
            Gsg.AddVertex("c");
            Gsg.AddVertex("d");
            Gsg.AddVertex("e");
            Gsg.AddVertex("f");
            Gsg.AddVertex("g");
            Gsg.AddVertex("h");

            Gsg.AddEdge("a", "b",3);
            Gsg.AddEdge("a", "c",5);
            Gsg.AddEdge("b", "d",4);
            Gsg.AddEdge("c", "d",12);
            Gsg.AddEdge("d", "e",9);
            Gsg.AddEdge("e", "f",4);
            Gsg.AddEdge("e", "g",5);
            Gsg.AddEdge("f", "g",6);
            Gsg.AddEdge("g", "h",20);
            Gsg.AddEdge("d", "h",8);
            Gsg.AddEdge("h", "e",1);


        }

        Gsg.TraverseGraph();

        do
        {
            _Gvalue = ""; _Gvalue1 = "";

            Console.WriteLine(" a. Traverse Graph");
            //Console.WriteLine(" b. Remove vertex");
            //Console.WriteLine(" c. Clear Graph");
            Console.WriteLine(" d. Add vertex");
            Console.WriteLine(" e. Add Edge");
            //Console.WriteLine(" f. Clear Edge");
            Console.WriteLine(" g. Kruskals MST");
            Console.WriteLine(" -- select activity -- ");
            String _graphactivity = Console.ReadLine();

            switch (_graphactivity)
            {
                case "a":
                    Gsg.TraverseGraph();
                    break;
                case "b":
                    Console.WriteLine("enter value to remove");
                    //Gsg.RemoveVertex(Console.ReadLine());
                    break;
                case "c":
                    //Gsg.Clear();
                    break;
                case "d":
                    Console.WriteLine("enter value to add vertex");
                    Gsg.AddVertex(Console.ReadLine());
                    break;
                case "e":
                    EdgeCapture(out _Gvalue, out _Gvalue1, out _weight, IsWeighted);
                    Gsg.AddEdge(_Gvalue, _Gvalue1,_weight);
                    break;
                case "f":
                    EdgeCapture(out _Gvalue, out _Gvalue1, out _weight, IsWeighted);
                    //Gsg.RemoveEdge(_Gvalue, _Gvalue1);
                    break;
                case "g":
                    Gsg.KruskalsMST();
                    break;
                default:
                    Console.WriteLine("Incorrect value selected");
                    break;
            }

            Console.WriteLine("do you want to continue (Y/N)");


        } while (Console.ReadLine().ToUpper() == "Y");


    }
}






