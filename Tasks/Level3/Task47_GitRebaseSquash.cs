using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Provides a checklist for squashing commits with interactive rebase.
/// </summary>
public sealed class Task47_GitRebaseSquash : ITask
{
    /// <inheritdoc />
    public string Title => "Git: rebase -i и squash коммитов";

    /// <inheritdoc />
    public string Description => "Объединяет четыре учебных коммита в один интерактивным rebase.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Создать feature/squash-demo и сделать четыре небольших коммита.",
        "Сохранить git log --oneline до и после git rebase -i HEAD~4 в git-notes.md."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine("Проводите упражнение в отдельном репозитории или учебной ветке:");
        Console.WriteLine("1. git switch -c feature/squash-demo");
        Console.WriteLine("2. Сделайте и сохраните четыре небольших коммита.");
        Console.WriteLine("3. git log --oneline -4  # сохраните вывод «до» в git-notes.md");
        Console.WriteLine("4. git rebase -i HEAD~4");
        Console.WriteLine("5. Оставьте первый коммит как pick, следующие три отметьте squash (или s).");
        Console.WriteLine("6. Сохраните сообщение объединённого коммита и завершите rebase.");
        Console.WriteLine("7. git log --oneline -4  # сохраните вывод «после» в git-notes.md");
        Console.WriteLine("Не переписывайте историю ветки, уже опубликованной и используемой другими.");
    }
}
