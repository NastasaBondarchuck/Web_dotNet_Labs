using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionContainsTests
{
    [Test]
    public void GetIndexOf_EmptySortedList_ReturnFalse()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        Assert.That(sortedList.Contains(rand.Next(-10, 11)), Is.False);
    }
    
    [Test]
    public void GetIndexOf_NotEmptySortedListWithoutSearchedValue_ReturnFalse()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }

        Assert.That(sortedList.Contains(rand.Next(11, 21)), Is.False);
    }
    
    [Test]
    public void GetIndexOf_NotEmptySortedListWithSearchedValue_ReturnTrue()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            int item = 10 - i;
            sortedList.Add(item);
        }

        Assert.That(sortedList.Contains(rand.Next(0, 11)), Is.True);
    }
}