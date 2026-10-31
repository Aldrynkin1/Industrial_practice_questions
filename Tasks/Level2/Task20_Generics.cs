using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates generic swap and maximum operations.
/// </summary>
public sealed class Task20_Generics : ITask
{
    /// <inheritdoc />
    public string Title => "Обобщения: Swap и Max";

    /// <inheritdoc />
    public string Description => "Меняет местами и сравнивает значения int, string и double.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать Swap<T>(ref T a, ref T b) без ограничений.",
        "Реализовать Max<T> с ограничением IComparable<T>."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int firstInt = 1;
        int secondInt = 2;
        Demonstrate(ref firstInt, ref secondInt);

        string firstString = "apple";
        string secondString = "pear";
        Demonstrate(ref firstString, ref secondString);

        double firstDouble = 1.5;
        double secondDouble = 2.5;
        Demonstrate(ref firstDouble, ref secondDouble);
    }

    private static void Demonstrate<T>(ref T first, ref T second)
        where T : IComparable<T>
    {
        Console.WriteLine($"До Swap: {first}, {second}; Max = {Max(first, second)}");
        Swap(ref first, ref second);
        Console.WriteLine($"После Swap: {first}, {second}; Max = {Max(first, second)}");
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        (first, second) = (second, first);
    }

    private static T Max<T>(T first, T second)
        where T : IComparable<T> =>
        first.CompareTo(second) >= 0 ? first : second;
}
