using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Counts case-insensitive word occurrences in a line of text.
/// </summary>
public sealed class Task13_WordFrequency : ITask
{
    /// <inheritdoc />
    public string Title => "Подсчёт слов в тексте";

    /// <inheritdoc />
    public string Description => "Подсчитывает слова без учёта регистра и сортирует по частоте.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Разделять слова по пробелам и знакам пунктуации.",
        "Использовать Dictionary<string, int> и нижний регистр.",
        "Выводить слова по убыванию количества вхождений."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.Write("Введите текст одной строкой: ");
        string text = Console.ReadLine() ?? string.Empty;
        Dictionary<string, int> counts = CountWords(text);

        if (counts.Count == 0)
        {
            Console.WriteLine("В тексте не найдено слов.");
            return;
        }

        foreach (KeyValuePair<string, int> entry in counts
                     .OrderByDescending(pair => pair.Value)
                     .ThenBy(pair => pair.Key, StringComparer.Ordinal))
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    private static Dictionary<string, int> CountWords(string text)
    {
        Dictionary<string, int> counts = new(StringComparer.Ordinal);
        StringBuilder word = new();

        void AddWord()
        {
            if (word.Length == 0)
            {
                return;
            }

            string normalized = word.ToString().ToLowerInvariant();
            counts[normalized] = counts.GetValueOrDefault(normalized) + 1;
            word.Clear();
        }

        foreach (char character in text)
        {
            if (char.IsLetterOrDigit(character))
            {
                word.Append(character);
            }
            else
            {
                AddWord();
            }
        }

        AddWord();
        return counts;
    }
}
