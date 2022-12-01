using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    internal class Program
    {
        static void Main(String[] args)
        {
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(23);
            nums.Insert(45);
            nums.Insert(16);
            nums.Insert(37);
            nums.Insert(3);
            nums.Insert(99);
            nums.Insert(22);

            Console.WriteLine("Inorder traversal: ");
            nums.InOrder(nums.root);
            Console.WriteLine();

            Console.WriteLine("PreOrder traversal: ");
            nums.PreOrder(nums.root);
            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal: ");
            nums.PostOrder(nums.root);
            Console.WriteLine();

            Console.WriteLine("Max: " + nums.FindMax());
            Console.WriteLine("Min: " + nums.FindMin());

            Console.WriteLine(nums.Find(99).Data);
            Console.ReadLine();
        }
    }
}