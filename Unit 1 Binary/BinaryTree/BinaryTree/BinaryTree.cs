using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public void DisplayNode()
        {
            Console.WriteLine(Data + " ");

        }
    }

    public class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int i)
        {
            Node newNode = new Node();
            newNode.Data = i;

            if(root == null) root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if(i < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                        else
                        {
                            current = current.Right;
                            if (current == null)
                            {
                                parent.Right = newNode;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void InOrder(Node theRoot)
        {
            if(!(theRoot == null))
            {
                InOrder(theRoot.Left);
                theRoot.DisplayNode();
                InOrder(theRoot.Right);
            }
        }

        public void PreOrder(Node theroot)
        {
            if(!(theroot == null))
            {
                theroot.DisplayNode();
                PreOrder(theroot.Left);
                PreOrder(theroot.Right);
            }
        }

        public void PostOrder(Node theroot)
        {
            if (!(theroot == null))
            {
                PostOrder(theroot.Left);
                PostOrder(theroot.Right);
                theroot.DisplayNode();
            }
        }
        public int FindMin()
        {
            Node current = root;
            while (!(current.Left == null))
                current = current.Left;
            return current.Data;
        }

        public int FindMax()
        {
            Node current = root;
            while (!(current.Right == null))
                current = current.Right;
            return current.Data;
        }
        public Node Find(int key)
        {
            Node current = root;
            while(current.Data != key)
            {
                if (key < current.Data)
                    current = current.Left;
                else current = current.Right;
                if (current == null)
                    return null;
            }
            return current;
        }
    }
    internal class BinaryTree
    {
    }
}
