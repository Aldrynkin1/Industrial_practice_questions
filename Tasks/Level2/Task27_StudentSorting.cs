using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates student ordering by grade and by name.
/// </summary>
public sealed class Task27_StudentSorting : ITask
{
    /// <inheritdoc />
    public string Title => "IComparable и IComparer для Student";

    /// <inheritdoc />
    public string Description => "Сортирует студентов по убыванию среднего балла и по имени.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать IComparable<Student> по среднему баллу по убыванию.",
        "Реализовать ByNameComparer для сортировки по имени.",
        "Показать оба порядка на одном списке студентов."
    ];

    /// <inheritdoc />
    public void Run()
    {
        List<Student> students =
        [
            new("Мария", 4.8),
            new("Алексей", 4.2),
            new("Ирина", 4.8),
            new("Борис", 3.9),
            new("Дамир", 4.5)
        ];

        students.Sort();
        PrintStudents("По среднему баллу (убывание)", students);
        students.Sort(new ByNameComparer());
        PrintStudents("По имени", students);
    }

    private static void PrintStudents(string heading, IEnumerable<Student> students)
    {
        Console.WriteLine($"{heading}:");
        foreach (Student student in students)
        {
            Console.WriteLine($"  {student.Name}: {student.AverageGrade:F1}");
        }
    }

    private sealed class Student(string name, double averageGrade) : IComparable<Student>
    {
        public string Name { get; } = name;

        public double AverageGrade { get; } = averageGrade;

        public int CompareTo(Student? other)
        {
            if (other is null)
            {
                return 1;
            }

            int gradeComparison = other.AverageGrade.CompareTo(AverageGrade);
            return gradeComparison != 0
                ? gradeComparison
                : StringComparer.CurrentCulture.Compare(Name, other.Name);
        }
    }

    private sealed class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student? first, Student? second)
        {
            if (ReferenceEquals(first, second))
            {
                return 0;
            }

            if (first is null)
            {
                return -1;
            }

            if (second is null)
            {
                return 1;
            }

            return StringComparer.CurrentCulture.Compare(first.Name, second.Name);
        }
    }
}
