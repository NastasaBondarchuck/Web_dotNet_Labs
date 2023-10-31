using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionGetValuesListTests
{
    [Test]
    public void GetValuesList_NotEmptySortedList_ReturnEmptyList()
    {
        Random rand = new Random();
        MySortedList<int> sortedList = new MySortedList<int>();
        List<int> list = new List<int>();
        
        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            list.Add(item);
            sortedList.Add(item);
        }
        list.Sort();
        var resultList = sortedList.GetValuesList();
        
        Assert.That(resultList, Is.EqualTo(list));
    }
    
    [Test]
    public void GetValuesList_EmptySortedList_ReturnException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        
        Assert.Throws<Exception>(() => sortedList.GetValuesList() ) ;
    }
}