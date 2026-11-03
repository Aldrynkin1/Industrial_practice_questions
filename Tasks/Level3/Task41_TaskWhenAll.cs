using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Compares sequential and parallel asynchronous work.
/// </summary>
public sealed class Task41_TaskWhenAll : ITask
{
    /// <inheritdoc />
    public string Title => "Task.WhenAll: десять задач параллельно";

    /// <inheritdoc />
    public string Description => "Сравнивает последовательное и параллельное ожидание десяти одинаковых операций.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать WorkAsync(int id): задержка 500 мс и возврат id.",
        "Замерить последовательный запуск с await в цикле и параллельный запуск через Task.WhenAll.",
        "Вывести время и проверить совпадение результатов."
    ];

    /// <inheritdoc />
    public void Run() => RunAsync().GetAwaiter().GetResult();

    private static async Task RunAsync()
    {
        const int taskCount = 10;
        List<int> sequentialResults = [];
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int id = 1; id <= taskCount; id++)
        {
            sequentialResults.Add(await WorkAsync(id));
        }

        stopwatch.Stop();
        TimeSpan sequentialTime = stopwatch.Elapsed;

        stopwatch.Restart();
        int[] parallelResults = await Task.WhenAll(
            Enumerable.Range(1, taskCount).Select(WorkAsync));
        stopwatch.Stop();

        Console.WriteLine($"Последовательно: {sequentialTime.TotalMilliseconds:F0} мс");
        Console.WriteLine($"Task.WhenAll: {stopwatch.Elapsed.TotalMilliseconds:F0} мс");
        Console.WriteLine($"Результаты совпадают: {sequentialResults.SequenceEqual(parallelResults)}");
        Console.WriteLine("Параллельное ожидание перекрывает задержки задач, поэтому обычно занимает около 500 мс, а не 5 секунд.");
    }

    private static async Task<int> WorkAsync(int id)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        return id;
    }
}
