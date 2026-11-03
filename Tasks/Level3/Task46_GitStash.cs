using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Provides a safe checklist for demonstrating git stash.
/// </summary>
public sealed class Task46_GitStash : ITask
{
    /// <inheritdoc />
    public string Title => "Git: git stash и stash pop";

    /// <inheritdoc />
    public string Description => "Показывает последовательность сохранения и восстановления незакоммиченных изменений.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Изменить учебный файл, выполнить git stash и проверить git stash list.",
        "Переключиться на другую ветку и обратно, затем выполнить git stash pop.",
        "Записать вывод до и после в git-notes.md."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine("Выполняйте команды в отдельной учебной ветке, чтобы не затронуть чужие изменения:");
        Console.WriteLine("1. Измените учебный файл и проверьте: git status");
        Console.WriteLine("2. git stash push -m \"task 46 demo\"");
        Console.WriteLine("3. git stash list  # сохраните вывод в git-notes.md");
        Console.WriteLine("4. git switch <другая-учебная-ветка>");
        Console.WriteLine("5. git switch <исходная-учебная-ветка>");
        Console.WriteLine("6. git stash pop");
        Console.WriteLine("7. git stash list  # сохраните вывод после восстановления в git-notes.md");
        Console.WriteLine("Если возник конфликт, разрешите его вручную; не удаляйте чужие изменения.");
    }
}
