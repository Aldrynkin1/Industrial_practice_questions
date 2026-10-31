using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Performs one of the four basic arithmetic operations.
/// </summary>
public sealed class Task03_Calculator : ITask
{
    /// <inheritdoc />
    public string Title => "Калькулятор";

    /// <inheritdoc />
    public string Description => "Принимает два числа и оператор, затем вычисляет результат.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Поддерживать операции +, -, * и / с помощью switch.",
        "Обрабатывать деление на ноль и неизвестный оператор.",
        "Проверять корректность введённых чисел."
    ];

    /// <inheritdoc />
    public void Run()
    {
        double? first = ConsoleHelper.ReadDouble("Введите первое число: ");
        if (first is null)
        {
            return;
        }

        double? second = ConsoleHelper.ReadDouble("Введите второе число: ");
        if (second is null)
        {
            return;
        }

        Console.Write("Введите операцию (+, -, *, /): ");
        string? operation = Console.ReadLine()?.Trim();
        if (operation is null)
        {
            return;
        }

        switch (operation)
        {
            case "+":
                Console.WriteLine($"Результат: {first.Value + second.Value}");
                break;
            case "-":
                Console.WriteLine($"Результат: {first.Value - second.Value}");
                break;
            case "*":
                Console.WriteLine($"Результат: {first.Value * second.Value}");
                break;
            case "/" when second.Value == 0:
                Console.WriteLine("Ошибка: деление на ноль.");
                break;
            case "/":
                Console.WriteLine($"Результат: {first.Value / second.Value}");
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                break;
        }
    }
}
