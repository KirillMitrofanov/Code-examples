using System;
using FifteenPuzzle;

namespace FifteenPuzzleViewConsole
{
	/// <summary>
	/// Класс-представление модели в консольное приложение
	/// </summary>
	public class ConsoleView : IView
	{
		/// <summary>
		/// Переменная-контроллер
		/// </summary>
		private MainController _controller;
		/// <summary>
		/// Переменная - модель игрового поля 
		/// </summary>
		private GameField _field;
		/// <summary>
		/// Свойство доступа к полю _controller
		/// </summary>
		public MainController Controller
		{
			get { return _controller; }
			set
			{
				if (value != null)
					_controller = value;

				else
					throw new ArgumentNullException("Controller cann't be null!");
			}
		}
		/// <summary>
		/// Свойство доступа к полю _field
		/// </summary>
		public GameField Field
		{
			get { return _field; }
			set
			{
				if (value != null)
					_field = value;

				else
					throw new ArgumentNullException("Controller cann't be null!");
			}
		}

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public ConsoleView(MainController parController)
		{
			Controller = parController;
			_field = GameField.Instance;
		}

		/// <summary>
		/// Начать новую игру (перемешать поле)
		/// </summary>
		public void StartNewGame()
		{
			_controller.StartNewGame();
		}
		/// <summary>
		/// Запустить игру
		/// </summary>
		public void Launch()
		{
			while (!_controller.IsInitialState())
			{
				ConsoleKeyInfo keyInfo = Console.ReadKey();
				ConsoleKey pressedKey = keyInfo.Key;

				switch (pressedKey)
				{
					case ConsoleKey.LeftArrow:
						_controller.TryMove(Directions.Left);
						break;
					case ConsoleKey.UpArrow:
						_controller.TryMove(Directions.Top);
						break;
					case ConsoleKey.RightArrow:
						_controller.TryMove(Directions.Right);
						break;
					case ConsoleKey.DownArrow:
						_controller.TryMove(Directions.Bottom);
						break;
				}
			}
		}
		/// <summary>
		/// Отобразить результаты игры
		/// </summary>
		public void ShowResult()
		{
			Console.Clear();
			Console.WriteLine($"Congratulation, your total score: {_controller.Steps}!");
		}
		/// <summary>
		/// Отрисовать
		/// </summary>
		public void Draw()
		{
			Console.Clear();
			Console.WriteLine(_field.ToString());
			Console.WriteLine($"Steps: {_controller.Steps}");
		}
	}
}
