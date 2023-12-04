using System;
using System.Linq;
class Program
{
    
    static void Main()
    {
        string inversStr = "";;
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();
        char[] invalidCharacters = EnglishOrNot(input);
        
        if (input.Length % 2 != 0)
        {
            inversStr = ConcatenateWithReversed(input);
        }
        else
        {
            inversStr = ReverseHalves(input);
        }

        if (invalidCharacters.Length == 0)
        {
            Console.WriteLine(IsEvenLength(input) ? ReverseHalves(input) : ConcatenateWithReversed(input));
            
            Dictionary<char, int> charCount = CountCharacters(inversStr);
            Console.WriteLine("Символы и их количество в строке:");
            foreach (var entry in charCount)
            {
                Console.WriteLine($"'{entry.Key}' - {entry.Value}");
            }
        }
        else
        {
            Console.Write("Ошибка! Были введены неподходящие символы: ");
            Console.Write(string.Join(" ", invalidCharacters));
        }
    }

    static bool IsEvenLength(string str) => str.Length % 2 == 0;

    static string Reverse(string str) => new string(str.ToCharArray().Reverse().ToArray());

    static string ReverseHalves(string str)
    {
        int midpoint = str.Length / 2;
        return Reverse(str.Substring(0, midpoint)) + Reverse(str.Substring(midpoint));
    }

    static string ConcatenateWithReversed(string str) => str + Reverse(str);

    static char[] EnglishOrNot(string str)
    {
        string inputString = str;
        string engLngStr = "abcdefghijklmnopqrstuvwxyz";
        char[] engLngChr = engLngStr.ToCharArray();

        char[] extraCharacters = inputString.ToCharArray().Where(c => !engLngChr.Contains(c)).ToArray();
        
        return extraCharacters;
    }

    static Dictionary<char, int> CountCharacters(string str)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in str)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        return charCount;
    }
}