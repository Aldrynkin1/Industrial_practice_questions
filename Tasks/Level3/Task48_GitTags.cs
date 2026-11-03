using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Provides a checklist for creating and publishing an annotated Git tag.
/// </summary>
public sealed class Task48_GitTags : ITask
{
    /// <inheritdoc />
    public string Title => "Git: аннотированный тег v1.0.0";

    /// <inheritdoc />
    public string Description => "Показывает создание аннотированного тега и сохранение результатов.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "На стабильном коммите main создать аннотированный тег v1.0.0.",
        "Проверить git tag и git show v1.0.0; отправить тег и сохранить вывод в git-notes.md."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Console.WriteLine("Проверьте выбранный стабильный коммит и удалённый репозиторий перед публикацией:");
        Console.WriteLine("1. git switch main");
        Console.WriteLine("2. git status  # убедитесь, что рабочее дерево чистое");
        Console.WriteLine("3. git tag -a v1.0.0 -m \"Release v1.0.0\"");
        Console.WriteLine("4. git tag");
        Console.WriteLine("5. git show v1.0.0  # сохраните оба вывода в git-notes.md");
        Console.WriteLine("6. git push origin v1.0.0  # отправляет тег на сервер");
    }
}
