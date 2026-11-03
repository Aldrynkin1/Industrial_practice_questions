using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Demonstrates lazy generation of even numbers with yield return.
/// </summary>
public sealed class Task39_EvenNumberGenerator : ITask
{
    /// <inheritdoc />
    public string Title => "yield return: генератор чётных чисел";

    /// <inheritdoc />
    public string Description => "Генерирует чётные числа лениво, по одному элементу во время foreach.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать IEnumerable<int> GetEvenNumbers(int max) через yield return без промежуточного списка.",
        "Показать перебор через foreach и вывод внутри генератора, демонстрирующий ленивость."
    ];

    /// <inheritdoc />
    public void Run()
    {
        const int max = 10;
        Console.WriteLine($"Чётные числа от 0 до {max}:");
        foreach (int number in GetEvenNumbers(max))
        {
            Console.WriteLine($"  получено в foreach: {number}");
        }
    }

    private static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (long number = 0; number <= max; number += 2)
        {
            Console.WriteLine($"  генератор подготовил: {number}");
            yield return (int)number;
        }
    }
}
