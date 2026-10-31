using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level2;

namespace CSharpPracticum.Menu;

/// <summary>
/// Displays and runs the assignments for level two.
/// </summary>
public sealed class Level2Menu
{
    private readonly IReadOnlyList<ITask> _tasks =
    [
        new Task16_StringExtensions(),
        new Task17_StringBuilderBenchmark(),
        new Task18_TryParseVsExceptions(),
        new Task19_CustomCollections(),
        new Task20_Generics(),
        new Task21_EnumDays(),
        new Task22_ParamsAndOverload(),
        new Task23_NullableValues(),
        new Task24_Animals(),
        new Task25_Shapes(),
        new Task26_DiscountStrategy(),
        new Task27_StudentSorting(),
        new Task28_PointEquality(),
        new Task29_NotificationFactory(),
        new Task30_BankAccount(),
        new Task31_DisposableFileWriter(),
        new Task32_Temperature(),
        new Task33_EmployeeLinq(),
        new Task34_WordGrouping(),
        new Task35_GitWorkflow()
    ];

    /// <summary>
    /// Runs the level-two menu until the user returns or exits.
    /// </summary>
    /// <returns><see langword="true"/> when the application should exit; otherwise, <see langword="false"/>.</returns>
    public bool Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("--- Уровень 2: Средний ---");
            for (int index = 0; index < _tasks.Count; index++)
            {
                Console.WriteLine($"{index + 16}. {_tasks[index].Title}");
            }

            Console.WriteLine("b. Назад");
            Console.WriteLine("0 или q. Выход");
            Console.Write("Выберите задание: ");

            string? choice = Console.ReadLine();
            if (choice is null || choice.Trim().Equals("q", StringComparison.OrdinalIgnoreCase) ||
                choice.Trim() == "0")
            {
                return true;
            }

            if (choice.Trim().Equals("b", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!int.TryParse(choice, out int taskNumber) || taskNumber < 16 || taskNumber >= 16 + _tasks.Count)
            {
                Console.WriteLine($"Введите номер задания от 16 до {15 + _tasks.Count}, b для возврата или 0 для выхода.");
                continue;
            }

            RunTask(_tasks[taskNumber - 16]);
        }
    }

    private static void RunTask(ITask task)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 50));
        Console.WriteLine(task.Title);
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Описание:");
        Console.WriteLine($"  {task.Description}");
        Console.WriteLine("Требования:");
        foreach (string requirement in task.Requirements)
        {
            Console.WriteLine($"  - {requirement}");
        }

        Console.WriteLine(new string('-', 50));
        task.Run();
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }
}
