using CSharpPracticum.Common;

namespace CSharpPracticum.Menu;

/// <summary>
/// Displays the practicum's top-level menu.
/// </summary>
public sealed class MenuRunner
{
    private readonly LevelMenu _levelMenu = new();
    private readonly Level2Menu _level2Menu = new();

    /// <summary>
    /// Runs the main menu until the user exits.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–14 выполнены, задание 15 не входит в эту реализацию)");
            Console.WriteLine("2. Уровень 2 — Средний (задания 16–34; задание 35 требует удалённый репозиторий)");
            Console.WriteLine("3. Уровень 3 — Продвинутый (не реализован)");
            Console.WriteLine("0 или q. Выход");
            Console.Write("Выберите уровень: ");

            string? choice = Console.ReadLine();
            if (choice is null || choice.Trim().Equals("q", StringComparison.OrdinalIgnoreCase) ||
                choice.Trim() == "0")
            {
                return;
            }

            switch (choice.Trim())
            {
                case "1":
                    if (_levelMenu.Run())
                    {
                        return;
                    }

                    break;
                case "2":
                    if (_level2Menu.Run())
                    {
                        return;
                    }

                    break;
                case "3":
                    Console.WriteLine("Этот уровень пока не реализован.");
                    break;
                default:
                    Console.WriteLine("Неизвестный пункт меню. Выберите 1, 2, 3 или 0.");
                    break;
            }
        }
    }
}
