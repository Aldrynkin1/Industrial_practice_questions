using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates value equality and hash-based uniqueness for points.
/// </summary>
public sealed class Task28_PointEquality : ITask
{
    /// <inheritdoc />
    public string Title => "Equals и GetHashCode для Point";

    /// <inheritdoc />
    public string Description => "Сравнивает точки по координатам и проверяет уникальность через HashSet.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Переопределить Equals(object) и GetHashCode.",
        "Реализовать IEquatable<Point>.",
        "Показать, что дубликат координат не увеличивает HashSet.Count."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Point first = new(3, 5);
        Point duplicate = new(3, 5);
        Point another = new(4, 5);
        HashSet<Point> points = [first, duplicate, another];

        Console.WriteLine($"Одинаковые координаты равны: {first.Equals(duplicate)}");
        Console.WriteLine($"Количество уникальных точек: {points.Count}");
        Console.WriteLine($"Точки: {string.Join(", ", points)}");
    }

    private sealed class Point(double x, double y) : IEquatable<Point>
    {
        public double X { get; } = x;

        public double Y { get; } = y;

        public bool Equals(Point? other) =>
            other is not null && X.Equals(other.X) && Y.Equals(other.Y);

        public override bool Equals(object? obj) => obj is Point other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override string ToString() => $"({X}, {Y})";
    }
}
