using System;
using System.Collections.Generic;
using System.Linq;

namespace FifteenPuzzle
{
	/// <summary>
	/// 
	/// </summary>
	public class MainController
	{
		/// <summary>
		/// Максимальное кол-во рекордов в списке
		/// </summary>
		private const int TOP_SCORES_COUNT = 10;
		/// <summary>
		/// Путь к файлу с рекордами
		/// </summary>
		private const string TOP_SCORES_FILE_PATH = "TopScores.bin";
		/// <summary>
		/// Экземпляр игрового поля
		/// </summary>
		private GameField _field;
		/// <summary>
		/// Текущее кол-во шагов
		/// </summary>
		private int _steps;
		/// <summary>
		/// Список рекордов
		/// </summary>
		private List<Score> _topScores;

		/// <summary>
		/// Cвойство доступа к полю _topScores
		/// </summary>
		public List<Score> TopScores
		{
			get { return _topScores; }
			set
			{
				if (value != null)
					_topScores = value;

				else
					throw new ArgumentNullException("Input TopScores is null!");
			}
		}
		/// <summary>
		/// Cвойство доступа к полю _field
		/// </summary>
		public GameField Field
		{
			get { return _field; }
			private set { _field = value; }
		}
		/// <summary>
		/// Cвойство доступа к полю _steps
		/// </summary>
		public int Steps
		{
			get { return _steps; }
			set
			{
				if (value >= 0)
					_steps = value;

				else
					throw new ArgumentException("Steps cann't be negative!");
			}
		}

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public MainController()
		{
			InitField();
			LoadTopScores();
			InitStartSteps();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="parView"></param>
		public void AddView(IView parView)
		{
			_field.FieldChanged += parView.Draw;
			parView.Draw();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parView"></param>
		public void RemoveView(IView parView)
		{
			_field.FieldChanged -= parView.Draw;
		}

		/// <summary>
		/// Попробовать сделать ход
		/// (поменять число с нулем)
		/// </summary>
		public bool TryMove(int parJ, int parI)
		{
			if (Field.TrySwapWithZero(parI, parJ))
			{
				Steps++;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Попробовать сделать ход
		/// (ноль с числом в указанном направлении)
		/// </summary>
		public bool TryMove(Directions moveDirection)
		{
			int i = _field.GetICoordinateOf(0);
			int j = _field.GetJCoordinateOf(0);

			Steps++;
			switch (moveDirection)
			{
				case Directions.Bottom:
					if (_field.TrySwapWithZero(i - 1, j))
						return true;
					break;

				case Directions.Left:
					if (_field.TrySwapWithZero(i, j + 1))
						return true;
					break;

				case Directions.Top:
					if (_field.TrySwapWithZero(i + 1, j))
						return true;
					break;

				case Directions.Right:
					if (_field.TrySwapWithZero(i, j - 1))
						return true;
					break;
			}
			Steps--;
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool IsInitialState()
		{
			return Field.IsInitialState();
		}

		/// <summary>
		/// Инициализировать экземпляр поля
		/// </summary>
		private void InitField()
		{
			_field = GameField.Instance;
		}
		/// <summary>
		/// Инициализировать начальное кол-во шагов
		/// </summary>
		private void InitStartSteps()
		{
			_steps = 0;
		}

		/// <summary>
		/// Загрузить рекорды из файла
		/// </summary>
		private void LoadTopScores()
		{
			List<Score> deserializedScores = 
				(List<Score>)ScoresSerializer.DeserializeScoresFrom(TOP_SCORES_FILE_PATH);

			if (deserializedScores == null)
				_topScores = new List<Score>();

			else
				_topScores = deserializedScores;
		}

		/// <summary>
		/// Начать новую игру
		/// </summary>
		public void StartNewGame()
		{
			Field.Shuffle();
			Steps = 0;
		}

		/// <summary>
		/// Показывает, попадает ли счет в топ 10
		/// </summary>
		/// <returns></returns>
		public bool IsScoreInTop()
		{
			if (TopScores.Count < TOP_SCORES_COUNT)
				return true;
			else
			{
				return Steps < TopScores[TOP_SCORES_COUNT - 1].Steps;
			}
		}

		/// <summary>
		/// Формировать список рекордов с учетом нового
		/// </summary>
		public void FormTopScoresWith(string parNickname)
		{
			AddScore(new Score(parNickname, Steps));
			SortTopScoresBySteps();
			TrimScoresOutOfTop();
		}

		/// <summary>
		/// Добавить рекорд в список
		/// </summary>
		private void AddScore(Score parScore)
		{
			_topScores.Add(parScore);
		}

		/// <summary>
		/// Сортировать список рекордов по кол-ву шагов
		/// </summary>
		private void SortTopScoresBySteps()
		{
			_topScores = _topScores.OrderBy(score => score.Steps).ToList();
		}

		/// <summary>
		/// Отсечь рекорды не попадающие в TOP_SCORES_COUNT лучших 
		/// </summary>
		private void TrimScoresOutOfTop()
		{
			if (_topScores.Count > TOP_SCORES_COUNT)
				_topScores = _topScores.Take(TOP_SCORES_COUNT).ToList();
		}
	}
}