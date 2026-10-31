using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates calculating and sorting shapes by area.
/// </summary>
public sealed class Task25_Shapes : ITask
{
    /// <inheritdoc />
    public string Title => "IShape и сортировка фигур";

    /// <inheritdoc />
    public string Description => "Сравнивает площади круга, прямоугольника и треугольника до и после сортировки.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать IShape.Area() и Perimeter().",
        "Добавить Circle, Rectangle и Triangle.",
        "Отсортировать список из пяти и более фигур по возрастанию площади."
    ];

    /// <inheritdoc />
    public void Run()
    {
        List<IShape> shapes =
        [
            new Circle(2),
            new Rectangle(3, 4),
            new Triangle(3, 4, 5),
            new Circle(1),
            new Rectangle(2, 7)
        ];

        PrintShapes("До сортировки", shapes);
        shapes.Sort((first, second) => first.Area().CompareTo(second.Area()));
        PrintShapes("После сортировки по площади", shapes);
    }

    private static void PrintShapes(string heading, IEnumerable<IShape> shapes)
    {
        Console.WriteLine($"{heading}:");
        foreach (IShape shape in shapes)
        {
            Console.WriteLine($"{shape}: площадь = {shape.Area():F2}, периметр = {shape.Perimeter():F2}");
        }
    }

    private interface IShape
    {
        double Area();

        double Perimeter();
    }

    private sealed class Circle(double radius) : IShape
    {
        public double Area() => Math.PI * radius * radius;

        public double Perimeter() => 2 * Math.PI * radius;

        public override string ToString() => $"Круг (r={radius})";
    }

    private sealed class Rectangle(double width, double height) : IShape
    {
        public double Area() => width * height;

        public double Perimeter() => 2 * (width + height);

        public override string ToString() => $"Прямоугольник ({width}×{height})";
    }

    private sealed class Triangle(double sideA, double sideB, double sideC) : IShape
    {
        public double Area()
        {
            double semiPerimeter = Perimeter() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) *
                             (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }

        public double Perimeter() => sideA + sideB + sideC;

        public override string ToString() => $"Треугольник ({sideA}, {sideB}, {sideC})";
    }
}
