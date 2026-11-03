using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Finds duplicate integers using a hash set and LINQ grouping.
/// </summary>
public sealed class Task36_ListDuplicates : ITask
{
    /// <inheritdoc />
    public string Title => "Дубликаты в List: HashSet и GroupBy";

    /// <inheritdoc />
    public string Description => "Ищет повторяющиеся числа двумя независимыми способами и сравнивает результаты.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Отдельными методами найти дубликаты через HashSet<int> и LINQ GroupBy.",
        "Проверять Contains перед добавлением элемента в HashSet.",
        "Показать оба результата на списке с повторами и убедиться, что наборы совпадают."
    ];

    /// <inheritdoc />
    public void Run()
    {
        List<int> numbers = [4, 7, 2, 4, 9, 7, 7, 1, 2, 5];
        HashSet<int> hashSetDuplicates = FindDuplicatesWithHashSet(numbers);
        HashSet<int> groupByDuplicates = FindDuplicatesWithGroupBy(numbers);

        Console.WriteLine($"Исходный список: {string.Join(", ", numbers)}");
        Console.WriteLine($"HashSet: {string.Join(", ", hashSetDuplicates.Order())}");
        Console.WriteLine($"GroupBy: {string.Join(", ", groupByDuplicates.Order())}");
        Console.WriteLine($"Наборы совпадают: {hashSetDuplicates.SetEquals(groupByDuplicates)}");
    }

    private static HashSet<int> FindDuplicatesWithHashSet(IEnumerable<int> numbers)
    {
        HashSet<int> seen = [];
        HashSet<int> duplicates = [];
        foreach (int number in numbers)
        {
            if (seen.Contains(number))
            {
                duplicates.Add(number);
            }
            else
            {
                seen.Add(number);
            }
        }

        return duplicates;
    }

    private static HashSet<int> FindDuplicatesWithGroupBy(IEnumerable<int> numbers) =>
        numbers.GroupBy(number => number)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToHashSet();
}
