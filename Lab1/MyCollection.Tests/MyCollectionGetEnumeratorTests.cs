using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionGetEnumeratorTests
{
    [Test]
    public void GetEnumerator_EmptySortedList_ReturnMoveNextFalseCurrentDefault()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        
        using var enumerator = sortedList.GetEnumerator();
        var resultMoveNext = enumerator.MoveNext();
        
        Assert.That(resultMoveNext, Is.False);
    }

    [Test]
    public void GetEnumerator_NotEmptySortedList_ReturnMoveNextTrue()
    {
        Random rand = new Random();
        MySortedList<int> sortedList = new MySortedList<int>();
        List<int> list = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            int item = rand.Next(-10, 11);
            sortedList.Add(item);
        }
        foreach (var item in sortedList) list.Add(item);
        
        Assert.That(sortedList.ToList(), Is.EqualTo(list));
    }

    [Test]
    public void GetEnumerator_ResetInNotEmptySortedList_ReturnHead()
    {
        Random rand = new Random();
        MySortedList<int> sortedList = new MySortedList<int>();
        
        sortedList.Add(rand.Next(-10, 11));
        using var enumerator = sortedList.GetEnumerator();
        enumerator.MoveNext();
        enumerator.Reset();
        
        Assert.That(sortedList.GetByIndex(0), Is.EqualTo(enumerator.Current));
    }
}
