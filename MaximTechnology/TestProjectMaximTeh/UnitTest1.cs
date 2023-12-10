namespace TestProjectMaximTeh;

using NUnit.Framework;

[TestFixture]
public class SortsTests
{

    [Test]
    public void Sort_WhenArrayIsEmpty_DoesNotThrowException()
    {
        // Arrange
        var sorts = new Sorts();
        char[] array = new char[0];

        // Act and Assert
        Assert.DoesNotThrow(() => sorts.Sort(array, 0, 0));
    }

    [Test]
    public void Sort_WhenCalledWithSortedArray_DoesNotChangeArray()
    {
        // Arrange
        var sorts = new Sorts();
        char[] array = { 'a', 'b', 'c', 'd' };

        // Act
        sorts.Sort(array, 0, array.Length - 1);

        // Assert
        char[] expected = { 'a', 'b', 'c', 'd' };
        Assert.AreEqual(expected, array);
    }
    

    [Test]
    public void ReverseHalves_WhenEvenLength_ReturnsCorrectResult()
    {
        // Arrange
        var stringManipulation = new StringManipulation();
        string input = "abcd";

        // Act
        string result = stringManipulation.ReverseHalves(input);

        // Assert
        Assert.AreEqual("badc", result);
    }
    

    [Test]
    public void CountCharacters_WhenStringIsEmpty_ReturnsEmptyDictionary()
    {
        // Arrange
        var characterCounter = new CharacterCounter();
        string input = "";

        // Act
        Dictionary<char, int> result = characterCounter.CountCharacters(input);

        // Assert
        Assert.IsEmpty(result);
    }

    
    [Test]
    public void InOrderTraversal_WhenTreeIsEmpty_DoesNotThrowException()
    {
        // Arrange
        var treeSort = new TreeSort();

        // Act and Assert
        Assert.DoesNotThrow(() => treeSort.InOrderTraversal());
    }



    [Test]
    public void RunTreeSort_WhenArrayIsEmpty_DoesNotThrowException()
    {
        // Arrange
        var treeSort = new TreeSort();
        char[] array = new char[0];

        // Act and Assert
        Assert.DoesNotThrow(() => treeSort.RunTreeSort(array));
    }

}
