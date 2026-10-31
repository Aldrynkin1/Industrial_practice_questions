using System.Diagnostics;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Compares string concatenation with StringBuilder.
/// </summary>
public sealed class Task17_StringBuilderBenchmark : ITask
{
    /// <inheritdoc />
    public string Title => "StringBuilder vs конкатенация";

    /// <inheritdoc />
    public string Description => "Строит одинаковую строку двумя способами и сравнивает время.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Собрать строку из 10 000 чисел конкатенацией и через StringBuilder.",
        "Измерить оба времени Stopwatch и вывести разницу.",
        "Проверить совпадение результатов и объяснить преимущества StringBuilder."
    ];

    /// <inheritdoc />
    public void Run()
    {
        const int itemCount = 10_000;

        // Concatenation repeatedly copies immutable strings; StringBuilder grows a reusable buffer instead.
        Stopwatch stopwatch = Stopwatch.StartNew();
        string concatenated = BuildWithConcatenation(itemCount);
        stopwatch.Stop();
        TimeSpan concatenationTime = stopwatch.Elapsed;

        stopwatch.Restart();
        string built = BuildWithStringBuilder(itemCount);
        stopwatch.Stop();
        TimeSpan stringBuilderTime = stopwatch.Elapsed;

        Console.WriteLine($"Конкатенация: {concatenationTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"StringBuilder: {stringBuilderTime.TotalMilliseconds:F2} мс");
        Console.WriteLine(
            $"Разница: {Math.Abs(concatenationTime.TotalMilliseconds - stringBuilderTime.TotalMilliseconds):F2} мс");
        Console.WriteLine($"Результаты совпадают: {string.Equals(concatenated, built, StringComparison.Ordinal)}");
        Console.WriteLine(
            "StringBuilder обычно быстрее: конкатенация создаёт много промежуточных строк, " +
            "а StringBuilder накапливает текст в изменяемом буфере.");
    }

    private static string BuildWithConcatenation(int itemCount)
    {
        string result = string.Empty;
        for (int number = 0; number < itemCount; number++)
        {
            result += number.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        return result;
    }

    private static string BuildWithStringBuilder(int itemCount)
    {
        StringBuilder builder = new();
        for (int number = 0; number < itemCount; number++)
        {
            builder.Append(number);
        }

        return builder.ToString();
    }
}
