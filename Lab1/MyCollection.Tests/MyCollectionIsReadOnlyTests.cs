using Lab1;

namespace MyCollection.Tests;

[TestFixture]
public class MyCollectionIsReadOnlyTests
{
    [Test]
    public void IsReadOnly_EverySortedList_ReturnFalse()
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        
        Assert.That(sortedList.IsReadOnly, Is.EqualTo(false));
    }
}
