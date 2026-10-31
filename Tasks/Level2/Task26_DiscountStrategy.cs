using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>
/// Demonstrates the strategy pattern for applying price discounts.
/// </summary>
public sealed class Task26_DiscountStrategy : ITask
{
    /// <inheritdoc />
    public string Title => "Паттерн «Стратегия»: скидки";

    /// <inheritdoc />
    public string Description => "Рассчитывает стоимость с обычной, VIP- и промо-скидкой.";

    /// <inheritdoc />
    public string[] Requirements =>
    [
        "Создать IDiscountStrategy с методом Apply(decimal price).",
        "Реализовать NoDiscount, VipDiscount (10%) и PromoDiscount (20%).",
        "Передавать стратегию в конструктор PriceCalculator."
    ];

    /// <inheritdoc />
    public void Run()
    {
        const decimal price = 1_000m;
        IDiscountStrategy[] strategies = [new NoDiscount(), new VipDiscount(), new PromoDiscount()];
        foreach (IDiscountStrategy strategy in strategies)
        {
            PriceCalculator calculator = new(strategy);
            Console.WriteLine($"{strategy.GetType().Name}: {calculator.Calculate(price):C}");
        }
    }

    private interface IDiscountStrategy
    {
        decimal Apply(decimal price);
    }

    private sealed class NoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price;
    }

    private sealed class VipDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.90m;
    }

    private sealed class PromoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.80m;
    }

    private sealed class PriceCalculator(IDiscountStrategy strategy)
    {
        public decimal Calculate(decimal price)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(price);
            return strategy.Apply(price);
        }
    }
}
