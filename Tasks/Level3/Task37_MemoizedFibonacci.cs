using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Compares recursive and memoized Fibonacci calculations.
/// </summary>
public sealed class Task37_MemoizedFibonacci : ITask
{
    /// <inheritdoc />
    public string Title => "Мемоизация Фибоначчи через Dictionary";

    /// <inheritdoc />
    public string Description => "Сравнивает обычную рекурсию и мемоизированный расчёт числа Фибоначчи.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать обычную рекурсивную и мемоизированную версии.",
        "Для мемоизации использовать Dictionary<int, long>.",
        "Замерить обе версии через Stopwatch на N = 30–35 и сравнить результаты."
    ];

    /// <inheritdoc />
    public void Run()
    {
        const int n = 35;

        Stopwatch stopwatch = Stopwatch.StartNew();
        long recursiveResult = FibonacciRecursive(n);
        stopwatch.Stop();
        TimeSpan recursiveTime = stopwatch.Elapsed;

        stopwatch.Restart();
        long memoizedResult = FibonacciMemoized(n, new Dictionary<int, long> { [0] = 0, [1] = 1 });
        stopwatch.Stop();
        TimeSpan memoizedTime = stopwatch.Elapsed;

        Console.WriteLine($"F({n}) рекурсивно: {recursiveResult}, {recursiveTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"F({n}) с мемоизацией: {memoizedResult}, {memoizedTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"Разница: {Math.Abs(recursiveTime.TotalMilliseconds - memoizedTime.TotalMilliseconds):F2} мс");
        Console.WriteLine($"Результаты совпадают: {recursiveResult == memoizedResult}");
    }

    private static long FibonacciRecursive(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "N не может быть отрицательным.");
        }

        return n < 2 ? n : FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    private static long FibonacciMemoized(int n, Dictionary<int, long> cache)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "N не может быть отрицательным.");
        }

        if (cache.TryGetValue(n, out long value))
        {
            return value;
        }

        value = FibonacciMemoized(n - 1, cache) + FibonacciMemoized(n - 2, cache);
        cache.Add(n, value);
        return value;
    }
}
