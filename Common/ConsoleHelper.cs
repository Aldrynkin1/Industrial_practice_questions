using System.Globalization;

namespace CSharpPracticum.Common;

/// <summary>
/// Provides validated console input helpers used by assignments.
/// </summary>
public static class ConsoleHelper
{
    /// <summary>
    /// Reads an integer, returning null when input ends.
    /// </summary>
    public static int? ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (input is null)
            {
                return null;
            }

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.CurrentCulture, out int value))
            {
                return value;
            }

            Console.WriteLine("Некорректное целое число. Попробуйте ещё раз.");
        }
    }

    /// <summary>
    /// Reads a finite double-precision number, returning null when input ends.
    /// </summary>
    public static double? ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (input is null)
            {
                return null;
            }

            if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.CurrentCulture, out double value) &&
                double.IsFinite(value))
            {
                return value;
            }

            Console.WriteLine("Некорректное число. Попробуйте ещё раз.");
        }
    }
}
