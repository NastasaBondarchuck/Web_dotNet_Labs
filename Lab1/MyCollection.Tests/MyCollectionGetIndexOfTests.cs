using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionGetIndexOfTests
{
    [Test]
    public void GetIndexOf_NotContainsItem_ReturnException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }
        
        Assert.Throws<Exception>(() => sortedList.GetIndexOf(rand.Next(11, 20)));
    }
    
    [Test]
    public void GetIndexOf_ContainsItem_ReturnItemIndex()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        List<int> list = new List<int>();
        
        for (int i = 0; i < 10; i++)
        {
            int item = 10 - i;
            list.Add(item);
            sortedList.Add(item);
        }
        int searchedItem = rand.Next(1, 11);
        list.Sort();
        
        Assert.That(sortedList.GetIndexOf(searchedItem), Is.EqualTo(list.IndexOf(searchedItem)));
    }

    [Test]
    public void GetIndexOf_EmptySortedList_ReturnException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        Assert.Throws<Exception>(() => sortedList.GetIndexOf(rand.Next(-10, 11)));
    }
}