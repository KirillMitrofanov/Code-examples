using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzle
{
	/// <summary>
	/// Класс реализующий логику работы игрового поля
	/// </summary>
	public class GameField : IEnumerable<int>
	{
		/// <summary>
		/// Внутренний экземпляр игрового поля,
		/// необходим для реализации шаблона Singletone
		/// </summary>
		private static GameField _instance;
		/// <summary>
		/// Числовая константа показывающая количество перемешиваний
		/// </summary>
		private const int SHUFFLE_COUNT = 3;
		/// <summary>
		/// Числовая константа показывающая количество
		/// возможных направлений для обмена 
		/// </summary>
		private const int DIRECTIONS_COUNT = 4;
		/// <summary>
		/// Числовая константа количество чисел в строке поля
		/// </summary>
		private const int SIDE_SIZE = 4;
		/// <summary>
		/// Константный двумерный массив, 
		/// необходим для инициализации игрового поля перед перемешиванием
		/// </summary>
		private readonly int[,] _initialField = new int[4, 4] { {1, 2, 3, 4 },
															{5, 6, 7, 8 },
															{9, 10, 11, 12},
															{13, 14, 15, 0 } };
		/// <summary>
		/// Внутренний двумерный массив,
		/// на нем организована логика перемещения чисел по игровому полю
		/// </summary>
		private int[,] _field = null;
		/// <summary>
		/// Переменная - псевдогенератор случайных чисел,
		/// необходимая для генерация направления перемешивания
		/// </summary>
		Random _random;
		/// <summary>
		/// Событие вызываемое при изменении начального состояния поля
		/// </summary>
		public event Action FieldChanged; 

		/// <summary>
		/// Конструкотор по умолчанию
		/// </summary>
		private GameField()
		{
			InitRandom();
			InitField();
			Shuffle();
			FieldChanged?.Invoke();
		}

		/// <summary>
		/// Свойство необходимое для получения статического экземпляра класса,
		/// необходимо для реализации шаблона Singletone
		/// </summary>
		public static GameField Instance
		{
			get
			{
				if (_instance == null)
					_instance = new GameField();

				return _instance;
			}
		}

		/// <summary>
		/// Метод сравнивающий текущее положение чисел на поле с начальным
		/// </summary>
		public bool IsInitialState()
		{
			return IsArraysEquals(_initialField, _field);
		}

		/// <summary>
		/// Сравнивает содержимое двух двумерных массивов поэлементно
		/// </summary>
		/// <returns></returns>
		private bool IsArraysEquals(int[,] parInitialField, int[,] parField)
		{
			if (parInitialField.GetLength(0) != parInitialField.GetLength(0)
					|| parInitialField.GetLength(1) != parInitialField.GetLength(1))
				return false;

			for(int i = 0; i < SIDE_SIZE; i++)
				for (int j = 0; j < SIDE_SIZE ; j++)
					if (parField[i, j] != parInitialField[i, j])
						return false;

			return true;
		}

		/// <summary>
		/// Начальная инициализация игрового поля
		/// </summary>
		private void InitField()
		{
			_field = (int[,])  _initialField.Clone();
		}

		/// <summary>
		/// 
		/// </summary>
		private void InitRandom()
		{
			_random = new Random(DateTime.Now.Millisecond);
		}

		#region Shuffle
		/// <summary>
		/// Перемешивание игрового поля
		/// </summary>
		public void Shuffle()
		{
			for (int counter = 0; counter < SHUFFLE_COUNT; counter++)
				SwapZeroToAnyDirection();

			ZeroToEnd();
		}

		/// <summary>
		/// Перемещение нуля в конец
		/// </summary>
		private void ZeroToEnd()
		{
			int i = GetICoordinateOf(0);
			int j = GetJCoordinateOf(0);

			while (!IsLastValue(0))
			{
				if (TrySwapWithRight(i, j))
					j = j + 1;

				if (TrySwapWithBottom(i, j))
					i = i + 1;
			}
		}

		/// <summary>
		/// Показывает является это значение последним (нижним-правым) на поле
		/// </summary>
		private bool IsLastValue(int parValue)
			=> _field[SIDE_SIZE - 1, SIDE_SIZE - 1] == parValue;

		/// <summary>
		/// Поменять ноль местами с числом в любом возможном направлении
		/// </summary>
		private void SwapZeroToAnyDirection()
		{
			int i = GetICoordinateOf(0);
			int j = GetJCoordinateOf(0);
			bool isSwapped = false;

			while (!isSwapped)
			{

				Directions nextDirection = (Directions)_random.Next(0, DIRECTIONS_COUNT);
				switch (nextDirection)
				{
					case Directions.Top:
						isSwapped = TrySwapWithTop(i, j);
						break;
					case Directions.Right:
						isSwapped = TrySwapWithRight(i, j);
						break;
					case Directions.Bottom:
						isSwapped = TrySwapWithBottom(i, j);
						break;
					case Directions.Left:
						isSwapped = TrySwapWithLeft(i, j);
						break;
				}
			}
		}

		/// <summary>
		/// Попробовать поменять число с левым
		/// </summary>
		private bool TrySwapWithLeft(int parI, int parJ)
		{
			if (!IsFirstColumn(parJ) && IsInField(parJ))
			{
				Swap(parI, parJ, parI, parJ - 1);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Попробовать поменять число с верхним
		/// </summary>
		private bool TrySwapWithTop(int parI, int parJ)
		{
			if (!IsFirstRow(parI) && IsInField(parI))
			{
				Swap(parI, parJ, parI - 1, parJ);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Попробовать поменять число с правым
		/// </summary>
		private bool TrySwapWithRight(int parI, int parJ)
		{
			if (!IsLastColumn(parJ) && IsInField(parJ))
			{
				Swap(parI, parJ, parI, parJ + 1);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Попробовать поменять число с нижним
		/// </summary>
		private bool TrySwapWithBottom(int parI, int parJ)
		{
			if (!IsLastRow(parI) && IsInField(parI))
			{
				Swap(parI, parJ, parI + 1, parJ);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Получить значение координаты I в поле
		/// для числа
		/// </summary>
		public int GetICoordinateOf(int parEement)
		{
			for (int i = 0; i < SIDE_SIZE; i++)
				for (int j = 0; j < SIDE_SIZE; j++)
					if (_field[i, j] == parEement)
						return i;

			throw new ArgumentException(nameof(parEement));
		}

		/// <summary>
		/// Получить значение координаты J в поле
		/// для числа
		/// </summary>
		public int GetJCoordinateOf(int parElement)
		{
			for (int i = 0; i < SIDE_SIZE; i++)
				for (int j = 0; j < SIDE_SIZE; j++)
					if (_field[i, j] == parElement)
						return j;

			throw new ArgumentException(nameof(parElement));
		}
		#endregion

		#region SwapWithZeroIfNear
		/// <summary>
		/// Меняет местаими число на позиции I, J с нулем, 
		/// если он рядом
		/// </summary>
		public bool TrySwapWithZero(int parI, int parJ)
		{
			if (!IsInField(parI) || !IsInField(parJ))
			{
				return false;
			}
			if (_field[parI, parJ] != 0)
			{
				if (IsZeroOnTheLeft(parI, parJ))
				{
					Swap(parI, parJ, parI, parJ - 1);
					return true;
				}
				else if (IsZeroOnTheTop(parI, parJ))
				{
					Swap(parI, parJ, parI - 1, parJ);
					return true;
				}
				else if (IsZeroOnTheRight(parI, parJ))
				{
					Swap(parI, parJ, parI, parJ + 1);
					return true;
				}
				else if (IsZeroOnTheBottom(parI, parJ))
				{
					Swap(parI, parJ, parI + 1, parJ);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Показывает, находиться ли слева от числа 
		/// имеющего координаты I, J ноль
		/// </summary>
		private bool IsZeroOnTheLeft(int parI, int parJ)
		{
			if (!IsFirstColumn(parJ) && IsInField(parJ))
				return _field[parI, parJ - 1] == 0;

			return false;
		}

		/// <summary>
		/// Показывает, находиться ли сверху от числа 
		/// имеющего координаты I, J ноль
		/// </summary>
		private bool IsZeroOnTheTop(int parI, int parJ)
		{
			if (!IsFirstRow(parI) && IsInField(parI))
				return _field[parI - 1, parJ] == 0;

			return false;
		}

		/// <summary>
		/// Показывает, находиться ли справа от числа 
		/// имеющего координаты I, J ноль
		/// </summary>
		private bool IsZeroOnTheRight(int parI, int parJ)
		{
			if (!IsLastColumn(parJ) && IsInField(parJ))
				return _field[parI, parJ + 1] == 0;

			return false;
		}

		/// <summary>
		/// Показывает, находиться ли снизу от числа 
		/// имеющего координаты I, J ноль
		/// </summary>
		private bool IsZeroOnTheBottom(int parI, int parJ)
		{
			if (!IsLastRow(parI) && IsInField(parI))
				return _field[parI + 1, parJ] == 0;

			return false;
		}
		#endregion

		/// <summary>
		/// Показывает, является ли строка I последней в поле
		/// </summary>
		private bool IsLastRow(int parI)
			=> parI == SIDE_SIZE - 1;

		/// <summary>
		/// Показывает, является ли строка I первой в поле
		/// </summary>
		private bool IsFirstRow(int parI)
			=> parI == 0;

		/// <summary>
		/// Показывает, является ли столбец J последним в поле
		/// </summary>
		private bool IsLastColumn(int parJ)
			=> parJ == SIDE_SIZE - 1;

		/// <summary>
		/// Показывает, является ли столбец J первым в поле
		/// </summary>
		private bool IsFirstColumn(int parJ)
			=> parJ == 0;

		/// <summary>
		/// Показывает, не выходит ли координата за границы поля
		/// </summary>
		private bool IsInField(int parCoordinate)
			=> parCoordinate >= 0 && parCoordinate <= SIDE_SIZE - 1; 

		/// <summary>
		/// Метод замены элемента с координатами I, J 
		/// c элементом с координатами newI, newJ
		/// </summary>
		private void Swap(int parI, int parJ, int parNewI, int parNewJ)
		{
			int temp = _field[parNewI, parNewJ];
			_field[parNewI, parNewJ] = _field[parI, parJ];
			_field[parI, parJ] = temp;
			FieldChanged?.Invoke();
		}

		/// <summary>
		/// Перегрузка метода ToString() для схематического \
		/// строкового отображения экземпляра поля
		/// </summary>
		public override string ToString()
		{
			StringBuilder field = new StringBuilder();
			for (int i = 0; i < SIDE_SIZE; i++)
			{
				for (int j = 0; j < SIDE_SIZE; j++)
				{
					field.Append($"{_field[i, j],3}");
				}
				field.Append("\n");
			}

			return field.ToString();
		}

		/// <summary>
		/// Реализация интерфейса IEnumerable
		/// </summary>
		public IEnumerator<int> GetEnumerator()
		{
			foreach (int number in _field)
			{
				yield return number;
			}
		}
		/// <summary>
		/// Реализация интерфейса IEnumerable
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
