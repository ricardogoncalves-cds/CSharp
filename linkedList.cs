/*
The code below implements the
LinkedList data structure.

A LinkedList is a type of data
structure where each element of
the list contains data and a 
pointer to the next element on 
the list.

This implementation allows to
add elements to the beginning,
to the end, or to the middle
(if sorted) of the LinkedList.
*/

// Creating a new LinkedList
MyLinkedList list = new MyLinkedList();

// Test cases
list.addToEnd(13);
list.addToEnd(17);
list.addToEnd(19);
list.addToEnd(28);
Console.WriteLine("Testing adding elements to the END of the LinkedList:");
list.Print();
Console.WriteLine("\n");

list.addToBeginning(10);
list.addToBeginning(7);
list.addToBeginning(4);
list.addToBeginning(3);
Console.WriteLine("Testing adding elements to the BEGINNING of the LinkedList:");
list.Print();
Console.WriteLine("\n");

list.addSorted(5);
list.addSorted(25);
list.addSorted(11);
list.addSorted(20);
Console.WriteLine("Testing adding elements SORTED to the LinkedList:");
list.Print();
Console.WriteLine("\n");


// Node class; each node is a data type of the LinkedList data structure
public class Node
{
    public int data;
    public Node next;

    public Node(int i)
    {
        data = i;
        next = null;
    }

    // Print the LinkedList
    public void Print()
    {
        Console.Write(data);
        if(next != null)
        {
            Console.Write(" >> ");
            next.Print();
        }
    }

    // Adds a new node in a sorted ordered; The list must be sorted for it to work properly
    public void addSorted(int data)
    {
        if(next == null)
        {
            next = new Node(data);
        }
        else if(data < next.data)
        {
            Node tempNode = new Node(data);
            tempNode.next = this.next;
            this.next = tempNode;
        }
        else
        {
            next.addSorted(data);
        }

    }

    // Adds a new node to the end of the LinkedList
    public void addToEnd(int data)
    {
        if(next == null)
        {
            next = new Node(data);
        }
        else
        {
            next.addToEnd(data);
        }
    }
}


// MyLinkedList class implements the LinkedList data structure
public class MyLinkedList
{
    public Node headNode;

    public MyLinkedList()
    {
        headNode = null;
    }

    // Adds a new node to the end of the LinkedList
    public void addToEnd(int data)
    {
        if(headNode == null)
        {
            headNode = new Node(data);
        }
        else
        {
            headNode.addToEnd(data);
        }
    }

    // Adds a new node in a sorted ordered; The list must be sorted for it to work properly
    public void addSorted(int data)
    {
        if(headNode == null)
        {
            headNode = new Node(data);
        }
        else if(data < headNode.data)
        {
            addToBeginning(data);
        }
        else
        {
            headNode.addSorted(data);
        }
    }

    // Adds a new node to the beginning of the LinkedList
    public void addToBeginning(int data)
    {
        if(headNode == null)
        {
            headNode = new Node(data);
        }
        else
        {
            Node tempNode = new Node(data);
            tempNode.next = headNode;
            headNode = tempNode;
        }
    }

    public void Print()
    {
        if(headNode != null)
        {
            headNode.Print();
        }
    }
}
