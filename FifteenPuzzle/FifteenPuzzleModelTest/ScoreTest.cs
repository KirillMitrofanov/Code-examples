using System;
using FifteenPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzleModelTest
{
	/// <summary>
	/// Модульный тест для класса Score
	/// </summary>
	[TestClass]
	public class ScoreTest
	{
		/// <summary>
		/// Общая для всего тестового класса переменная
		/// </summary>
		Score _firstScore;
		/// <summary>
		/// Метод инициализируюший значение
		/// общей для всего тестового класса переменной
		/// </summary>
		[TestInitialize]
		public void InitializeValues()
		{
			_firstScore = new Score("mitroha", 80);
		}

		/// <summary>
		/// Тест конструктора по умолчанию
		/// (входное значение параметра Steps - отрицательное число)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CtorDefault_NegativeStepsValue_Test()
		{
			Score score = new Score("mitroha", -1);
		}

		/// <summary>
		/// Тест конструктора по умолчанию
		/// (входное значение параметра Nickname - null)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CtorDefault_NicknameIsNull_Test()
		{
			Score score = new Score(null, 50);
		}

		/// <summary>
		/// Тест конструктора по умолчанию
		/// (входное значение параметра Nickname - пробелы)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CtorDefault_NicknameIsWhitespace_Test()
		{
			Score score = new Score("   ", 50);
		}

		/// <summary>
		/// Тест конструктора по умолчанию
		/// (входное значение параметра Nickname - пустая строка)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CtorDefault_NicknameIsEmpty_Test()
		{
			Score score = new Score("", 50);
		}

		/// <summary>
		/// Тест конструктора по умолчанию
		/// (Все входные значения верны)
		/// </summary>
		[TestMethod]
		public void CtorDefault_AllCorrectValues_Test()
		{
			Score score = new Score("mitroha", 50);

			Assert.AreEqual(50, score.Steps);
			Assert.AreEqual("mitroha", score.Nickname);
		}

		/// <summary>
		/// Тест свойства Steps
		/// (входное значение - число больше нуля)
		/// </summary>
		[TestMethod]
		public void PropertySteps_MoreThanZeroValue_Test()
		{
			_firstScore.Steps = 1;

			int expected = 1;
			int actual = _firstScore.Steps;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест свойства Steps
		/// (входное значение - ноль)
		/// </summary>
		[TestMethod]
		public void PropertySteps_ZeroValue_Test()
		{
			_firstScore.Steps = 0;

			int expected = 0;
			int actual = _firstScore.Steps;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест свойства Steps
		/// (входное значение - большое число)
		/// </summary>
		[TestMethod]
		public void PropertySteps_BigValue_Test()
		{
			_firstScore.Steps = 999999999;

			int expected = 999999999;
			int actual = _firstScore.Steps;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест свойства Steps
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PropertySteps_NegativeValue_Test()
		{
			_firstScore.Steps = -1;
		}

		/// <summary>
		/// Тест свойства Nickname
		/// (входное значение - пустая строка)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PropertyNickname_EmptyValue_Test()
		{
			_firstScore.Nickname = "";
		}

		/// <summary>
		/// Тест свойства Nickname
		/// (входное значение - пробелы)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PropertyNickname_WhiteSpaceValue_Test()
		{
			_firstScore.Nickname = "   ";
		}

		/// <summary>
		/// Тест свойства Nickname
		/// (входное значение - null)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PropertyNickname_NullValue_Test()
		{
			_firstScore.Nickname = null;
		}
	}
}
