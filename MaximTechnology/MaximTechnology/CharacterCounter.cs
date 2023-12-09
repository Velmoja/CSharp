using System.Collections.Generic;

class CharacterCounter
{
    public Dictionary<char, int> CountCharacters(string str)
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