using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Implements and times bubble sort and insertion sort.
/// </summary>
public sealed class Task10_ArraySorting : ITask
{
    /// <inheritdoc />
    public string Title => "Сортировка массива";

    /// <inheritdoc />
    public string Description => "Сортирует два одинаковых массива пузырьком и вставками, измеряя время.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать BubbleSort и InsertionSort без Array.Sort и LINQ.",
        "Использовать массивы из 10 000 одинаковых исходных значений.",
        "Измерить время с помощью Stopwatch."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int[] original = new int[10_000];
        for (int index = 0; index < original.Length; index++)
        {
            original[index] = Random.Shared.Next(0, 100_001);
        }

        int[] bubbleArray = (int[])original.Clone();
        int[] insertionArray = (int[])original.Clone();

        Stopwatch stopwatch = Stopwatch.StartNew();
        BubbleSort(bubbleArray);
        stopwatch.Stop();
        TimeSpan bubbleTime = stopwatch.Elapsed;

        stopwatch.Restart();
        InsertionSort(insertionArray);
        stopwatch.Stop();
        TimeSpan insertionTime = stopwatch.Elapsed;

        Console.WriteLine($"Пузырьковая сортировка: {bubbleTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"Сортировка вставками: {insertionTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"Оба массива отсортированы: {IsSorted(bubbleArray) && IsSorted(insertionArray)}");
    }

    private static void BubbleSort(int[] numbers)
    {
        for (int end = numbers.Length - 1; end > 0; end--)
        {
            bool swapped = false;
            for (int index = 0; index < end; index++)
            {
                if (numbers[index] <= numbers[index + 1])
                {
                    continue;
                }

                (numbers[index], numbers[index + 1]) = (numbers[index + 1], numbers[index]);
                swapped = true;
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    private static void InsertionSort(int[] numbers)
    {
        for (int index = 1; index < numbers.Length; index++)
        {
            int value = numbers[index];
            int position = index - 1;
            while (position >= 0 && numbers[position] > value)
            {
                numbers[position + 1] = numbers[position];
                position--;
            }

            numbers[position + 1] = value;
        }
    }

    private static bool IsSorted(int[] numbers)
    {
        for (int index = 1; index < numbers.Length; index++)
        {
            if (numbers[index - 1] > numbers[index])
            {
                return false;
            }
        }

        return true;
    }
}
