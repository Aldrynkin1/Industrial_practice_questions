using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Provides a guarded checklist for recovering a commit with reflog.
/// </summary>
public sealed class Task49_GitReflog : ITask
{
    /// <inheritdoc />
    public string Title => "Git: восстановление коммита через reflog";

    /// <inheritdoc />
    public string Description => "Описывает восстановление учебного коммита по reflog после перемещения HEAD.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Выполнить учебный коммит, найти его через git reflog после перемещения HEAD.",
        "Восстановить ссылку и сохранить git reflog и git log --oneline в git-notes.md."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine("ВНИМАНИЕ: reset --hard удаляет незакоммиченные изменения. Используйте только disposable-клон.");
        Console.WriteLine("1. Создайте отдельный учебный коммит и запишите его хеш.");
        Console.WriteLine("2. Убедитесь, что в disposable-клоне нет нужных незакоммиченных изменений.");
        Console.WriteLine("3. git reset --hard HEAD~1  # разрушительная команда; не запускайте в рабочем проекте");
        Console.WriteLine("4. git reflog  # найдите хеш учебного коммита и сохраните вывод");
        Console.WriteLine("5. git reset --hard <хеш-коммита>  # восстановление также перемещает HEAD");
        Console.WriteLine("6. git reflog и git log --oneline  # сохраните вывод в git-notes.md");
    }
}
