using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Prints the FizzBuzz sequence from one to one hundred.
/// </summary>
public sealed class Task08_FizzBuzz : ITask
{
    /// <inheritdoc />
    public string Title => "FizzBuzz";

    /// <inheritdoc />
    public string Description => "Печатает числа от 1 до 100 с заменами Fizz, Buzz и FizzBuzz.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать цикл.",
        "Проверять делимость в порядке 15, 3, 5."
    ];

    /// <inheritdoc />
    public void Run()
    {
        for (int number = 1; number <= 100; number++)
        {
            if (number % 15 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }
    }
}
