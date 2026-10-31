using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates dynamically growing array-backed stack and queue implementations.
/// </summary>
public sealed class Task19_CustomCollections : ITask
{
    /// <inheritdoc />
    public string Title => "Свой стек и очередь на массиве";

    /// <inheritdoc />
    public string Description => "Показывает операции стека и очереди с динамическими массивами.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Реализовать MyStack<T> и MyQueue<T> с расширением массива вдвое.",
        "Пустые Pop и Dequeue должны бросать InvalidOperationException.",
        "Проверить более пяти операций на каждой коллекции."
    ];

    /// <inheritdoc />
    public void Run()
    {
        MyStack<int> stack = new();
        for (int number = 1; number <= 6; number++)
        {
            stack.Push(number);
        }

        Console.WriteLine($"Стек: Count={stack.Count}, Peek={stack.Peek()}, Pop={stack.Pop()}");
        while (!stack.IsEmpty)
        {
            Console.Write($"{stack.Pop()} ");
        }

        Console.WriteLine();

        MyQueue<string> queue = new();
        foreach (string name in new[] { "Аня", "Борис", "Вера", "Глеб", "Дина", "Егор" })
        {
            queue.Enqueue(name);
        }

        Console.WriteLine($"Очередь: Count={queue.Count}, Peek={queue.Peek()}, Dequeue={queue.Dequeue()}");
        while (!queue.IsEmpty)
        {
            Console.Write($"{queue.Dequeue()} ");
        }

        Console.WriteLine();
        try
        {
            _ = stack.Pop();
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine($"Пустой стек: {exception.Message}");
        }

        try
        {
            _ = queue.Dequeue();
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine($"Пустая очередь: {exception.Message}");
        }
    }
}

/// <summary>
/// Represents a last-in-first-out collection backed by a dynamically resized array.
/// </summary>
public sealed class MyStack<T>
{
    private T[] _items = new T[4];

    /// <summary>
    /// Gets the number of items in the stack.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets whether the stack has no items.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Adds an item to the top of the stack.
    /// </summary>
    public void Push(T item)
    {
        EnsureCapacity();
        _items[Count++] = item;
    }

    /// <summary>
    /// Removes and returns the item at the top of the stack.
    /// </summary>
    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Стек пуст.");
        }

        T item = _items[--Count];
        _items[Count] = default!;
        return item;
    }

    /// <summary>
    /// Returns the item at the top of the stack without removing it.
    /// </summary>
    public T Peek() =>
        IsEmpty ? throw new InvalidOperationException("Стек пуст.") : _items[Count - 1];

    private void EnsureCapacity()
    {
        if (Count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
    }
}

/// <summary>
/// Represents a first-in-first-out collection backed by a dynamically resized circular array.
/// </summary>
public sealed class MyQueue<T>
{
    private T[] _items = new T[4];
    private int _head;

    /// <summary>
    /// Gets the number of items in the queue.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets whether the queue has no items.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    /// Adds an item to the end of the queue.
    /// </summary>
    public void Enqueue(T item)
    {
        EnsureCapacity();
        int tail = (_head + Count) % _items.Length;
        _items[tail] = item;
        Count++;
    }

    /// <summary>
    /// Removes and returns the item at the beginning of the queue.
    /// </summary>
    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Очередь пуста.");
        }

        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        Count--;
        return item;
    }

    /// <summary>
    /// Returns the item at the beginning of the queue without removing it.
    /// </summary>
    public T Peek() =>
        IsEmpty ? throw new InvalidOperationException("Очередь пуста.") : _items[_head];

    private void EnsureCapacity()
    {
        if (Count < _items.Length)
        {
            return;
        }

        T[] expanded = new T[_items.Length * 2];
        for (int index = 0; index < Count; index++)
        {
            expanded[index] = _items[(_head + index) % _items.Length];
        }

        _items = expanded;
        _head = 0;
    }
}
