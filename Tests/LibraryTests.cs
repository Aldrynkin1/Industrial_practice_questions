using CSharpPracticum.Tasks.Level3;
using Xunit;

namespace CSharpPracticum.Tests;

public sealed class LibraryTests
{
    [Fact]
    public void BorrowBook_MarksBookUnavailableAndAddsItToReader()
    {
        Book book = new("Книга", "Автор");
        Reader reader = new("Читатель");
        Library library = new([book]);

        library.BorrowBook(book, reader);

        Assert.False(book.IsAvailable);
        Assert.Contains(book, reader.BorrowedBooks);
    }

    [Fact]
    public void ReturnBook_MarksBookAvailableAndRemovesItFromReader()
    {
        Book book = new("Книга", "Автор");
        Reader reader = new("Читатель");
        Library library = new([book]);
        library.BorrowBook(book, reader);

        library.ReturnBook(book, reader);

        Assert.True(book.IsAvailable);
        Assert.Empty(reader.BorrowedBooks);
    }

    [Fact]
    public void BorrowBook_ThrowsWhenBookIsAlreadyBorrowed()
    {
        Book book = new("Книга", "Автор");
        Library library = new([book]);
        library.BorrowBook(book, new Reader("Первый"));

        Assert.Throws<InvalidOperationException>(() => library.BorrowBook(book, new Reader("Второй")));
    }

    [Fact]
    public void BorrowBook_ThrowsWhenReaderAlreadyHasThreeBooks()
    {
        Book[] books =
        [
            new("Книга 1", "Автор"),
            new("Книга 2", "Автор"),
            new("Книга 3", "Автор"),
            new("Книга 4", "Автор")
        ];
        Reader reader = new("Читатель");
        Library library = new(books);
        foreach (Book book in books.Take(3))
        {
            library.BorrowBook(book, reader);
        }

        Assert.Throws<InvalidOperationException>(() => library.BorrowBook(books[3], reader));
        Assert.True(books[3].IsAvailable);
    }

    [Fact]
    public void ReturnBook_ThrowsWhenReaderDoesNotHaveBook()
    {
        Book book = new("Книга", "Автор");
        Library library = new([book]);

        Assert.Throws<InvalidOperationException>(() => library.ReturnBook(book, new Reader("Читатель")));
        Assert.True(book.IsAvailable);
    }

    [Fact]
    public void BorrowBook_ThrowsWhenBookIsNotInLibrary()
    {
        Library library = new([]);

        Assert.Throws<ArgumentException>(() => library.BorrowBook(new Book("Книга", "Автор"), new Reader("Читатель")));
    }
}
