using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates creating notification channels with a factory.
/// </summary>
public sealed class Task29_NotificationFactory : ITask
{
    /// <inheritdoc />
    public string Title => "Паттерн «Фабрика»: уведомления";

    /// <inheritdoc />
    public string Description => "Создаёт email, SMS и push-уведомления по значению enum.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Определить INotification.Send(string message).",
        "Реализовать EmailNotification, SmsNotification и PushNotification.",
        "Создавать соответствующий объект через NotificationFactory."
    ];

    /// <inheritdoc />
    public void Run()
    {
        foreach (NotificationType type in Enum.GetValues<NotificationType>())
        {
            INotification notification = NotificationFactory.Create(type);
            notification.Send("Практикум успешно выполнен.");
        }
    }

    private enum NotificationType
    {
        Email,
        Sms,
        Push
    }

    private interface INotification
    {
        void Send(string message);
    }

    private sealed class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Email: {message}");
    }

    private sealed class SmsNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"SMS: {message}");
    }

    private sealed class PushNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Push: {message}");
    }

    private static class NotificationFactory
    {
        public static INotification Create(NotificationType type) =>
            type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                NotificationType.Push => new PushNotification(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Неизвестный тип уведомления.")
            };
    }
}
