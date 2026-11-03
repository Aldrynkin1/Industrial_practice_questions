using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Compares repeated middle insertions in a list and linked list.
/// </summary>
public sealed class Task38_ListVsLinkedList : ITask
{
    /// <inheritdoc />
    public string Title => "List<T> vs LinkedList<T>: вставка в середину";

    /// <inheritdoc />
    public string Description => "Сравнивает время тысячи вставок в середину коллекций из 100 000 элементов.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Создать List<int> и LinkedList<int> по 100 000 элементов.",
        "Вставить по 1 000 элементов в середину и измерить время через Stopwatch.",
        "Объяснить, что LinkedList быстрее вставляет при известном узле, но медленнее ищет элемент по индексу."
    ];

    /// <inheritdoc />
    public void Run()
    {
        const int initialCount = 100_000;
        const int insertCount = 1_000;
        List<int> list = Enumerable.Range(0, initialCount).ToList();
        LinkedList<int> linkedList = new(Enumerable.Range(0, initialCount));
        int middleIndex = initialCount / 2;
        LinkedListNode<int> middleNode = linkedList.First!;
        for (int index = 0; index < middleIndex; index++)
        {
            middleNode = middleNode.Next!;
        }

        // Find the linked-list node before timing so the benchmark measures insertion, not index lookup.
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int index = 0; index < insertCount; index++)
        {
            list.Insert(middleIndex, -index);
        }

        stopwatch.Stop();
        TimeSpan listTime = stopwatch.Elapsed;

        stopwatch.Restart();
        for (int index = 0; index < insertCount; index++)
        {
            linkedList.AddBefore(middleNode, -index);
        }

        stopwatch.Stop();

        Console.WriteLine($"List<int>: {listTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"LinkedList<int>: {stopwatch.Elapsed.TotalMilliseconds:F2} мс");
        Console.WriteLine(
            "LinkedList вставляет быстрее, когда нужный узел уже найден; поиск узла по индексу требует обхода, " +
            "тогда как List быстро обращается по индексу, но сдвигает элементы при вставке.");
    }
}
