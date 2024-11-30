using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    internal class Program
    {
        public class Node
        {
            public int value;
            public Node left;
            public Node right;
        }
        public class BinarySearchTree
        {
            public Node root = new Node();
            public BinarySearchTree()
            {
                root = null;
            }

            public void Insert(int data)
            {
                Insert(data, root);
            }
            private void Insert(int data,Node selected)
            {
                Node newNode = new Node();
                newNode.value = data;
                newNode.left = null;
                newNode.right = null;

                if (this.root == null)
                {
                    this.root = newNode;
                    return;
                }
                else if (data > selected.value)
                {
                    if (selected.right == null)
                    {
                        selected.right = newNode;
                        return;
                    }
                    else
                    {
                        Insert(data, selected.right);
                    }
                }
                else if (data < selected.value)
                {
                    if (selected.left == null)
                    {
                        selected.left = newNode;
                        return;
                    }
                    else
                    {
                        Insert(data, selected.left);
                    }
                }
                else
                {
                    return;
                }
            }
        }
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(4);



            Console.WriteLine(tree.root.left.right.value.ToString());
        }
    }
}
