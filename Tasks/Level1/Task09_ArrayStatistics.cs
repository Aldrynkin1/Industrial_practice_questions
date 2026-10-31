using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Computes basic statistics for an integer array without LINQ.
/// </summary>
public sealed class Task09_ArrayStatistics : ITask
{
    /// <inheritdoc />
    public string Title => "Работа с массивами";

    /// <inheritdoc />
    public string Description => "Самостоятельно находит минимум, максимум, сумму и среднее массива.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать FindMin, FindMax, CalculateSum и CalculateAverage отдельно.",
        "Не использовать LINQ или Min, Max, Sum и Average.",
        "Обработать пустой массив."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int[] numbers = new int[20];
        for (int index = 0; index < numbers.Length; index++)
        {
            numbers[index] = Random.Shared.Next(1, 101);
        }

        Console.WriteLine($"Массив: {string.Join(", ", numbers)}");
        Console.WriteLine($"Минимум: {FindMin(numbers)}");
        Console.WriteLine($"Максимум: {FindMax(numbers)}");
        Console.WriteLine($"Сумма: {CalculateSum(numbers)}");
        Console.WriteLine($"Среднее: {CalculateAverage(numbers):F2}");

        int[] empty = [];
        Console.WriteLine($"Проверка пустого массива: {DescribeEmptyArray(empty)}");
    }

    private static int? FindMin(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return null;
        }

        int minimum = numbers[0];
        for (int index = 1; index < numbers.Length; index++)
        {
            if (numbers[index] < minimum)
            {
                minimum = numbers[index];
            }
        }

        return minimum;
    }

    private static int? FindMax(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return null;
        }

        int maximum = numbers[0];
        for (int index = 1; index < numbers.Length; index++)
        {
            if (numbers[index] > maximum)
            {
                maximum = numbers[index];
            }
        }

        return maximum;
    }

    private static long CalculateSum(int[] numbers)
    {
        long sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    private static double? CalculateAverage(int[] numbers) =>
        numbers.Length == 0 ? null : (double)CalculateSum(numbers) / numbers.Length;

    private static string DescribeEmptyArray(int[] numbers) =>
        FindMin(numbers) is null && FindMax(numbers) is null && CalculateAverage(numbers) is null
            ? "показатели не определены"
            : "массив содержит значения";
}
