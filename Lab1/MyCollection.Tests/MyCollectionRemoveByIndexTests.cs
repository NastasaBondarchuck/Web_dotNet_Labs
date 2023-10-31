using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionRemoveByIndexTests
{
    [Test]
    public void RemoveByIndex_EmptySortedList_ReturnException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        Assert.Throws<Exception>(() => sortedList.RemoveByIndex(rand.Next(0, 11)));
    }

    [Test]
    public void RemoveByIndex_IndexLessThanZeroWithNotEmptySortedList_ReturnIndexOutOfRangeException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }

        Assert.Throws<IndexOutOfRangeException>(() => sortedList.RemoveByIndex(rand.Next(-10, 0)));
    }

    [Test]
    public void RemoveByIndex_IndexGreaterThanNotEmptySortedListCount_ReturnIndexOutOfRangeException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }

        Assert.Throws<IndexOutOfRangeException>(() => sortedList.RemoveByIndex(rand.Next(10, 20)));
    }
    
    [Test]
    public void RemoveByIndex_IndexGreaterThanZeroWithNotEmptySortedList_ReturnTrueAndSortedListWithoutValueByGivenIndex()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        List<int> list = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            list.Add(item);
            sortedList.Add(item);
        }
        list.Sort();
        int indexToRemove = rand.Next(1, 10);
        list.RemoveAt(indexToRemove);
        
        Assert.That(sortedList.RemoveByIndex(indexToRemove), Is.EqualTo(true));
        Assert.That(sortedList.ToList(), Is.EqualTo(list));
    }

    [Test]
    public void RemoveByIndex_IndexIsZeroWithNotEmptySortedList_ReturnTrueAndSortedListWithoutValueByGivenIndex()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }
        int indexToRemove = 0;
        int headNext = sortedList.GetByIndex(1);
        
        Assert.That(sortedList.RemoveByIndex(indexToRemove), Is.EqualTo(true));
        Assert.That(sortedList.GetByIndex(0), Is.EqualTo(headNext));
    }
}