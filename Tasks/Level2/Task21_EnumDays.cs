using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates day-of-week enumeration and weekend detection.
/// </summary>
public sealed class Task21_EnumDays : ITask
{
    /// <inheritdoc />
    public string Title => "enum: дни недели";

    /// <inheritdoc />
    public string Description => "Показывает русские названия дней недели и отмечает выходные.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Описать дни недели через enum.",
        "Реализовать IsWeekend и GetRussianName.",
        "Вывести данные для всех семи дней."
    ];

    /// <inheritdoc />
    public void Run()
    {
        foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
        {
            Console.WriteLine($"{GetRussianName(day)}: выходной — {IsWeekend(day)}");
        }
    }

    private static bool IsWeekend(DayOfWeek day) =>
        day is DayOfWeek.Saturday or DayOfWeek.Sunday;

    private static string GetRussianName(DayOfWeek day) =>
        day switch
        {
            DayOfWeek.Monday => "Понедельник",
            DayOfWeek.Tuesday => "Вторник",
            DayOfWeek.Wednesday => "Среда",
            DayOfWeek.Thursday => "Четверг",
            DayOfWeek.Friday => "Пятница",
            DayOfWeek.Saturday => "Суббота",
            DayOfWeek.Sunday => "Воскресенье",
            _ => throw new ArgumentOutOfRangeException(nameof(day), day, "Неизвестный день недели.")
        };

    private enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
