using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates disposing a file writer with using statements and declarations.
/// </summary>
public sealed class Task31_DisposableFileWriter : ITask
{
    /// <inheritdoc />
    public string Title => "IDisposable и using";

    /// <inheritdoc />
    public string Description => "Записывает файл объектом FileWriter и проверяет повторную запись после закрытия.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать FileWriter с StreamWriter и Dispose().",
        "Показать using-блок и using-декларацию.",
        "После освобождения ресурса дописать файл и прочитать результат."
    ];

    /// <inheritdoc />
    public void Run()
    {
        string path = Path.Combine(Path.GetTempPath(), $"csharp-practicum-{Guid.NewGuid():N}.txt");
        try
        {
            using (FileWriter writer = new(path))
            {
                writer.WriteLine("Запись через using-блок.");
            }

            File.AppendAllText(path, "Повторная запись после закрытия потока." + Environment.NewLine);
            WriteWithDeclaration(path);
            Console.WriteLine(File.ReadAllText(path));
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }

    private static void WriteWithDeclaration(string path)
    {
        using FileWriter writer = new(path);
        writer.WriteLine("Запись через using-декларацию.");
    }

    private sealed class FileWriter : IDisposable
    {
        private readonly StreamWriter _writer;
        private bool _disposed;

        public FileWriter(string path)
        {
            _writer = new StreamWriter(path, append: true);
        }

        public void WriteLine(string text)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            _writer.WriteLine(text);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _writer.Dispose();
            _disposed = true;
        }
    }
}
