using System;
using FifteenPuzzle;

namespace FifteenPuzzleViewConsole
{
	/// <summary>
	/// Класс - инструмент для отображени ConsoleView
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Главная точка входа в приложения
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			MainController controller = new MainController();
			ConsoleView view = new ConsoleView(controller);
			controller.AddView(view);
			ConsoleKey pressedKey;
			while (true)
			{
				view.StartNewGame();
				view.Launch();
				view.ShowResult();
				Console.WriteLine("Press E to exit, press other key to restart...\n");
				pressedKey = Console.ReadKey().Key;
				if (pressedKey == ConsoleKey.E)
					break;
			}
		}
	}
}
