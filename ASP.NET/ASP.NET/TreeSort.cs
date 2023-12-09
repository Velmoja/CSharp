namespace ASP.NET;

public class TreeSort
{
    private TreeNode root;

    public void Insert(char data)
    {
        root = InsertRec(root, data);
    }

    private TreeNode InsertRec(TreeNode root, char data)
    {
        if (root == null)
        {
            root = new TreeNode(data);
        }
        else if (data < root.Data)
        {
            root.Left = InsertRec(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRec(root.Right, data);
        }
        else
        {
            root.Count++;
        }

        return root;
    }

    public void InOrderTraversal()
    {
        InOrderTraversalRec(root);
    }

    private void InOrderTraversalRec(TreeNode root)
    {
        if (root != null)
        {
            InOrderTraversalRec(root.Left);
            
            for (int i = 0; i < root.Count; i++)
            {
                Console.Write(root.Data + " ");
            }

            InOrderTraversalRec(root.Right);
        }
    }

    public char[] Sort(char[] data)
    {
        char[] tempData = new char[data.Length];
        Array.Copy(data, tempData, data.Length);
        char[] sortedData = Behave(ref tempData);
        return sortedData;
    }

    private char[] Behave(ref char[] data)
    {
        var treeNode = new TreeNode(data[0]);
        for (int i = 1; i < data.Length; i++)
        {
            Insert(data[i]);
        }

        return treeNode.Transform();
    }

}

public class TreeNode
{
    public char Data;
    public int Count;
    public TreeNode? Left; 
    public TreeNode? Right;

    public TreeNode(char data)
    {
        Data = data;
        Count = 1;
        Left = Right = null;
    }
    public char[] Transform(List<char>? elements = null)
    {
        if (elements == null)
        {
            elements = new List<char>();
        }

        if (Left != null)
        {
            Left.Transform(elements);
        }

        elements.Add(Data);

        if (Right != null)
        {
            Right.Transform(elements);
        }

        return elements.ToArray();
    }
}