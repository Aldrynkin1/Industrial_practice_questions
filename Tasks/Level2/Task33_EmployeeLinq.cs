using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates LINQ queries over a collection of employees.
/// </summary>
public sealed class Task33_EmployeeLinq : ITask
{
    /// <inheritdoc />
    public string Title => "LINQ: сотрудники";

    /// <inheritdoc />
    public string Description => "Находит топ-3 зарплат, средние зарплаты отделов и сотрудников старше 30.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать список как минимум из десяти Employee.",
        "Получить топ-3 по зарплате, GroupBy + Average по отделам и Where для возраста > 30.",
        "Вывести результаты каждого запроса."
    ];

    /// <inheritdoc />
    public void Run()
    {
        List<Employee> employees =
        [
            new("Анна", 28, 320_000, "Разработка"),
            new("Борис", 34, 410_000, "Разработка"),
            new("Вера", 41, 360_000, "Продажи"),
            new("Глеб", 29, 280_000, "Поддержка"),
            new("Дарья", 37, 390_000, "Продажи"),
            new("Егор", 45, 470_000, "Разработка"),
            new("Жанна", 31, 300_000, "Поддержка"),
            new("Илья", 26, 260_000, "Продажи"),
            new("Кира", 52, 430_000, "Поддержка"),
            new("Лев", 33, 350_000, "Разработка")
        ];

        Console.WriteLine("Топ-3 по зарплате:");
        foreach (Employee employee in employees.OrderByDescending(employee => employee.Salary).Take(3))
        {
            Console.WriteLine($"  {employee.Name}: {employee.Salary:C}");
        }

        Console.WriteLine("Средняя зарплата по отделам:");
        foreach (var department in employees
                     .GroupBy(employee => employee.Department)
                     .OrderBy(group => group.Key, StringComparer.CurrentCulture))
        {
            Console.WriteLine($"  {department.Key}: {department.Average(employee => employee.Salary):C}");
        }

        Console.WriteLine("Сотрудники старше 30:");
        foreach (Employee employee in employees.Where(employee => employee.Age > 30))
        {
            Console.WriteLine($"  {employee.Name}, {employee.Age}");
        }
    }

    private sealed record Employee(string Name, int Age, decimal Salary, string Department);
}
