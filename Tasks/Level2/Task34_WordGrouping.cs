using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates LINQ grouping and sorting of words by their first letter.
/// </summary>
public sealed class Task34_WordGrouping : ITask
{
    /// <inheritdoc />
    public string Title => "LINQ: группировка слов по первой букве";

    /// <inheritdoc />
    public string Description => "Группирует слова по первой букве и сортирует группы и слова.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать список из десяти и более непустых слов.",
        "Сгруппировать через GroupBy по первой букве.",
        "Отсортировать группы и слова внутри каждой группы."
    ];

    /// <inheritdoc />
    public void Run()
    {
        string[] words =
        [
            "арбуз", "апельсин", "авокадо", "банан", "бор", "берёза",
            "вишня", "виноград", "вода", "груша", "гриб", "город"
        ];

        foreach (var group in words
                     .GroupBy(word => char.ToUpperInvariant(word[0]))
                     .OrderBy(group => group.Key))
        {
            string sortedWords = string.Join(", ",
                group.OrderBy(word => word, StringComparer.CurrentCulture));
            Console.WriteLine($"{group.Key}: {sortedWords}");
        }
    }
}
