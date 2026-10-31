using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Calculates the sum of an integer's digits using two approaches.
/// </summary>
public sealed class Task06_SumOfDigits : ITask
{
    /// <inheritdoc />
    public string Title => "Сумма цифр числа";

    /// <inheritdoc />
    public string Description => "Сравнивает суммирование цифр через строку и через арифметику.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать отдельные строковый и арифметический методы.",
        "Корректно учитывать знак и обрабатывать отрицательные числа."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int? input = ConsoleHelper.ReadInt("Введите целое число: ");
        if (input is null)
        {
            return;
        }

        int[] examples = [0, 1234, -1234, input.Value];
        foreach (int number in examples.Distinct())
        {
            int stringResult = SumUsingString(number);
            int arithmeticResult = SumUsingArithmetic(number);
            Console.WriteLine(
                $"{number}: через строку = {stringResult}, через арифметику = {arithmeticResult}");
        }
    }

    private static int SumUsingString(int number)
    {
        int sum = 0;
        foreach (char character in Math.Abs((long)number).ToString())
        {
            sum += int.Parse(character.ToString(), System.Globalization.CultureInfo.InvariantCulture);
        }

        return sum;
    }

    private static int SumUsingArithmetic(int number)
    {
        long remaining = Math.Abs((long)number);
        int sum = 0;
        while (remaining > 0)
        {
            sum += (int)(remaining % 10);
            remaining /= 10;
        }

        return sum;
    }
}
