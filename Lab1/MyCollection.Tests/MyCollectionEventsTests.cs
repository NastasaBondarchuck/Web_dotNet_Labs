using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionEventsTests
{
    [Test]
    public void Events_CountIncrease_ReturnCountIncreasedByOne()
    {
        Random rand = new Random();
        MySortedList<int> sortedList = new MySortedList<int>();
        int count = sortedList.Count;
        sortedList.CountIncrease += delegate { count += 1; };
        
        sortedList.Add(rand.Next(-10, 11));
        
        Assert.That(count, Is.EqualTo(sortedList.Count));
    }
    
    [Test]
    public void Events_CountDecrease_ReturnCountDecreasedByOne()
    {
        Random rand = new Random();
        MySortedList<int> sortedList = new MySortedList<int>();
        
        int item = rand.Next(-10, 11);
        sortedList.Add(item);
        int count = sortedList.Count;
        sortedList.CountDecrease += delegate { count -= 1; };
        sortedList.Remove(item);
        
        Assert.That(count, Is.EqualTo(sortedList.Count));
    }
}