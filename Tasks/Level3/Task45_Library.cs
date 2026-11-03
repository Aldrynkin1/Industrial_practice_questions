using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>
/// Represents a book in the library.
/// </summary>
public sealed class Book(string title, string author)
{
    /// <summary>
    /// Gets the book title.
    /// </summary>
    public string Title { get; } = string.IsNullOrWhiteSpace(title)
        ? throw new ArgumentException("Название книги не может быть пустым.", nameof(title))
        : title;

    /// <summary>
    /// Gets the book author.
    /// </summary>
    public string Author { get; } = string.IsNullOrWhiteSpace(author)
        ? throw new ArgumentException("Автор книги не может быть пустым.", nameof(author))
        : author;

    /// <summary>
    /// Gets whether the book is available for borrowing.
    /// </summary>
    public bool IsAvailable { get; internal set; } = true;
}

/// <summary>
/// Represents a library reader and the books they have borrowed.
/// </summary>
public sealed class Reader(string name)
{
    private readonly List<Book> _borrowedBooks = [];

    /// <summary>
    /// Gets the reader name.
    /// </summary>
    public string Name { get; } = string.IsNullOrWhiteSpace(name)
        ? throw new ArgumentException("Имя читателя не может быть пустым.", nameof(name))
        : name;

    /// <summary>
    /// Gets the books currently borrowed by this reader.
    /// </summary>
    public IReadOnlyList<Book> BorrowedBooks => _borrowedBooks.AsReadOnly();

    internal void AddBook(Book book) => _borrowedBooks.Add(book);

    internal bool RemoveBook(Book book) => _borrowedBooks.Remove(book);
}

/// <summary>
/// Manages lending and returning books.
/// </summary>
public sealed class Library(IEnumerable<Book> books)
{
    private const int BorrowingLimit = 3;
    private readonly List<Book> _books = books.ToList();

    /// <summary>
    /// Borrows an available library book for a reader.
    /// </summary>
    public void BorrowBook(Book book, Reader reader)
    {
        ArgumentNullException.ThrowIfNull(book);
        ArgumentNullException.ThrowIfNull(reader);
        if (!_books.Contains(book))
        {
            throw new ArgumentException("Эта книга не входит в библиотечный фонд.", nameof(book));
        }

        if (!book.IsAvailable)
        {
            throw new InvalidOperationException($"Книга «{book.Title}» уже выдана.");
        }

        if (reader.BorrowedBooks.Count >= BorrowingLimit)
        {
            throw new InvalidOperationException($"Читатель не может взять больше {BorrowingLimit} книг.");
        }

        book.IsAvailable = false;
        reader.AddBook(book);
    }

    /// <summary>
    /// Returns a book borrowed by the specified reader.
    /// </summary>
    public void ReturnBook(Book book, Reader reader)
    {
        ArgumentNullException.ThrowIfNull(book);
        ArgumentNullException.ThrowIfNull(reader);
        if (!reader.RemoveBook(book))
        {
            throw new InvalidOperationException($"У читателя {reader.Name} нет этой книги.");
        }

        book.IsAvailable = true;
    }
}

/// <summary>
/// Demonstrates borrowing and returning books in a small library.
/// </summary>
public sealed class Task45_Library : ITask
{
    /// <inheritdoc />
    public string Title => "Мини-проект «Библиотека»";

    /// <inheritdoc />
    public string Description => "Демонстрирует выдачу и возврат книг с ограничением на число книг у читателя.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать Book, Reader и Library.",
        "Выдавать и возвращать книги; запрещать повторную выдачу и превышение лимита в три книги.",
        "Покрыть ключевые сценарии минимум пятью unit-тестами."
    ];

    /// <inheritdoc />
    public void Run()
    {
        Book book = new("Чистый код", "Роберт Мартин");
        Reader reader = new("Анна");
        Library library = new([book]);
        library.BorrowBook(book, reader);
        Console.WriteLine($"{reader.Name} взяла «{book.Title}». Доступна: {book.IsAvailable}");
        library.ReturnBook(book, reader);
        Console.WriteLine($"Книга возвращена. Доступна: {book.IsAvailable}");
        Console.WriteLine("Unit-тесты сценариев библиотеки находятся в проекте Tests/.");
    }
}
