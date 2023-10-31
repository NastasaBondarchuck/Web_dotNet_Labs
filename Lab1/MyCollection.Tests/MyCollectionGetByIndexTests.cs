using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionGetByIndexTests
{
    [Test]
    public void GetByIndex_EmptySortedList_ReturnException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        
        Assert.Throws<Exception>(() => sortedList.GetByIndex(rand.Next(0, 11)));
    }

    [Test]
    public void GetByIndex_IndexLessThanZeroInNotEmptySortedList_ReturnIndexOutOfRangeException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }
        
        Assert.Throws<IndexOutOfRangeException>(() => sortedList.GetByIndex(rand.Next(-10, 0)));
    }
    
    [Test]
    public void GetByIndex_IndexGreaterThanCountInNotEmptySortedList_ReturnIndexOutOfRangeException()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }
        
        Assert.Throws<IndexOutOfRangeException>(() => sortedList.GetByIndex(rand.Next(10, 20)));
    }    
    
    [Test]
    public void GetByIndex_IndexIsZeroInNotEmptySortedList_ReturnIndexOutOfRangeException()
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
        
        Assert.That(sortedList.GetByIndex(0), Is.EqualTo(list[0]));
    }
    
    [Test]
    public void GetByIndex_IndexIsCorrectInNotEmptySortedList_ReturnCurrentItem()
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
        int index = rand.Next(1, 10);
        
        Assert.That(sortedList.GetByIndex(index), Is.EqualTo(list[index]));
    }
}