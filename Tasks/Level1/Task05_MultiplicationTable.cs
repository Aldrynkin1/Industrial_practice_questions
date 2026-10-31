using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Prints a formatted multiplication table.
/// </summary>
public sealed class Task05_MultiplicationTable : ITask
{
    /// <inheritdoc />
    public string Title => "Таблица умножения";

    /// <inheritdoc />
    public string Description => "Выводит ровную таблицу произведений чисел от 1 до 10.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать два вложенных цикла for.",
        "Выровнять значения таблицы."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.Write("    ");
        for (int column = 1; column <= 10; column++)
        {
            Console.Write($"{column,4}");
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 44));
        for (int row = 1; row <= 10; row++)
        {
            Console.Write($"{row,3} |");
            for (int column = 1; column <= 10; column++)
            {
                Console.Write($"{row * column,4}");
            }

            Console.WriteLine();
        }
    }
}
