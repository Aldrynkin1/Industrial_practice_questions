using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Demonstrates cancellation of an asynchronous operation.
/// </summary>
public sealed class Task42_CancellationToken : ITask
{
    /// <inheritdoc />
    public string Title => "CancellationToken: отмена операции";

    /// <inheritdoc />
    public string Description => "Запускает десять задержек и отменяет операцию через две секунды.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать LongOperationAsync(CancellationToken) с десятью задержками по 500 мс.",
        "Отменить операцию через две секунды и обработать OperationCanceledException."
    ];

    /// <inheritdoc />
    public void Run() => RunAsync().GetAwaiter().GetResult();

    private static async Task RunAsync()
    {
        using CancellationTokenSource cancellationTokenSource = new();
        Task operation = LongOperationAsync(cancellationTokenSource.Token);

        await Task.Delay(TimeSpan.FromSeconds(2));
        cancellationTokenSource.Cancel();

        try
        {
            await operation;
        }
        catch (OperationCanceledException) when (cancellationTokenSource.IsCancellationRequested)
        {
            Console.WriteLine("Операция отменена.");
        }
    }

    private static async Task LongOperationAsync(CancellationToken token)
    {
        for (int step = 1; step <= 10; step++)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500), token);
            Console.WriteLine($"Выполнен шаг {step}/10.");
        }
    }
}
