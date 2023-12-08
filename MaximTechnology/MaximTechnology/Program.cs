using System;
using System.Linq;
using MaximTechnology;

class Program
{
    static void Main()
    {
        StringManipulation stringManipulation = new StringManipulation();
        Sorts sorts = new Sorts();
        TreeSort treeSort = new TreeSort();
        RandomNumber randomNumber = new RandomNumber();
        
        string input = stringManipulation.GetUserInput();
        char[] invalidCharacters = stringManipulation.EnglishOrNot(input);
        
        if (invalidCharacters.Length == 0)
        {
            if (stringManipulation.IsEvenLength(input))
            {
                Console.WriteLine(stringManipulation.ReverseHalves(input));
            }
            else
            {
                Console.WriteLine(stringManipulation.ConcatenateWithReversed(input));
            }
            
            string inversStr = stringManipulation.IsEvenLength(input) ? stringManipulation.ReverseHalves(input) : stringManipulation.ConcatenateWithReversed(input);
            
            CharacterCounter characterCounter = new CharacterCounter();
            Dictionary<char, int> charCount = characterCounter.CountCharacters(inversStr);

            Console.WriteLine("Символы и их количество в строке:");
            foreach (var entry in charCount)
            {
                Console.WriteLine($"'{entry.Key}' - {entry.Value}");
            }

            Console.Write("Самая длинная подстрока начинающаяся и заканчивающаяся на гласную: ");
            string subStr = stringManipulation.FindLongestSubs(inversStr);
            Console.Write(subStr);
            
            char[] masForSort = inversStr.ToCharArray();

            Console.WriteLine("Выберите тип сортировки:");
            Console.WriteLine("1. Быстрая сортировка (Quicksort)");
            Console.WriteLine("2. Сортировка деревом (Tree sort)");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    sorts.RunQuickSort(masForSort);
                    break;
                case 2:
                    treeSort.RunTreeSort(masForSort);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
            
            int randomIndex = randomNumber.GetRandomNumberFromApi(inversStr.Length).Result;
            
            if (randomIndex >= 0 && randomIndex < inversStr.Length)
            {
                inversStr = inversStr.Remove(randomIndex-1, 1);
                Console.WriteLine($"Строка после удаления символа: {inversStr}");
            }
            else
            {
                Console.WriteLine("Ошибка: случайное число вне допустимого диапазона.");
            }
        }
        else
        {
            Console.Write("Ошибка! Были введены неподходящие символы: ");
            Console.Write(string.Join(" ", invalidCharacters));
        }

    }
    
}