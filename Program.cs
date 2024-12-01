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
            public void Delete(int data, Node selected)
            {

            }
            public Node FindMin(bool left=true)
            {
                Node selectedNode = new Node();
                selectedNode = this.root;
                if (left)
                {
                    while (selectedNode.left != null)
                    {
                        selectedNode = selectedNode.left;
                    }
                }
                else
                {
                    selectedNode = this.root.right;
                    while (selectedNode.left != null)
                    {
                        selectedNode = selectedNode.left;
                    }
                }
                Console.WriteLine(selectedNode.value);
                return(selectedNode);

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
            tree.Insert(24);
            tree.Insert(6);

            //The parameter for FindMin searches the left subtree by default, and the right subtree if set to false
            tree.FindMin();
            tree.FindMin(false);
        }
    }
}
