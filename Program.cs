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
            public void Delete(int data)
            {
                Delete(data, this.root);
            }
            private void Delete(int data, Node selectedNode)
            {
                Node nodeToBeDeleted;
                Node parent;
                if (this.root == null)
                {
                    return;
                }
                if (this.root.left != null || this.root.right != null)
                {
                    if (data > selectedNode.value)
                    {
                        if (selectedNode.right.value == data)
                        {
                            nodeToBeDeleted = selectedNode.right;
                            parent = selectedNode;
                            Console.WriteLine(nodeToBeDeleted.value.ToString() + ": Deletion Value");
                            Console.WriteLine(parent.value.ToString() + ": Parent Value");

                            if (nodeToBeDeleted.right == null && nodeToBeDeleted.left == null)
                            {
                                selectedNode.right = null;
                            }

                            else if(nodeToBeDeleted.left != null && nodeToBeDeleted.right == null)
                            {
                                selectedNode.right = nodeToBeDeleted.left;
                            }

                            else if(nodeToBeDeleted.left == null && nodeToBeDeleted.right != null)
                            {
                                selectedNode.right = nodeToBeDeleted.right;
                            }
                        }
                        else
                        {
                            Delete(data, selectedNode.right);
                        }
                    }
                    else if (data < selectedNode.value)
                    {
                        if (selectedNode.left.value == data)
                        {
                            nodeToBeDeleted = selectedNode.left;
                            parent = selectedNode;
                            Console.WriteLine(nodeToBeDeleted.value.ToString() + ": Deletion Value");
                            Console.WriteLine(parent.value.ToString() + ": Parent Value");

                            if (nodeToBeDeleted.right == null && nodeToBeDeleted.left == null)
                            {
                                selectedNode.left = null;
                            }

                            else if (nodeToBeDeleted.left != null && nodeToBeDeleted.right == null)
                            {
                                selectedNode.left = nodeToBeDeleted.left;
                            }

                            else if (nodeToBeDeleted.left == null && nodeToBeDeleted.right != null)
                            {
                                selectedNode.left = nodeToBeDeleted.right;
                            }
                        }
                        else
                        {
                            Delete(data, selectedNode.left);
                        }
                    }
                }
                else if(this.root.value == data)
                {
                    nodeToBeDeleted = this.root;
                    parent = null;
                    Console.WriteLine(nodeToBeDeleted.value.ToString() + ": Deletion Value");
                    Console.WriteLine( "null : Parent Value");
                }


            }
            public Node FindMin(bool left = true)
            {
                Node selectedNode = new Node();
                selectedNode = this.root;
                if (this.root.right != null && this.root.right != null)
                {
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
            tree.Insert(10);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            tree.Insert(20);
            tree.Insert(15);
            tree.Insert(13);

            tree.FindMin();
            tree.Delete(2);
            tree.FindMin();
            tree.Delete(1);
            tree.FindMin();
            //The parameter for FindMin searches the left subtree by default, and the right subtree if set to false
            tree.FindMin();

            
        }
    }
}
