using System;
using System.Linq;

class StringManipulation
{
    public string GetUserInput()
    {
        Console.Write("Введите строку: ");
        return Console.ReadLine();
    }

    public bool IsEvenLength(string str) => str.Length % 2 == 0;

    public string Reverse(string str) => new string(str.ToCharArray().Reverse().ToArray());

    public string ReverseHalves(string str)
    {
        int midpoint = str.Length / 2;
        return Reverse(str.Substring(0, midpoint)) + Reverse(str.Substring(midpoint));
    }

    public string ConcatenateWithReversed(string str) => str + Reverse(str);

    public char[] EnglishOrNot(string str)
    {
        string inputString = str;
        string engLngStr = "abcdefghijklmnopqrstuvwxyz";
        char[] engLngChr = engLngStr.ToCharArray();

        char[] extraCharacters = inputString.ToCharArray().Where(c => !engLngChr.Contains(c)).ToArray();

        return extraCharacters;
    }

    public string FindLongestSubs(string str)
    {
        string vowels = "aeiou";
        char[] first = vowels.ToCharArray();
        string input = str;

        int indexFirst = input.IndexOfAny(first);
        int indexSecond = input.LastIndexOfAny(first);

        if (indexFirst >= 0 && indexSecond >= 0)
        {
            string substring = input.Substring(indexFirst, indexSecond - indexFirst + 1);
            if (substring.Length >= 2)
            {
                Console.WriteLine(substring);
            }
            else
            {
                Console.Write("введен один гласный символ - ");
                Console.Write(substring);
            }
        }
        else
        {
            Console.WriteLine("не введено ни одной гласной буквы");
        }

        return null;
    }
}