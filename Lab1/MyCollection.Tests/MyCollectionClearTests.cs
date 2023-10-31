using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionClearTests
{
    [Test]
    public void Clear_NotEmptySortedList_ReturnContainsFalseAndCountEqualToZero()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int item = 10 - i;
            sortedList.Add(item);
        }
        sortedList.Clear();
        
        Assert.That(sortedList.Count, Is.EqualTo(0));
        Assert.That(sortedList.Contains(rand.Next(1, 11)), Is.EqualTo(false));
    }
    
    [Test]
    public void Clear_EmptySortedList_ReturnContainsFalseAndCountEqualToZero()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();
        sortedList.Clear();
        
        Assert.That(sortedList.Count, Is.EqualTo(0));
        Assert.That(sortedList.Contains(rand.Next(1, 11)), Is.EqualTo(false));
    }
}