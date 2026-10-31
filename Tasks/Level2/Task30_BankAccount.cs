using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates a bank account with a custom insufficient-funds exception.
/// </summary>
public sealed class Task30_BankAccount : ITask
{
    /// <inheritdoc />
    public string Title => "BankAccount и своё исключение";

    /// <inheritdoc />
    public string Description => "Вносит и снимает деньги со счёта, не допуская отрицательного баланса.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Хранить баланс приватно и предоставить Deposit/Withdraw.",
        "Бросать InsufficientFundsException, если снятие превышает остаток.",
        "Показать успешную операцию и обработать отказ через try/catch."
    ];

    /// <inheritdoc />
    public void Run()
    {
        BankAccount account = new(500m);
        account.Deposit(100m);
        account.Withdraw(200m);
        Console.WriteLine($"Баланс после успешного снятия: {account.Balance:C}");

        try
        {
            account.Withdraw(1_000m);
        }
        catch (InsufficientFundsException exception)
        {
            Console.WriteLine($"Операция отклонена: {exception.Message}");
        }

        Console.WriteLine($"Итоговый баланс: {account.Balance:C}");
    }

    private sealed class BankAccount
    {
        private decimal _balance;

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Баланс не может быть отрицательным.");
            }

            _balance = initialBalance;
        }

        public decimal Balance => _balance;

        public void Deposit(decimal amount)
        {
            ValidatePositiveAmount(amount);
            _balance = checked(_balance + amount);
        }

        public void Withdraw(decimal amount)
        {
            ValidatePositiveAmount(amount);
            if (amount > _balance)
            {
                throw new InsufficientFundsException(
                    $"Запрошено {amount:C}, доступно {_balance:C}.");
            }

            _balance -= amount;
        }

        private static void ValidatePositiveAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма должна быть больше нуля.");
            }
        }
    }

    private sealed class InsufficientFundsException(string message) : Exception(message);
}
