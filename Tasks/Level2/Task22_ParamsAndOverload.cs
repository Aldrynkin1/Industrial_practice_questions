using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates summation with params and an array argument.
/// </summary>
public sealed class Task22_ParamsAndOverload : ITask
{
    /// <inheritdoc />
    public string Title => "params-метод суммы";

    /// <inheritdoc />
    public string Description =>
        "Суммирует числа, переданные отдельными аргументами, массивом или без аргументов.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать сумму для params int[].",
        "Показать вызовы Sum(1, 2, 3), Sum(new[] { 1, 2, 3 }) и Sum().",
        "Пустой массив должен давать 0."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
        Console.WriteLine($"Sum(new[] {{ 1, 2, 3 }}) = {Sum(new[] { 1, 2, 3 })}");
        Console.WriteLine($"Sum() = {Sum()}");
        Console.WriteLine(
            "Примечание: params int[] уже принимает и int[]; объявить рядом Sum(int[]) нельзя, " +
            "поскольку после компиляции это одинаковая сигнатура.");
    }

    private static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum = checked(sum + number);
        }

        return sum;
    }
}
