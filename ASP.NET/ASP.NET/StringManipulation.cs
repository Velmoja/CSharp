using System;
using System.Linq;
using MaximTechnology;

class StringManipulation
{
    public string Manipulate(string str)
    {
        return IsEvenLength(str) ? ReverseHalves(str) : ConcatenateWithReversed(str);
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
        string substring = ""; 

        int indexFirst = input.IndexOfAny(first);
        int indexSecond = input.LastIndexOfAny(first);

        if (indexFirst >= 0 && indexSecond >= 0)
        {
            substring = input.Substring(indexFirst, indexSecond - indexFirst + 1);
        }

        return substring;
    }

    public string RemoveRandomChar(string str)
    {
        int randomIndex = RandomNumber.GetRandomNumberFromApi(str.Length).Result;

        if (randomIndex >= 0 && randomIndex < str.Length)
        {
            return str.Remove(randomIndex - 1, 1);
        }

        throw new IndexOutOfRangeException();
    }
}