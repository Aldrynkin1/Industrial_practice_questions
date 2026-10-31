using System.Globalization;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Compares TryParse and exception-based integer parsing.
/// </summary>
public sealed class Task18_TryParseVsExceptions : ITask
{
    /// <inheritdoc />
    public string Title => "TryParse vs try/catch";

    /// <inheritdoc />
    public string Description => "Сравнивает обработку корректной и некорректной строки как числа.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать разбор через int.TryParse и через int.Parse с обработкой FormatException.",
        "Показать оба метода на строках 123 и abc."
    ];

    /// <inheritdoc />
    public void Run()
    {
        foreach (string input in new[] { "123", "abc" })
        {
            bool tryParseSucceeded = TryParseValue(input, out int tryParseValue);
            (bool parseSucceeded, int parseValue) = ParseWithExceptionHandling(input);
            Console.WriteLine(
                $"\"{input}\": TryParse = {(tryParseSucceeded ? tryParseValue : "ошибка")}, " +
                $"try/catch = {(parseSucceeded ? parseValue : "ошибка")}");
        }
    }

    private static bool TryParseValue(string input, out int value) =>
        int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out value);

    private static (bool Success, int Value) ParseWithExceptionHandling(string input)
    {
        try
        {
            return (true, int.Parse(input, NumberStyles.Integer, CultureInfo.InvariantCulture));
        }
        catch (FormatException)
        {
            return (false, default);
        }
    }
}
