using System;

class Sorts
{
    public void Sort(char[] array, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(array, low, high);

            Sort(array, low, partitionIndex - 1);
            Sort(array, partitionIndex + 1, high);
        }
    }

    public static int Partition(char[] array, int low, int high)
    {
        char pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        
        char tempPivot = array[i + 1];
        array[i + 1] = array[high];
        array[high] = tempPivot;

        return i + 1;
    }
    
     public static void PrintArray(char[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

     public void RunQuickSort(char[] array)
     {
         char[] masForSort = array;
         Sort(masForSort,0,masForSort.Length-1 );
         Console.WriteLine("Сортировка методом Quicksort:");
         PrintArray(masForSort);
     }
}

class TreeNode
{
    public char Data;
    public int Count;
    public TreeNode Left, Right;

    public TreeNode(char data)
    {
        Data = data;
        Count = 1;
        Left = Right = null;
    }
}

class TreeSort
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

    public void RunTreeSort(char[] array)
    {
        char[] masForSort = array;
        TreeSort treeSort = new TreeSort();
        foreach (var character in masForSort)
        {
            treeSort.Insert(character);
        }
        Console.WriteLine("Сортировка методом TreeSort:");
        treeSort.InOrderTraversal();
        Console.WriteLine();
    }
}
