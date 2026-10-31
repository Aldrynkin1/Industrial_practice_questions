using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates extension methods for string values.
/// </summary>
public sealed class Task16_StringExtensions : ITask
{
    /// <inheritdoc />
    public string Title => "Методы расширения для string";

    /// <inheritdoc />
    public string Description => "Добавляет к строке проверку палиндрома, подсчёт слов и переворот.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать IsPalindrome, WordCount и ReverseString в статическом классе.",
        "Каждый extension-метод принимает this string первым параметром.",
        "Продемонстрировать вызовы на нескольких строках."
    ];

    /// <inheritdoc />
    public void Run()
    {
        string[] samples = ["А роза упала на лапу Азора", "Hello, C#!", ""];
        foreach (string sample in samples)
        {
            Console.WriteLine($"Строка: \"{sample}\"");
            Console.WriteLine($"  Палиндром: {sample.IsPalindrome()}");
            Console.WriteLine($"  Слов: {sample.WordCount()}");
            Console.WriteLine($"  Наоборот: \"{sample.ReverseString()}\"");
        }
    }
}

/// <summary>
/// Provides extension methods for string values.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Checks whether letters and digits in the string form a palindrome.
    /// </summary>
    public static bool IsPalindrome(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        int left = 0;
        int right = value.Length - 1;
        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(value[left]))
            {
                left++;
            }

            while (left < right && !char.IsLetterOrDigit(value[right]))
            {
                right--;
            }

            if (char.ToUpperInvariant(value[left]) != char.ToUpperInvariant(value[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    /// <summary>
    /// Counts non-empty sequences of letters and digits.
    /// </summary>
    public static int WordCount(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        int count = 0;
        bool insideWord = false;
        foreach (char character in value)
        {
            if (char.IsLetterOrDigit(character))
            {
                if (!insideWord)
                {
                    count++;
                    insideWord = true;
                }
            }
            else
            {
                insideWord = false;
            }
        }

        return count;
    }

    /// <summary>
    /// Returns the string with its UTF-16 code units in reverse order.
    /// </summary>
    public static string ReverseString(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        char[] reversed = new char[value.Length];
        for (int index = 0; index < value.Length; index++)
        {
            reversed[index] = value[value.Length - index - 1];
        }

        return new string(reversed);
    }
}
