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
                if(this.root.left != null || this.root.right != null)
                {
                    if (this.root.value == data)
                    {
                        nodeToBeDeleted = this.root;
                        parent = null;
                        Node rightSubtreeMin = this.FindMin(nodeToBeDeleted.right, true);
                        Delete(this.FindMin(nodeToBeDeleted.right, true).value);
                        this.root.value = rightSubtreeMin.value;
                        return;
                    }
                    else
                    {

                        if (data > selectedNode.value)
                        {
                            if (selectedNode.right.value == data)
                            {
                                nodeToBeDeleted = selectedNode.right;
                                parent = selectedNode;

                                if (nodeToBeDeleted.right == null && nodeToBeDeleted.left == null)
                                {
                                    selectedNode.right = null;
                                    return;
                                }

                                else if (nodeToBeDeleted.left != null && nodeToBeDeleted.right == null)
                                {
                                    selectedNode.right = nodeToBeDeleted.left;
                                    return;
                                }

                                else if (nodeToBeDeleted.left == null && nodeToBeDeleted.right != null)
                                {
                                    selectedNode.right = nodeToBeDeleted.right;
                                    return;
                                }

                                else
                                {
                                    Node rightSubtreeMin = this.FindMin(nodeToBeDeleted.right, true);
                                    Delete(this.FindMin(nodeToBeDeleted.right, true).value);
                                    selectedNode.left.value = rightSubtreeMin.value;
                                    return;
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

                                if (nodeToBeDeleted.right == null && nodeToBeDeleted.left == null)
                                {
                                    selectedNode.left = null;
                                    return;
                                }

                                else if (nodeToBeDeleted.left != null && nodeToBeDeleted.right == null)
                                {
                                    selectedNode.left = nodeToBeDeleted.left;
                                    return;
                                }

                                else if (nodeToBeDeleted.left == null && nodeToBeDeleted.right != null)
                                {
                                    selectedNode.left = nodeToBeDeleted.right;
                                    return;
                                }
                                else
                                {
                                    Node rightSubtreeMin = this.FindMin(nodeToBeDeleted.right, true);
                                    Delete(this.FindMin(nodeToBeDeleted.right, true).value);
                                    selectedNode.left.value = rightSubtreeMin.value;
                                    return;
                                }
                            }
                            else
                            {
                                Delete(data, selectedNode.left);
                            }
                        }
                    }
                }




            }
            public Node FindMin()
            {
                return FindMin(this.root, true);
            }
            private Node FindMin(Node selectedNode,bool left = true)
            {

                if (selectedNode.right != null && selectedNode.left != null)
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
            tree.Insert(16);

            //The parameter for FindMin searches the left subtree by default, and the right subtree if set to false
            Console.WriteLine("---------------");

            tree.Delete(10);
            Console.WriteLine(tree.root.right.left.value.ToString());

            






        }
    }
}
