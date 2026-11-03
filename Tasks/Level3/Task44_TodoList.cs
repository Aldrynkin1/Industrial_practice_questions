using System.Text.Json;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Represents a task in the todo list.
/// </summary>
public sealed class TaskItem
{
    /// <summary>
    /// Initializes an empty task item for JSON deserialization.
    /// </summary>
    public TaskItem()
    {
        Title = string.Empty;
    }

    /// <summary>
    /// Initializes a task item with the specified values.
    /// </summary>
    public TaskItem(int id, string title, bool isDone = false)
    {
        Id = id;
        Title = title;
        IsDone = isDone;
    }

    /// <summary>
    /// Gets or sets the task identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the task title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets whether the task has been completed.
    /// </summary>
    public bool IsDone { get; set; }
}

/// <summary>
/// Loads and persists todo items as JSON.
/// </summary>
public sealed class TaskRepository
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    private readonly string _filePath;
    private readonly List<TaskItem> _items;

    /// <summary>
    /// Initializes the repository from the specified JSON file, or starts empty if it does not exist.
    /// </summary>
    public TaskRepository(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        _filePath = filePath;
        if (!File.Exists(_filePath))
        {
            _items = [];
            return;
        }

        string json = File.ReadAllText(_filePath);
        _items = JsonSerializer.Deserialize<List<TaskItem>>(json)
            ?? throw new InvalidDataException("JSON-файл содержит null вместо списка задач.");
    }

    /// <summary>
    /// Gets a snapshot of all stored tasks.
    /// </summary>
    public IReadOnlyList<TaskItem> GetAll() =>
        _items.Select(item => new TaskItem(item.Id, item.Title, item.IsDone)).ToArray();

    /// <summary>
    /// Adds a task, saves the updated list, and returns the new item.
    /// </summary>
    public TaskItem Add(string title)
    {
        int id = checked(_items.Select(item => item.Id).DefaultIfEmpty(0).Max() + 1);
        TaskItem item = new(id, title);
        _items.Add(item);
        Save();
        return item;
    }

    /// <summary>
    /// Marks a task as done and saves the updated list.
    /// </summary>
    public bool MarkAsDone(int id)
    {
        TaskItem? item = _items.FirstOrDefault(candidate => candidate.Id == id);
        if (item is null)
        {
            return false;
        }

        item.IsDone = true;
        Save();
        return true;
    }

    /// <summary>
    /// Deletes a task and saves the updated list.
    /// </summary>
    public bool Delete(int id)
    {
        TaskItem? item = _items.FirstOrDefault(candidate => candidate.Id == id);
        if (item is null)
        {
            return false;
        }

        _items.Remove(item);
        Save();
        return true;
    }

    private void Save()
    {
        string? directory = Path.GetDirectoryName(Path.GetFullPath(_filePath));
        if (directory is not null)
        {
            Directory.CreateDirectory(directory);
        }

        File.WriteAllText(_filePath, JsonSerializer.Serialize(_items, JsonOptions));
    }
}

/// <summary>
/// Applies validation and business rules to todo operations.
/// </summary>
public sealed class TaskService(TaskRepository repository)
{
    /// <summary>
    /// Adds a task after validating its title.
    /// </summary>
    public TaskItem Add(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        return repository.Add(title.Trim());
    }

    /// <summary>
    /// Gets all tasks.
    /// </summary>
    public IReadOnlyList<TaskItem> GetAll() => repository.GetAll();

    /// <summary>
    /// Marks a task as done, returning false if it does not exist.
    /// </summary>
    public bool MarkAsDone(int id) => repository.MarkAsDone(id);

    /// <summary>
    /// Deletes a task, returning false if it does not exist.
    /// </summary>
    public bool Delete(int id) => repository.Delete(id);
}

/// <summary>
/// Runs an interactive todo list with JSON persistence.
/// </summary>
public sealed class Task44_TodoList : ITask
{
    /// <inheritdoc />
    public string Title => "Мини-проект Todo List: классы и JSON";

    /// <inheritdoc />
    public string Description => "Управляет задачами через меню и сохраняет изменения в tasks.json.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Использовать TaskItem, TaskRepository и TaskService.",
        "Поддержать добавление, вывод, отметку выполнения и удаление.",
        "Сохранять и загружать данные через System.Text.Json; сообщать о некорректном вводе и ошибках файла."
    ];

    /// <inheritdoc />
    public void Run()
    {
        try
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "tasks.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine("tasks.json не найден: открыт пустой список, файл появится после добавления задачи.");
            }

            RunMenu(new TaskService(new TaskRepository(filePath)));
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Ошибка файла списка задач: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Нет доступа к файлу списка задач: {exception.Message}");
        }
        catch (JsonException exception)
        {
            Console.WriteLine($"Не удалось прочитать tasks.json: {exception.Message}");
        }
        catch (InvalidDataException exception)
        {
            Console.WriteLine($"Некорректные данные tasks.json: {exception.Message}");
        }
    }

    private static void RunMenu(TaskService service)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Показать все задачи");
            Console.WriteLine("3. Отметить задачу выполненной");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("0. Назад");
            int? choice = ConsoleHelper.ReadInt("Выберите действие: ");
            if (choice is null or 0)
            {
                return;
            }

            switch (choice)
            {
                case 1:
                    AddTask(service);
                    break;
                case 2:
                    PrintTasks(service.GetAll());
                    break;
                case 3:
                    UpdateTask(service, markAsDone: true);
                    break;
                case 4:
                    UpdateTask(service, markAsDone: false);
                    break;
                default:
                    Console.WriteLine("Выберите действие от 0 до 4.");
                    break;
            }
        }
    }

    private static void AddTask(TaskService service)
    {
        Console.Write("Название задачи: ");
        string? title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Название не может быть пустым.");
            return;
        }

        TaskItem item = service.Add(title);
        Console.WriteLine($"Добавлена задача #{item.Id}.");
    }

    private static void UpdateTask(TaskService service, bool markAsDone)
    {
        int? id = ConsoleHelper.ReadInt("ID задачи: ");
        if (id is null)
        {
            return;
        }

        bool updated = markAsDone ? service.MarkAsDone(id.Value) : service.Delete(id.Value);
        Console.WriteLine(updated
            ? markAsDone ? "Задача отмечена выполненной." : "Задача удалена."
            : "Задача с таким ID не найдена.");
    }

    private static void PrintTasks(IReadOnlyList<TaskItem> items)
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        foreach (TaskItem item in items)
        {
            Console.WriteLine($"[{(item.IsDone ? "x" : " ")}] #{item.Id}: {item.Title}");
        }
    }
}
