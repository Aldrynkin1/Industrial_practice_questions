using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates temperature properties with absolute-zero validation.
/// </summary>
public sealed class Task32_Temperature : ITask
{
    /// <inheritdoc />
    public string Title => "Свойства с валидацией: Temperature";

    /// <inheritdoc />
    public string Description => "Проверяет температуру в Celsius и вычисляет значение Fahrenheit.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Запретить Celsius ниже −273.15 через ArgumentOutOfRangeException.",
        "Вычислять Fahrenheit только для чтения.",
        "Показать корректное и некорректное присваивание."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Temperature temperature = new() { Celsius = 25 };
        Console.WriteLine($"{temperature.Celsius:F2} °C = {temperature.Fahrenheit:F2} °F");

        try
        {
            temperature.Celsius = -300;
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.WriteLine($"Некорректное значение отклонено: {exception.Message}");
        }
    }

    private sealed class Temperature
    {
        private double _celsius;

        public double Celsius
        {
            get => _celsius;
            set
            {
                if (!double.IsFinite(value) || value < -273.15)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), value, "Температура не может быть ниже абсолютного нуля.");
                }

                _celsius = value;
            }
        }

        public double Fahrenheit => Celsius * 9 / 5 + 32;
    }
}
