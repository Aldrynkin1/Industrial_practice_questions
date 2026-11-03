using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level3;

namespace CSharpPracticum.Menu;

/// <summary>
/// Displays and runs the assignments for level three.
/// </summary>
public sealed class Level3Menu
{
    private readonly IReadOnlyList<ITask> _tasks =
    [
        new Task36_ListDuplicates(),
        new Task37_MemoizedFibonacci(),
        new Task38_ListVsLinkedList(),
        new Task39_EvenNumberGenerator(),
        new Task40_AsyncDownload(),
        new Task41_TaskWhenAll(),
        new Task42_CancellationToken(),
        new Task43_ExceptionOrder(),
        new Task44_TodoList(),
        new Task45_Library(),
        new Task46_GitStash(),
        new Task47_GitRebaseSquash(),
        new Task48_GitTags(),
        new Task49_GitReflog(),
        new Task50_GitBisect()
    ];

    /// <summary>
    /// Runs the level-three menu until the user returns or exits.
    /// </summary>
    /// <returns><see langword="true"/> when the application should exit; otherwise, <see langword="false"/>.</returns>
    public bool Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("--- Уровень 3: Продвинутый ---");
            for (int index = 0; index < _tasks.Count; index++)
            {
                Console.WriteLine($"{index + 36}. {_tasks[index].Title}");
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

            if (!int.TryParse(choice, out int taskNumber) || taskNumber < 36 || taskNumber >= 36 + _tasks.Count)
            {
                Console.WriteLine($"Введите номер задания от 36 до {35 + _tasks.Count}, b для возврата или 0 для выхода.");
                continue;
            }

            RunTask(_tasks[taskNumber - 36]);
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
