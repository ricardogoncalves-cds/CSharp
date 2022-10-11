private static void Main(string[] args)
{
    Console.WriteLine("Binary Search Tree");

    BinaryTree binaryTree = new BinaryTree();

    /*
     * Below is a visual representation of the
     * Binary Search Tree that will be created
     * using the Insert method:
     * 
     *              55
     *            /    \
     *          50      88
     *         /       /  \
     *       33       86  100
     *      /  \     /  \     
     *     20  44   71  87   
     *  
     */

    // Inserting nodes to the BinarySearchTree

    binaryTree.Insert(55);
    binaryTree.Insert(50);
    binaryTree.Insert(88);
    binaryTree.Insert(86);
    binaryTree.Insert(33);
    binaryTree.Insert(20);
    binaryTree.Insert(100);
    binaryTree.Insert(44);
    binaryTree.Insert(71);
    binaryTree.Insert(87);

    // Test cases of the various methods available to the BinarySearchTree

    // In order traversal
    Console.Write("\nIn order traversal || Left -> Root -> Right: ");
    binaryTree.InOrderTraversal();
    Console.WriteLine();

    // Preorder traversal
    Console.Write("\nPreorder traversal || Root -> Left -> Right: ");
    binaryTree.PreOrderTraversal();
    Console.WriteLine();

    // Postorder traversal
    Console.Write("\nPostorder traversal || Left -> Right -> Root: ");
    binaryTree.PostOrderTraversal();
    Console.WriteLine();

    // Find a value; NOTE: refer to the comment below the Find and FindRecursively methods;
    Console.WriteLine("\nFind 71");
    var nodeFind = binaryTree.Find(71);
    Console.WriteLine(nodeFind.Data);

    // Find a value recursively; NOTE: refer to the comment below the Find and FindRecursively methods;
    Console.WriteLine("\nFind recursively 71");
    var nodeFindRecursive = binaryTree.FindRecursive(71);
    Console.WriteLine(nodeFindRecursive.Data);

    /* NOTE: The find methods will throw an unhandled exception 
     * if the value provided does not exist in the tree, as this
     * are only to test the methods.
     * 
     * The exceptions can be handled as it has been done below
     * in the Soft delete test;
     */

    // Delete nodes
    Console.WriteLine("\nDelete leaf node 71");
    binaryTree.Remove(71);
    binaryTree.InOrderTraversal();
    Console.WriteLine();

    Console.WriteLine("\nDelete node with one child 86");
    binaryTree.Remove(86);
    binaryTree.InOrderTraversal();
    Console.WriteLine();

    // Soft delete node
    Console.WriteLine("\nSoft delete node 33");
    binaryTree.SoftDelete(33);

    if (binaryTree.Find(33) != null)
        Console.WriteLine(binaryTree.Find(33).Data);
    else
        Console.WriteLine("Node 33 not found");
    Console.WriteLine();

    // Find the smallest value
    Console.Write("The smallest value in the tree: ");
    Console.WriteLine(binaryTree.Smallest());

    // Find the largest value
    Console.Write("\nThe largest value in the tree: ");
    Console.WriteLine(binaryTree.Largest());

    // Find the number of leaf nodes
    Console.Write("\nNumber of leaf nodes: ");
    Console.WriteLine(binaryTree.NumberOfLeafNodes());

    // Find the height of the tree
    Console.Write("\nHeight of the tree: ");
    Console.WriteLine(binaryTree.Height());
}

/// <summary>
/// BINARY SEARCH TREE class
/// 
/// The Binary search tree is made of nodes;
/// 
/// The code bellow models the binary search tree class that has been implemented;
/// </summary>

public class BinaryTree
{
    private TreeNode root;

    // O(Log n)
    public TreeNode Find(int data)
    {
        if(root != null)
        {
            return root.Find(data);
        }
        else
        {
            return null;
        }
    }

    // O(Log n)
    public TreeNode FindRecursive(int data)
    {
        if(root != null)
        {
            return root.FindRecursive(data);
        }
        else
        {
            return null;
        }
    }

    // O(Log n)
    public void Insert(int data)
    {
        if(root != null)
        {
            root.Insert(data);
        }
        else
        {
            root = new TreeNode(data);
        }
    }

    // O(Log n)
    public void Remove(int data)
    {
        TreeNode currentNode = root;
        TreeNode parent = root;
        bool isLeftChild = false;

        if(currentNode == null)
        {
            return;
        }

        while(currentNode != null && currentNode.Data != data)
        {
            parent = currentNode;

            if(data < currentNode.Data)
            {
                currentNode = currentNode.LeftNode;
                isLeftChild = true;
            }
            else
            {
                currentNode = currentNode.RightNode;
                isLeftChild = false;
            }
        }

        if(currentNode == null)
        {
            return;
        }

        if(currentNode.RightNode == null && currentNode.LeftNode == null)
        {
            if(currentNode == root)
            {
                root = null;
            }
            else
            {
                if(isLeftChild)
                {
                    parent.LeftNode = null;
                }
                else
                {
                    parent.RightNode = null;
                }
            }
        }
        else if(currentNode.RightNode == null)
        {
            if(currentNode == root)
            {
                root = currentNode.LeftNode;
            }
            else
            {
                if(isLeftChild)
                {
                    parent.LeftNode = currentNode.LeftNode;
                }
                else
                {
                    parent.RightNode = currentNode.LeftNode;
                }
            }
        }
        else if(currentNode.LeftNode == null)
        {
            if(currentNode == root)
            {
                root = currentNode.RightNode;
            }
            else
            {
                if(isLeftChild)
                {
                    parent.LeftNode = currentNode.RightNode;
                }
                else
                {
                    parent.RightNode = currentNode.RightNode;
                }
            }
        }
        else
        {
            TreeNode successor = GetSuccessor(currentNode);

            if(currentNode == root)
            {
                root = successor;
            }
            else if(isLeftChild)
            {
                parent.LeftNode = successor;
            }
            else
            {
                parent.RightNode = successor;
            }
        }
    }

    private TreeNode GetSuccessor(TreeNode node)
    {
        TreeNode parentSuccessor = node;
        TreeNode successor = node;
        TreeNode current = node.RightNode;

        // Starting at the right child, go down every left child node
        while (current != null)
        {
            parentSuccessor = successor;
            successor = current;
            current = current.LeftNode;
        }

        // If successor is not just the right node
        if (successor != node.RightNode)
        {
            // Set the left node on the parent node of the successor to the right child node of the successor if it has one
            parentSuccessor.LeftNode = successor.RightNode;
            // Attach the rght child node of the node being deleted to the successor right node
            successor.RightNode = node.RightNode;
        }

        // Atach the left child node of the node being deleted to the successor left node
        successor.LeftNode = node.LeftNode;

        return successor;
    }

    public void SoftDelete(int data)
    {
        TreeNode toDelete = Find(data);
        if(toDelete != null)
        {
            toDelete.Delete();
        }
    }

    // Find the smallest value in the tree
    public Nullable<int> Smallest()
    {
        if(root != null)
        {
            return root.SmallestValue();
        }
        else
        {
            return null;
        }
    }

    public Nullable<int> Largest()
    {
        if(root != null)
        {
            return root.LargestValue();
        }
        else
        {
            return null;
        }
    }

    public int NumberOfLeafNodes()
    {
        if(root == null)
        {
            return 0;
        }

        return root.NumberOfLeafNodes();
    }

    public int Height()
    {
        if(root == null)
        {
            return 0;
        }

        return root.Height();
    }

    // Tree traversal

    /* In order
     * 
     * Goes left to right;
     * Starts at the left node, then goes to parent
     * node, then checks if the right node has a left
     * node, then recursively goes up the tree;
     * It keeps going left, then parent, then right;
     * Numbers will be in ascending order;
     */
    public void InOrderTraversal()
    {
        if(root != null)
            root.InOrderTraversal();
    }

    /* Preorder 
     * 
     * Starts from the root, then goes left, and
     * then goes right recursively;
     */
    public void PreOrderTraversal()
    {
        if (root != null)
            root.PreOrderTraversal();
    }

   /* Postorder
    * 
    * Starts at the left node, then goes right,
    * and then goes root recursively;
    */
    public void PostOrderTraversal()
    {
        if (root != null)
            root.PostOrderTraversal();
    }

}
/// <summary>
/// TREE NODE class
/// 
/// The Binary search tree is made of nodes;
/// 
/// The code bellow models the node class used by the binary search tree;
/// </summary>

public class TreeNode
{
    private int data;

    public int Data
    {
        get { return data; }
    }

    // Left child
    private TreeNode leftNode;

    public TreeNode LeftNode
    {
        get { return leftNode; }
        set { leftNode = value; }
    }

    // Right child
    private TreeNode rightNode;

    public TreeNode RightNode
    {
        get { return rightNode; }
        set { rightNode = value; }
    }

    // Soft delete
    private bool isDeleted;

    public bool IsDeleted
    {
        get { return isDeleted; }
    }

    // Node contructor
    public TreeNode(int value)
    {
        data = value;
    }

    // Set soft delete
    public void Delete()
    {
        isDeleted = true;
    }

    // Recursively calls insert down the tree until it finds an open spot
    public void Insert(int value)
    {
        if(value >= data)
        {
            if(rightNode == null)
            {
                rightNode = new TreeNode(value);
            }
            else
            {
                rightNode.Insert(value);
            }
        }
        else
        {
            if(leftNode == null)
            {
                leftNode = new TreeNode(value);
            }
            else
            {
                leftNode.Insert(value);
            }
        }
    }

    public TreeNode Find(int value)
    {
        // This node is the starting current node
        TreeNode currentNode = this;

        // Loop through this node and all its children
        while(currentNode != null)
        {
            // If the current node data is equal to the value return it
            if(value == currentNode.data && currentNode.isDeleted == false)
            {
                return currentNode;
            }
            // If the value is greater than the current data go to the right child
            else if(value > currentNode.data)
            {
                currentNode = currentNode.rightNode;
            }
            // If the value is smaller than the current data go to the left child
            else
            {
                currentNode = currentNode.leftNode;
            }
        }
        // Node not found
        return null;
    }

    public TreeNode FindRecursive(int value)
    {
        // If value matches node data return the node
        if(value == data && isDeleted == false)
        {
            return this;
        }
        // If the value is less than the current data go to the left child
        else if(value < data && leftNode != null)
        {
            return leftNode.FindRecursive(value);
        }
        // If the value is greater go to the right child
        else if(rightNode != null)
        {
            return rightNode.FindRecursive(value);
        }
        else
        {
            return null;
        }
    }

    public Nullable<int> SmallestValue()
    {
        if (leftNode == null)
        {
            return data;
        }
        else
        {
            return leftNode.SmallestValue();
        }
    }

    public Nullable<int> LargestValue()
    {
        if(rightNode == null)
        {
            return data;
        }
        else
        {
            return rightNode.LargestValue();
        }
    }

    public int NumberOfLeafNodes()
    {
        if(this.leftNode == null && this.rightNode == null)
        {
            return 1;
        }

        int leftLeaves = 0;
        int rightLeaves = 0;

        if(this.leftNode != null)
        {
            leftLeaves = leftNode.NumberOfLeafNodes();
        }
        if(this.rightNode != null)
        {
            rightLeaves = rightNode.NumberOfLeafNodes();
        }

        return leftLeaves + rightLeaves;
    }

    public int Height()
    {
        if(this.leftNode == null && this.RightNode == null)
        {
            return 1;
        }

        int left = 0;
        int right = 0;

        if (this.leftNode != null)
        {
            left = this.leftNode.Height();
        }
        if(this.rightNode != null)
        {
            right = this.rightNode.Height();
        }

        if(left > right)
        {
            return left + 1;
        }
        else
        {
            return right + 1;
        }
    }

    // Left -> Root -> Right nodes recursively
    public void InOrderTraversal()
    {
        // Goes to the left most node and prints its data
        if(leftNode != null)
            leftNode.InOrderTraversal();

        // Print the root node
        Console.Write(data + " ");

        // Goes to the right node and prints it as both its children are null
        if(rightNode != null)
            rightNode.InOrderTraversal();
    }

    // Root -> Left -> Right nodes recursively
    public void PreOrderTraversal()
    {
        // First print the root node
        Console.Write(data + " ");

        // Then goes to the left most child and prints its data
        if(leftNode != null)
            leftNode.PreOrderTraversal();

        // Then goes to the right and prints as both its children are null
        if(rightNode != null)
            RightNode.PreOrderTraversal();
    }

    // Left -> Right -> Root nodes recursively
    public void PostOrderTraversal()
    {
        // First goes to the left most child and prints its data
        if(leftNode!= null)
            leftNode.PostOrderTraversal();

        // Then goes to the right node and prints as both its children are null
        if(rightNode!= null)
            RightNode.PostOrderTraversal();

        // Then print the root node
        Console.Write(data + " ");
    }
}
