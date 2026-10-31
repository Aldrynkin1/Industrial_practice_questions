using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates nullable values, null-coalescing, and null-conditional access.
/// </summary>
public sealed class Task23_NullableValues : ITask
{
    private readonly Dictionary<string, int> _values = new(StringComparer.Ordinal)
    {
        ["answer"] = 42
    };

    /// <inheritdoc />
    public string Title => "Nullable-типы, ?? и ?.";

    /// <inheritdoc />
    public string Description => "Показывает nullable-результат поиска и безопасную работу с null.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать int? FindValue(string key).",
        "Использовать ??, ?. и HasValue/Value с проверкой.",
        "Показать найденный и отсутствующий ключи."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int? found = FindValue("answer");
        int? missing = FindValue("missing");
        Console.WriteLine($"Найденное значение: {found ?? -1}");
        Console.WriteLine($"Значение по умолчанию: {missing ?? -1}");

        if (found.HasValue)
        {
            Console.WriteLine($"HasValue / Value: {found.Value}");
        }

        if (!missing.HasValue)
        {
            Console.WriteLine("Для отсутствующего ключа значение равно null.");
        }

        Person? person = new("Мария");
        Person? absentPerson = null;
        Console.WriteLine($"?. для существующего объекта: {person?.Name ?? "имя неизвестно"}");
        Console.WriteLine($"?. для null: {absentPerson?.Name ?? "имя неизвестно"}");
    }

    private int? FindValue(string key) =>
        _values.TryGetValue(key, out int value) ? value : null;

    private sealed record Person(string Name);
}
