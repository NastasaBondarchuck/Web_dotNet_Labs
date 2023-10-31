using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionAddTests
{
    [Test]
    public void Add_SortedList_ReturnSortedList()
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
        
        Assert.That(sortedList.ToList(), Is.EqualTo(list));
    }
}