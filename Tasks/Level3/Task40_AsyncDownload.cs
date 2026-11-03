using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Demonstrates async work and exception handling.
/// </summary>
public sealed class Task40_AsyncDownload : ITask
{
    /// <inheritdoc />
    public string Title => "async/await и обработка исключений";

    /// <inheritdoc />
    public string Description => "Имитирует загрузку ресурса и обрабатывает пустой URL без падения приложения.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать DownloadAsync(string url) с Task.Delay(1000).",
        "Для пустого URL выбрасывать ArgumentException.",
        "Через await в try/catch показать успешный и ошибочный вызовы."
    ];

    /// <inheritdoc />
    public void Run() => RunAsync().GetAwaiter().GetResult();

    private static async Task RunAsync()
    {
        try
        {
            string result = await DownloadAsync("https://example.com/resource");
            Console.WriteLine($"Успешно: {result}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Ошибка загрузки: {exception.Message}");
        }

        try
        {
            string result = await DownloadAsync(string.Empty);
            Console.WriteLine($"Успешно: {result}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Ожидаемая ошибка: {exception.Message}");
        }
    }

    private static async Task<string> DownloadAsync(string url)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        await Task.Delay(TimeSpan.FromSeconds(1));
        return $"Содержимое ресурса {url}";
    }
}
