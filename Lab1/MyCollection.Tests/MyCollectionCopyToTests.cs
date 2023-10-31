using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionCopyToTests
{
    [Test]
    public void CopyTo_InsertDiapasonLessThanNotEmptySortedListCount_ReturnIndexOutOfRangeException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        int[] array = { 1, 2, 3, 4, 5};

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }

        Assert.Throws<IndexOutOfRangeException>(() => sortedList.CopyTo(array, rand.Next(0, 5)));
    }
    
    [Test]
    public void CopyTo_IndexLessThanZeroWithNotEmptySortedList_ReturnIndexOutOfRangeException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        int[] array = { 1, 2, 3, 4, 5};

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }

        Assert.Throws<IndexOutOfRangeException>(() => sortedList.CopyTo(array, rand.Next(-10, 0)));
    }
    
    [Test]
    public void CopyTo_EmptySortedList_ReturnArrayWithNoChanges()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        int[] arrayBeforeCoping = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int[] arrayAfterCoping = new int[10];
        arrayBeforeCoping.CopyTo(arrayAfterCoping, 0);
        sortedList.CopyTo(arrayAfterCoping, rand.Next(0, 10));
        
        Assert.That(arrayAfterCoping, Is.EqualTo(arrayBeforeCoping));
    }

}