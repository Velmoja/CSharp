using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();
        
        Console.WriteLine(IsEvenLength(input) ? ReverseHalves(input) : ConcatenateWithReversed(input));
    }
    static bool IsEvenLength(string str) => str.Length % 2 == 0;

    static string Reverse(string str) => new string(str.ToCharArray().Reverse().ToArray());

    static string ReverseHalves(string str)
    {
        int midpoint = str.Length / 2;
        return Reverse(str.Substring(0, midpoint)) + Reverse(str.Substring(midpoint));
    }
    
    static string ConcatenateWithReversed(string str) => str + Reverse(str);
}