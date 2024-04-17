using System;
using System.Collections.Generic;
using System.Text;
class Node
{
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    private Node root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.Data)
        {
            root.Left = InsertRec(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRec(root.Right, data);
        }

        return root;
    }

    public void InOrder()
    {
        InOrderRec(root);
    }

    private void InOrderRec(Node root)
    {
        if (root != null)
        {
            InOrderRec(root.Left);
            Console.Write(root.Data + " ");
            InOrderRec(root.Right);
        }
    }

    public void PreOrder()
    {
        PreOrderRec(root);
    }

    private void PreOrderRec(Node root)
    {
        if (root != null)
        {
            Console.Write(root.Data + " ");
            PreOrderRec(root.Left);
            PreOrderRec(root.Right);
        }
    }

    public void PostOrder()
    {
        PostOrderRec(root);
    }

    private void PostOrderRec(Node root)
    {
        if (root != null)
        {
            PostOrderRec(root.Left);
            PostOrderRec(root.Right);
            Console.Write(root.Data + " ");
        }
    }
}

class Program
{
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введіть довжину масиву:");
        int length = int.Parse(Console.ReadLine());

        int[] arr = new int[length];
        Random rand = new Random();

        Console.WriteLine("Випадковий масив чисел:");

        for (int i = 0; i < length; i++)
        {
            arr[i] = rand.Next(100); 
            Console.Write(arr[i] + " ");
        }

        BinaryTree binaryTree = new BinaryTree();

        
        foreach (int num in arr)
        {
            binaryTree.Insert(num);
        }

        Console.WriteLine("\n\nВпорядковане бінарне дерево (ін-ордер):");
        binaryTree.InOrder();

        Console.WriteLine("\n\nБінарне дерево (пре-ордер):");
        binaryTree.PreOrder();

        Console.WriteLine("\n\nБінарне дерево (пост-ордер):");
        binaryTree.PostOrder();

        Console.ReadLine();
    }
}
