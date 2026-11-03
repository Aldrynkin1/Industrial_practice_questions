using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Demonstrates specific exception handlers and finally execution.
/// </summary>
public sealed class Task43_ExceptionOrder : ITask
{
    /// <inheritdoc />
    public string Title => "Исключения и порядок catch";

    /// <inheritdoc />
    public string Description => "Показывает три типа исключений, специализированные обработчики и finally.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Создать сценарии FormatException, DivideByZeroException и CustomException.",
        "Обработать исключения отдельными catch-блоками от частных к общему.",
        "Выполнить finally для каждого сценария и объяснить важность порядка catch."
    ];

    /// <inheritdoc />
    public void Run()
    {
        foreach (string scenario in new[] { "format", "divide", "custom" })
        {
            Console.WriteLine($"Сценарий: {scenario}");
            try
            {
                RunScenario(scenario);
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Пойман FormatException: {exception.Message}");
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine($"Пойман DivideByZeroException: {exception.Message}");
            }
            catch (CustomException exception)
            {
                Console.WriteLine($"Пойман CustomException: {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Поймано другое исключение: {exception.Message}");
            }
            finally
            {
                Console.WriteLine("Завершено.");
            }
        }

        Console.WriteLine(
            "Специализированные типы нужно перехватывать раньше общего Exception, иначе общий обработчик " +
            "перехватит исключение первым.");
    }

    private static void RunScenario(string scenario)
    {
        switch (scenario)
        {
            case "format":
                _ = int.Parse("не число");
                break;
            case "divide":
                int divisor = int.Parse("0");
                _ = 10 / divisor;
                break;
            case "custom":
                throw new CustomException("Демонстрационное пользовательское исключение.");
            default:
                throw new ArgumentOutOfRangeException(nameof(scenario));
        }
    }

    private sealed class CustomException(string message) : Exception(message);
}
