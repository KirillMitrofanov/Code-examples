using System;
using System.Collections.Generic;
using System.IO;
using FifteenPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzleModelTest
{
	/// <summary>
	/// Модульный тест для класса ScoresSerializer
	/// </summary>
	[TestClass]
	public class ScoresSerializerTest
	{
		/// <summary>
		/// Общая для всего тестового класса переменная
		/// </summary>
		private List<Score> _scores;
		/// <summary>
		/// Метод инициализируюший значение
		/// общей для всего тестового класса переменной
		/// </summary>
		[TestInitialize]
		public void Initialize()
		{
			_scores = new List<Score>();
			_scores.Add(new Score("Bonehead", 250));
			_scores.Add(new Score("Coward", 170));
			_scores.Add(new Score("Master", 80));
		}

		/// <summary>
		/// Тест сериализации списка рекордов в файл
		/// (значение списка рекордов - null,
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void SerializeScoresTo_NullListValue_Test()
		{
			ScoresSerializer.SerializeScoresTo(null, "ScoresTest.bin");	
		}

		/// <summary>
		/// Тест сериализации списка рекордов в файл
		/// значение пути файла - путь к файлу, подходящему для записи)
		/// </summary>
		[TestMethod]
		public void SerializeScoresTo_CorrectFilePath_Test()
		{
			ScoresSerializer.SerializeScoresTo(_scores, "ScoresTest.bin");
		}

		/// <summary>
		/// Тест сериализации списка рекордов в файл
		/// (корректное значение списка рекордов,
		/// значение пути файла - путь к файлу только для чтения)
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(UnauthorizedAccessException))]
		public void SerializeScoresTo_PathOfReadOnlyFile_Test()
		{
			ScoresSerializer.SerializeScoresTo(_scores, "ReadOnlyFile.bin");
		}

		/// <summary>
		/// Тест сериализации и десериализации списка рекордов из файла
		/// (корректное значение списка рекордов,
		/// значение пути файла - путь к файлу подходящего для записи)
		/// </summary>
		[TestMethod]
		public void SerializeToFileAndDeserialize_CorrectValues_Test()
		{
			ScoresSerializer.SerializeScoresTo(_scores, "ScoresTest.bin");

			List<Score> actual = (List<Score>) ScoresSerializer.DeserializeScoresFrom("ScoresTest.bin");

			CollectionAssert.AreEqual(_scores, actual);
		}

		/// <summary>
		/// Тест сериализации списка рекордов в файл
		/// (пустое значение списка рекордов,
		/// значение пути файла - путь к файлу подходящего для чтения)
		/// </summary>
		[TestMethod]
		public void SerializeScoresTo_EmptyRecordsList_Test()
		{
			ScoresSerializer.SerializeScoresTo(new List<Score>(), "ScoresTest.bin");
		}

		/// <summary>
		/// Тест сериализации и десериализации списка рекордов из файла
		/// (Пустое значение списка рекордов,
		/// значение пути файла - путь к файлу подходящего для записи)
		/// </summary>
		[TestMethod]
		public void SerializeToFileAndDeserialize_EmptyListValue_Test()
		{
			ScoresSerializer.SerializeScoresTo(new List<Score>(), "ScoresTest.bin");

			List<Score> actual = (List<Score>)ScoresSerializer.DeserializeScoresFrom("ScoresTest.bin");
			CollectionAssert.AreEqual(new List<Score>(), actual);
		}

	}
}
