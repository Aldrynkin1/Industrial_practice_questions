using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Checks whether a phrase is a palindrome while ignoring punctuation and case.
/// </summary>
public sealed class Task12_Palindrome : ITask
{
    /// <inheritdoc />
    public string Title => "Проверка палиндрома";

    /// <inheritdoc />
    public string Description => "Сравнивает строку с двух концов, пропуская пробелы и знаки пунктуации.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Не учитывать регистр, пробелы и пунктуацию.",
        "Не использовать LINQ и Reverse.",
        "Корректно обрабатывать пустую строку и строку из одного символа."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine() ?? string.Empty;
        Console.WriteLine(IsPalindrome(input) ? "true" : "false");
    }

    private static bool IsPalindrome(string input)
    {
        int left = 0;
        int right = input.Length - 1;
        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(input[left]))
            {
                left++;
            }

            while (left < right && !char.IsLetterOrDigit(input[right]))
            {
                right--;
            }

            if (char.ToUpperInvariant(input[left]) != char.ToUpperInvariant(input[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}
