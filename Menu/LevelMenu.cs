using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level1;

namespace CSharpPracticum.Menu;

/// <summary>
/// Displays and runs the assignments implemented for level one.
/// </summary>
public sealed class LevelMenu
{
    private readonly IReadOnlyList<ITask> _tasks =
    [
        new Task01_GreetingAndDate(),
        new Task02_PrimitiveTypes(),
        new Task03_Calculator(),
        new Task04_EvenOrOdd(),
        new Task05_MultiplicationTable(),
        new Task06_SumOfDigits(),
        new Task07_ReverseString(),
        new Task08_FizzBuzz(),
        new Task09_ArrayStatistics(),
        new Task10_ArraySorting(),
        new Task11_MainDiagonal(),
        new Task12_Palindrome(),
        new Task13_WordFrequency(),
        new Task14_AgeCalculator()
    ];

    /// <summary>
    /// Runs the level-one menu until the user returns or exits.
    /// </summary>
    /// <returns><see langword="true"/> when the application should exit; otherwise, <see langword="false"/>.</returns>
    public bool Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("--- Уровень 1: Базовый ---");
            for (int index = 0; index < _tasks.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {_tasks[index].Title}");
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

            if (!int.TryParse(choice, out int taskNumber) || taskNumber < 1 || taskNumber > _tasks.Count)
            {
                Console.WriteLine($"Введите номер задания от 1 до {_tasks.Count}, b для возврата или 0 для выхода.");
                continue;
            }

            RunTask(_tasks[taskNumber - 1]);
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
