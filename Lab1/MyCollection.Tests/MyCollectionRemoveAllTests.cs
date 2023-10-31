using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionRemoveAllTests
{
    [Test]
    public void RemoveAll_NotContainsValueToRemove_ReturnFalse()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        Random rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }
        
        Assert.That(sortedList.RemoveAll(rand.Next(11, 21)), Is.EqualTo(false));
    }
    
    [Test]
    public void RemoveAll_ContainsValueToRemove_ReturnTrueAndSortedListWithoutAllMatchedValues()
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
        list.Sort();
        int itemToRemove = rand.Next(1, 11);
        while (list.Contains(itemToRemove)) list.Remove(itemToRemove);
        
        Assert.That(sortedList.RemoveAll(itemToRemove), Is.EqualTo(true));
        Assert.That(sortedList.ToList(), Is.EqualTo(list));
    }
}