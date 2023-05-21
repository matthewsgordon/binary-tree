using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    //Class MyNode to hold one integer item
    //Left child leftChild 
    //Right child rightChild
    //Parent myParent (for root node myParent is NULL)

    class MyNode
    {
        public int item;
        public MyNode leftChild;
        public MyNode rightChild;
        public MyNode myParent;

        //Default Constructor
        public MyNode()
        {
            item = 0;
            leftChild = null;
            rightChild = null;
            myParent = null;
        }
        //Constructor with value parameter
        public MyNode(int value)
        {
            item = value;
            leftChild = null;
            rightChild = null;
            myParent = null;
        }
    }
    class MyBinaryTree
    {
        public MyNode root;
        public MyBinaryTree()
        {
            root = null;
        }
        public MyNode ReturnRoot()
        {
            return root;
        }
        // method for inserting node 
        public void InsertNode(int id)
        {
            MyNode newNode = new MyNode(id);

            if (root == null)
            {
                //First element and it should be the root
                root = newNode;
            }
            else
            {
                //Assign the new node to the appropriate parent by comparing the item.
                //For example, if the given item is less then root's item then it goes to leftChild 
                //else go to the rightChild. Continue until you find a situation where
                //the new node could be attached as one of the child of a parent.
                //Don't foget to assign the parent node as well.
                MyNode current = root;
                MyNode parent;

                while (true)
                {
                    parent = current;
                    if (Convert.ToInt32(newNode.item) < Convert.ToInt32(current.item))
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            break;
                        }
                    }
                }
            }
        }

        //NOTE: USE RECURSION FOR ALL THE BELOW TRAVERSAL ALGORITHM
        // Method for pre order traversal
        public void Preorder(MyNode tmpNode)
        {
            if (tmpNode == null)
                return;

            Console.WriteLine(tmpNode.item);
            Preorder(tmpNode.leftChild);
            Preorder(tmpNode.rightChild);

        }
        // Method for in order traversal
        public void Inorder(MyNode tmpNode)
        {
            if (tmpNode == null)
                return;

            Inorder(tmpNode.leftChild);
            Console.WriteLine(tmpNode.item);
            Inorder(tmpNode.rightChild);
        }
        // Method for post order traversal
        public void Postorder(MyNode tmpNode)
        {
            //Start from the Root
            if (tmpNode == null)
                return;

            Postorder(tmpNode.leftChild);
            Postorder(tmpNode.rightChild);
            Console.WriteLine(tmpNode.item);


        }

        public void DepthFirstSearch(MyNode node)
        {
            MyNode tmpNode = root;
            Stack<MyNode> stack = new Stack<MyNode>();
            // Search for node 
            while (!stack.Any() || tmpNode != null)
            {
                // Find current node
                if (tmpNode != null)
                {
                    if (tmpNode.item == node.item)
                    {
                        Console.WriteLine("Found Node: " + node.item);
                    }
                }
                // If right child is not null then traverse left
                if (tmpNode.rightChild != null)
                {
                    stack.Push(tmpNode.rightChild);
                    tmpNode = tmpNode.leftChild;
                }
                else
                {
                    tmpNode = stack.Pop();
                }
            }
        }

        public void BreadthFirstSearch(MyNode node)
        {
            Queue<MyNode> q = new Queue<MyNode>();
            // creates a queue of items
            q.Enqueue(root);
            while (q.Any())
            {
                // dequeue the first item
                MyNode tmpNode = q.Dequeue();
                // Find node 
                if (tmpNode.item == node.item)
                {
                    Console.WriteLine("Found Node: "+node.item);
                }
                if (tmpNode.leftChild != null)
                {
                    q.Enqueue(tmpNode.leftChild);
                }
                if (tmpNode.rightChild != null)
                {
                    q.Enqueue(tmpNode.rightChild);
                }
            }
        }

        public void RecursiveSearch(MyNode tmpNode, MyNode searchNode)
        {
            // If node is null start again
            if (tmpNode == null)
                return;
                // Find node
            if (tmpNode.item == searchNode.item)
            {
                Console.WriteLine("Found node: "+searchNode.item);
                return;
            }
            // Searches nodes until 20 and 30 are found 
            RecursiveSearch(tmpNode.leftChild, searchNode);
            RecursiveSearch(tmpNode.rightChild, searchNode);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTree theTree = new MyBinaryTree();
            //Insert the following number to the tree and keep the order
            //25,15,26,13,22,30,20,23,28,33,16,17

            /*   ADD YOUR CODE HERE */
            int[] numbers = { 25, 15, 26, 13, 22, 30, 20, 23, 28, 33, 16, 17 };
            for (int i = 0; i < numbers.Length; i++)
            {
                theTree.InsertNode(numbers[i]);
            }

            MyNode root = theTree.ReturnRoot();



            //Do In-order traversal of this tree and print the items

            /*   ADD YOUR CODE HERE */
            Console.WriteLine(" Inorder traversal :");
            theTree.Inorder(root);


            //Do Pre-order traversal of this tree and print the items

            /*   ADD YOUR CODE HERE */
            Console.WriteLine("Pre order traversal :");
            theTree.Preorder(root);


            //Do Post-order traversal of this tree and print the items

            /*   ADD YOUR CODE HERE */
            Console.WriteLine("Post order traversal :");
            theTree.Postorder(root);

            MyNode n20 = new MyNode(20);
            theTree.DepthFirstSearch(n20);

            MyNode n30 = new MyNode(30);
            theTree.BreadthFirstSearch(n30);
            // Searches for nodes 20 and 30
            theTree.RecursiveSearch(theTree.ReturnRoot(),n20);
            theTree.RecursiveSearch(theTree.ReturnRoot(),n30);


        }
    }
}