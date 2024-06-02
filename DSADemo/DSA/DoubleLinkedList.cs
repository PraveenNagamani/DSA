using System;
using System.Collections;


namespace DSADemo.DSA
{
    public class Node
    {

        public Node Prev;
        public int Val;
        public Node next;

        public Node(int val) {
            Prev = null;
            Val = val;
            next = null;
        }

    }
    internal class DoubleLinkedList 
    {
        

     

        public Node InsertNode(Node CurrNode,int data)
        {
            Node newNode = new Node(data);
            if (CurrNode != null)
            {
                newNode.next = CurrNode;
                CurrNode.Prev = newNode;
            }
          

            return newNode;

        }

        public int listsize(Node CurrNode)
        {
            int res = 0;
            while(CurrNode != null)
            {
                res++;
                CurrNode = CurrNode.next;
            }
            return res;
        }

        public void printlist(Node CurrNode)
        {
            string resint;
            while (CurrNode != null)
            {
                resint = CurrNode.Val + " ";
                Console.WriteLine(resint);
                CurrNode = CurrNode.next;
            }
            
        }

        public void printReverselist(Node CurrNode)
        {
            string resint;
            while (CurrNode != null)
            {
                resint = CurrNode.Val + " ";
                Console.WriteLine(resint);
                CurrNode = CurrNode.Prev;
            }

        }

        public Node removeduplicates(Node CurrNode)
        {
            goto LLPointers;

            #region "Usingarray"
            int dllsize = listsize(CurrNode), i = 0;
            int[] distvalues = new int[dllsize];
            bool dupfound = false;
            Node prevnode = null;




            while (CurrNode != null)
            {
                //if(CurrNode.Prev != null) prevnode = CurrNode.Prev;

                for (int j = 0; j < dllsize; j++)
                {

                    if (distvalues[j] == CurrNode.Val)
                    {

                        if (prevnode != null)
                        {
                            prevnode.next = CurrNode.next;
                            if (CurrNode.next != null) CurrNode.next.Prev = prevnode;
                        }
                        else
                        {
                            CurrNode.next.Prev = null;
                        }
                        dupfound = true;
                        break;

                    }
                    else if (distvalues[j] == 0)
                    {
                        break;
                    }

                }

                if (dupfound == false)
                {
                    distvalues[i] = CurrNode.Val;
                    i++;
                }
                else { dupfound = false; }

                prevnode = CurrNode;
                CurrNode = CurrNode.next;
            }

            prevnode = null;
            Node head = null;
            for (int a = 0; a < i; a++)
            {
                head = InsertNode(head, distvalues[a]);
            }

            return head;
        #endregion

        #region "usingLLpointers"
        LLPointers:
            Node ptr1;

            ptr1 = CurrNode; 

            while(ptr1 != null)
            {
                

                for(Node ptr2 = ptr1.next; ptr2 != null; ptr2 = ptr2.next)
                {
                    if(ptr1.Val == ptr2.Val)
                    {
                        if(ptr2.Prev != null)
                        {
                            if(ptr2.next != null) ptr2.Prev.next = ptr2.next;
                             
                        }
                        else
                        {
                            ptr2.next.Prev = null;
                        }


                    }

                    ptr1 = ptr2;
                }

                
                ptr1 = ptr1.next;
            }

            return ptr1;
            #endregion

        }

    }
}
