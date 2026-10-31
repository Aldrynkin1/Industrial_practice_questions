using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Determines whether an integer is even or odd in two ways.
/// </summary>
public sealed class Task04_EvenOrOdd : ITask
{
    /// <inheritdoc />
    public string Title => "Проверка чётности числа";

    /// <inheritdoc />
    public string Description => "Определяет чётность введённого числа двумя отдельными методами.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "В одном методе проверить остаток от деления на 2.",
        "В другом методе использовать тернарный оператор."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int? number = ConsoleHelper.ReadInt("Введите целое число: ");
        if (number is null)
        {
            return;
        }

        Console.WriteLine($"Проверка через остаток: {DescribeWithRemainder(number.Value)}");
        Console.WriteLine($"Проверка через тернарный оператор: {DescribeWithConditional(number.Value)}");
    }

    private static string DescribeWithRemainder(int number)
    {
        if (number % 2 == 0)
        {
            return "чётное";
        }

        return "нечётное";
    }

    private static string DescribeWithConditional(int number) =>
        number % 2 == 0 ? "чётное" : "нечётное";
}
