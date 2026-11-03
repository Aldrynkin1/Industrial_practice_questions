using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Provides a checklist for locating a regression with git bisect.
/// </summary>
public sealed class Task50_GitBisect : ITask
{
    /// <inheritdoc />
    public string Title => "Git: поиск регрессии через bisect";

    /// <inheritdoc />
    public string Description => "Использует бинарный поиск по истории, чтобы определить коммит с регрессией.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать учебную историю из десяти или более коммитов с известными good и bad точками.",
        "Выполнять git bisect good/bad до нахождения первого плохого коммита и затем git bisect reset.",
        "Сохранить вывод bisect в git-notes.md."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine("Используйте учебный репозиторий с десятью или более коммитами и проверяемым тестом:");
        Console.WriteLine("1. Убедитесь, что рабочее дерево чистое; запишите заведомо исправный хеш.");
        Console.WriteLine("2. git bisect start");
        Console.WriteLine("3. git bisect bad  # текущая версия не проходит проверку");
        Console.WriteLine("4. git bisect good <хеш-исправного-коммита>");
        Console.WriteLine("5. На каждом выбранном коммите запускайте проверку, затем git bisect good или git bisect bad.");
        Console.WriteLine("6. Сохраните вывод с найденным плохим коммитом в git-notes.md.");
        Console.WriteLine("7. git bisect reset");
        Console.WriteLine("Если проверку можно автоматизировать, используйте git bisect run <команда-теста>.");
    }
}
