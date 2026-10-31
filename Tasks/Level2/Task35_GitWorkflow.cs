using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Presents the Git workflow required for the level-two submission.
/// </summary>
public sealed class Task35_GitWorkflow : ITask
{
    /// <inheritdoc />
    public string Title => "Git: PR, Conventional Commits и rebase";

    /// <inheritdoc />
    public string Description =>
        "Задание выполняется в Git-репозитории с доступом к GitHub или GitLab; приложение показывает чек-лист.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Отдельным коммитом добавить .gitignore и .editorconfig.",
        "Создать feature/task-35, сделать Conventional Commits, отправить ветку и открыть PR в main.",
        "После merge выполнить интерактивный rebase трёх коммитов в feature/rebase-demo.",
        "Сохранить вывод git log --oneline в git-notes.md."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine("В текущей папке нет настроенного удалённого репозитория, поэтому PR и push не выполняются автоматически.");
        Console.WriteLine("Когда репозиторий будет связан с GitHub/GitLab, выполните по шагам:");
        Console.WriteLine("1. git status");
        Console.WriteLine("2. git add .gitignore .editorconfig");
        Console.WriteLine("3. git commit -m \"chore: add gitignore and editorconfig\"");
        Console.WriteLine("4. git switch -c feature/task-35");
        Console.WriteLine("5. Создайте 2–3 коммита с Conventional Commit сообщениями.");
        Console.WriteLine("6. git push -u origin feature/task-35");
        Console.WriteLine("7. Откройте PR в main с описанием изменений и проверок; после ревью выполните merge.");
        Console.WriteLine("8. git switch -c feature/rebase-demo main");
        Console.WriteLine("9. Создайте три небольших коммита, затем выполните git rebase -i HEAD~3 и squash.");
        Console.WriteLine("10. Сохраните вывод git log --oneline в git-notes.md.");
        Console.WriteLine();
        Console.WriteLine("Проверьте .gitignore и .editorconfig в корне проекта перед коммитом.");
    }
}
