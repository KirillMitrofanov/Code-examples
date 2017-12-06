using System;

namespace FifteenPuzzle
{	
	/// <summary>
	/// Класс представляющий сущность запись Cчет
	/// </summary>
	[Serializable]
	public class Score
	{
		/// <summary>
		/// Никнейм игрока
		/// </summary>
		private string _nickname;
		/// <summary>
		/// Счет игрока
		/// </summary>
		private int _steps;

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Score(string parNickname, int parSteps)
		{
			Nickname = parNickname;
			Steps = parSteps;
		}

		/// <summary>
		/// Свойство доступа только для чтения для поля _nickname
		/// </summary>
		public string Nickname
		{
			get { return _nickname;  }
			set
			{
				if (!string.IsNullOrWhiteSpace(value))
					_nickname = value;

				else
					throw new ArgumentException("Nickname cann't be null or white space!");
			}
		}
		/// <summary>
		/// Свойство доступа только для чтения для поля _steps
		/// </summary>
		public int Steps
		{
			get { return _steps; }
			set
			{
				if (value >= 0)
					_steps = value;

				else
					throw new ArgumentException("Steps count cann't be negative!");
			}
		}

		/// <summary>
		/// Перегрузка метода ToString() для схематического
		/// строкового отображения экземпляра класса
		/// </summary>
		public override string ToString()
		{
			return $"Nickname: {Nickname} Steps: {Steps}";
		}

		/// <summary>
		/// Метод сравнения экземпляра класса Score с другими объектами
		/// </summary>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return this == null;

			if (!(obj is Score))
				return false;

			if (ReferenceEquals(this, obj))
				return true;

			Score score = (Score)obj;
			return score.Steps == Steps && score.Nickname == Nickname;
		}
	}
}
