using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates inheritance and polymorphism with animals.
/// </summary>
public sealed class Task24_Animals : ITask
{
    /// <inheritdoc />
    public string Title => "ООП: Animal, Dog, Cat и Bird";

    /// <inheritdoc />
    public string Description => "Создаёт иерархию животных и вызывает переопределённые методы через базовый тип.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Создать абстрактный Animal с Name, MakeSound и информативным ToString.",
        "Реализовать Dog, Cat, Bird; у Bird добавить Fly.",
        "Продемонстрировать полиморфизм через List<Animal>."
    ];

    /// <inheritdoc />
    public void Run()
    {
        List<Animal> animals = [new Dog("Шарик"), new Cat("Мурка"), new Bird("Кеша")];
        foreach (Animal animal in animals)
        {
            Console.WriteLine($"{animal}: {animal.MakeSound()}");
            if (animal is Bird bird)
            {
                Console.WriteLine(bird.Fly());
            }
        }
    }

    private abstract class Animal(string name)
    {
        public string Name { get; } = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("Имя животного не может быть пустым.", nameof(name))
            : name;

        public abstract string MakeSound();

        public override string ToString() => $"{GetType().Name}: {Name}";
    }

    private sealed class Dog(string name) : Animal(name)
    {
        public override string MakeSound() => "Гав!";
    }

    private sealed class Cat(string name) : Animal(name)
    {
        public override string MakeSound() => "Мяу!";
    }

    private sealed class Bird(string name) : Animal(name)
    {
        public override string MakeSound() => "Чирик!";

        public string Fly() => $"{Name} летит.";
    }
}
