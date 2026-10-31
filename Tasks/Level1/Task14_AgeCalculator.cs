using System.Globalization;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Calculates a person's age in years, months, and days.
/// </summary>
public sealed class Task14_AgeCalculator : ITask
{
    /// <inheritdoc />
    public string Title => "Расчёт возраста по дате рождения";

    /// <inheritdoc />
    public string Description => "Вычисляет полный возраст на текущую дату в годах, месяцах и днях.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Проверить дату рождения с помощью DateTime.TryParse.",
        "Учитывать наступление дня рождения в текущем году.",
        "Сообщать об ошибочной или будущей дате без аварийного завершения."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.Write("Введите дату рождения (например, 22.10.2000): ");
        string? input = Console.ReadLine();
        if (input is null)
        {
            return;
        }

        string[] acceptedFormats = ["dd.MM.yyyy", "d.M.yyyy", "yyyy-MM-dd"];
        bool isValidDate =
            DateTime.TryParseExact(input.Trim(), acceptedFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parsedDate) ||
            DateTime.TryParse(input, CultureInfo.CurrentCulture, DateTimeStyles.None, out parsedDate);
        if (!isValidDate)
        {
            Console.WriteLine("Ошибка: не удалось распознать дату.");
            return;
        }

        DateTime birthDate = parsedDate.Date;
        DateTime today = DateTime.Today;
        if (birthDate > today)
        {
            Console.WriteLine("Ошибка: дата рождения не может быть в будущем.");
            return;
        }

        (int years, int months, int days) = CalculateAge(birthDate, today);
        Console.WriteLine($"{years} лет, {months} месяцев, {days} дней");
    }

    private static (int Years, int Months, int Days) CalculateAge(DateTime birthDate, DateTime today)
    {
        int years = today.Year - birthDate.Year;
        if (birthDate.AddYears(years) > today)
        {
            years--;
        }

        DateTime anniversary = birthDate.AddYears(years);
        int months = (today.Year - anniversary.Year) * 12 + today.Month - anniversary.Month;
        if (anniversary.AddMonths(months) > today)
        {
            months--;
        }

        DateTime lastMonthAnniversary = anniversary.AddMonths(months);
        int days = (today - lastMonthAnniversary).Days;
        return (years, months, days);
    }
}
