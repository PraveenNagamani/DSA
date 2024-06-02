// See https://aka.ms/new-console-template for more information


using DSADemo.DSA;
using System.Linq.Expressions;
using System.Text;

Console.WriteLine("Demonstration of : ");
Console.WriteLine(" 1. Dictionary");
Console.WriteLine(" 2. Double Linked List");
Console.WriteLine(" 3. Graphs");
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

        //Console.WriteLine("enter no of edges");
        //int e = Convert.ToInt32(Console.ReadLine());

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
    default:
        Console.WriteLine("Incorrect demo no entered");
        break;

}





