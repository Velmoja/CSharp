namespace ASP.NET;

public class QuickSort
{
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
    

    public char[] Sort(char[] data)
    {
        char[] tempData = new char[data.Length];
        Array.Copy(data, tempData, data.Length);
        char[] sortedData = Behave(ref tempData, 0, data.Length - 1);
        return sortedData;
    }

    private char[] Behave(ref char[] data, int left, int right)
    {
        if (left < right)
        {
            int partitionIndex = Partition(data, left, right);

            Behave(ref data, left, partitionIndex - 1);
            Behave(ref data, partitionIndex + 1, right);
        }

        return data;
    }
}