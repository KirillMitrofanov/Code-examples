using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FifteenPuzzle
{
	/// <summary>
	/// Класс-утилита, 
	/// необходимый для сохранения и загрузки существущих рекордов из файла
	/// </summary>
	public class ScoresSerializer
	{
		/// <summary>
		/// Сериализовать список рекордов в файл
		/// </summary>
		public static void SerializeScoresTo(IEnumerable<Score> parScores, string parFilePath)
		{
			if (parScores == null)
				throw new ArgumentNullException("Input scores is null!");

			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fileStream = new FileStream(parFilePath, FileMode.OpenOrCreate))
			{
				formatter.Serialize(fileStream, parScores);
			}
		}

		/// <summary>
		/// Десериализовать список рекордов из файла
		/// </summary>
		public static IEnumerable<Score> DeserializeScoresFrom(string parFilePath)
		{
			if (!File.Exists(parFilePath))
				new IOException("File " + parFilePath + " not found!");

			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fileStream = new FileStream(parFilePath, FileMode.OpenOrCreate))
			{
				if (fileStream.Length != 0)
				{
					return (IEnumerable<Score>) formatter.Deserialize(fileStream);
				}
				return null;
			}
		}
	}
}
