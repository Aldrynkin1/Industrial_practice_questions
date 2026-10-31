using System.Globalization;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Prints a greeting and the current date.
/// </summary>
public sealed class Task01_GreetingAndDate : ITask
{
    /// <inheritdoc />
    public string Title => "Приветствие и текущая дата";

    /// <inheritdoc />
    public string Description => "Выводит приветствие и текущую дату на отдельных строках.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать Console.WriteLine и DateTime.Now.",
        "Форматировать дату как день.месяц.год (dd.MM.yyyy)."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine("Привет! Добро пожаловать в практикум по C#.");
        Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture));
    }
}
