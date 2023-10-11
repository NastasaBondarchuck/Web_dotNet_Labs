namespace Lab1;
internal class Program
{
    static void Main(string[] args)
    {
        MySortedList<int> sortedList = new MySortedList<int>();
        
        sortedList.CountIncrease += sender => sender.Count++;
        sortedList.CountDecrease += sender => sender.Count--;
        
        List<int> list = new List<int> {1, 19, 33, 12, 0, -9, 18};
        
        Print(list, "List with base values:");
        foreach (var number in list) sortedList.Add(number);
        Print(sortedList, "Base SortedList:");
        Console.WriteLine($"\nSortedList Count:{sortedList.Count}");
        
        sortedList.Add(4);
        Print(sortedList, "SortedList after adding item 4:");
        sortedList.Add(-15);
        Print(sortedList, "SortedList after adding item -15:");
        sortedList.Add(19);
        Print(sortedList, "SortedList after adding item 19:");
        sortedList.Remove(1);
        Print(sortedList, "SortedList after removing item 1:");
        sortedList.RemoveByIndex(5);
        Print(sortedList, "SortedList after removing item by index 5:");
        Console.WriteLine($"\nSortedList Count:{sortedList.Count}");
        
        int index = sortedList.GetIndexOf(19);
        int value = sortedList.GetByIndex(index);
        Console.WriteLine($"\n\nIndex: {index}, Value: {value}");
        
        Console.WriteLine($"\nSortedList contains item 45: {sortedList.Contains(45)}");
        Console.WriteLine($"SortedList contains item 19: {sortedList.Contains(19)}");
        sortedList.RemoveAll(19);
        
        Print(sortedList, "SortedList after removing all items equal 19:");
        Console.WriteLine($"\nSortedList Count:{sortedList.Count}");
        int[] arr = new int[15];
        for (int i = 0; i < 7; i++) arr[i] = i + 1;
        Print(arr, "Array before CopyTo:");
        sortedList.CopyTo(arr, 5);
        Print(arr, "Array after CopyTo:");
        int[] valuesArray = sortedList.GetValuesArray();
        Print(valuesArray, "Values Array:");
        List<int> valuesList = sortedList.GetValuesList();
        Print(valuesList, "Values List:");
        sortedList.Clear();
        Print(sortedList, "Cleared SortedList (nothing is expected):");
        Console.ReadLine();
    }

    private static void Print(List<int> list, string message)
    {
        Console.WriteLine($"\n{message}");
        foreach (var item in list) Console.Write($"{item}  ");
    }

    private static void Print(int[] array, string message)
    {
        Console.WriteLine($"\n{message}");
        foreach (var item in array)  Console.Write($"{item}  ");
    }

    private static void Print(MySortedList<int> sortedList, string message)
    {
        Console.WriteLine($"\n{message}");
        foreach (var item in sortedList)  Console.Write($"{item}  ");
    }
    
}