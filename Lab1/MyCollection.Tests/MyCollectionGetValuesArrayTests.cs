using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionGetValuesArrayTests
{
    [Test]
    public void GetValuesArray_NotEmptySortedList_ReturnEmptyArray()
    {
        Random rand = new Random();
        MySortedList<int> sortedList = new MySortedList<int>();
        int[] array = new int[10];
        
        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            array[i] = item;
            sortedList.Add(item);
        }
        Array.Sort(array);
        var resultArray = sortedList.GetValuesArray();
        
        Assert.That(resultArray, Is.EqualTo(array));
    }

    [Test]
    public void GetValuesArray_EmptySortedList_ReturnException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        
        Assert.Throws<Exception>(() => sortedList.GetValuesArray() ) ;
    }
}