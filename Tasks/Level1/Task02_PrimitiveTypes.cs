using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Demonstrates primitive C# data types.
/// </summary>
public sealed class Task02_PrimitiveTypes : ITask
{
    /// <inheritdoc />
    public string Title => "Переменные и типы данных";

    /// <inheritdoc />
    public string Description => "Создаёт значения разных типов и показывает имя, значение и фактический тип.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать типы int, long, double, float, decimal, bool, char и string.",
        "Для float использовать суффикс f, для decimal — суффикс m.",
        "Для получения имени типа использовать GetType().Name."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int age = 21;
        long population = 8_000_000_000L;
        double temperature = 21.75;
        float weight = 68.5f;
        decimal price = 1_299.99m;
        bool isStudent = true;
        char grade = 'A';
        string name = "Алибек";

        PrintValue(nameof(age), age);
        PrintValue(nameof(population), population);
        PrintValue(nameof(temperature), temperature);
        PrintValue(nameof(weight), weight);
        PrintValue(nameof(price), price);
        PrintValue(nameof(isStudent), isStudent);
        PrintValue(nameof(grade), grade);
        PrintValue(nameof(name), name);
    }

    private static void PrintValue<T>(string name, T value)
    {
        Console.WriteLine($"{name}: {value} (тип: {value?.GetType().Name ?? typeof(T).Name})");
    }
}
