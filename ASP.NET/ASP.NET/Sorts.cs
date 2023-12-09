using System;
using ASP.NET;

public static class Sorts
{
    public static char[] Sort(char[] data, SortType sortType)
    {
        switch (sortType)
        {
            case SortType.QuickSort:
                return new QuickSort().Sort(data);
            case SortType.TreeSort:
                return new TreeSort().Sort(data);
            default:
                return null;
        }
    }
}