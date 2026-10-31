using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>
/// Creates a square matrix and sums its main diagonal.
/// </summary>
public sealed class Task11_MainDiagonal : ITask
{
    /// <inheritdoc />
    public string Title => "Матрица и главная диагональ";

    /// <inheritdoc />
    public string Description => "Создаёт квадратную матрицу случайных чисел и считает сумму главной диагонали.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Запрашивать размер N не меньше 2.",
        "Вывести матрицу и вычислить сумму диагонали одним циклом for.",
        "Не использовать LINQ."
    ];

    /// <inheritdoc />
    public void Run()
    {
        int? input = ConsoleHelper.ReadInt("Введите размер матрицы N (не меньше 2): ");
        if (input is null)
        {
            return;
        }

        if (input.Value < 2)
        {
            Console.WriteLine("Размер матрицы должен быть не меньше 2.");
            return;
        }

        int size = input.Value;
        int[,] matrix = new int[size, size];
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                matrix[row, column] = Random.Shared.Next(1, 101);
            }
        }

        Console.WriteLine("Матрица:");
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                Console.Write($"{matrix[row, column],4}");
            }

            Console.WriteLine();
        }

        long diagonalSum = 0;
        for (int index = 0; index < size; index++)
        {
            diagonalSum += matrix[index, index];
        }

        Console.WriteLine($"Сумма главной диагонали: {diagonalSum}");
    }
}
