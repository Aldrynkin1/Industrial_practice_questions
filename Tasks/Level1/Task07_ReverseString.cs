using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Reverses a string with a loop.
/// </summary>
public sealed class Task07_ReverseString : ITask
{
    /// <inheritdoc />
    public string Title => "Переворот строки";

    /// <inheritdoc />
    public string Description => "Переворачивает строку, перебирая символы с конца к началу.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать цикл for.",
        "Не использовать Array.Reverse или LINQ.",
        "Корректно обработать пустую строку и строку из одного символа."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine() ?? string.Empty;
        Console.WriteLine($"Перевёрнутая строка: {Reverse(input)}");
    }

    private static string Reverse(string input)
    {
        char[] reversed = new char[input.Length];
        for (int sourceIndex = input.Length - 1, targetIndex = 0;
             sourceIndex >= 0;
             sourceIndex--, targetIndex++)
        {
            reversed[targetIndex] = input[sourceIndex];
        }

        return new string(reversed);
    }
}
