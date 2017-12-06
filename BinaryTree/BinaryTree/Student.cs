using System;

namespace BinarySearchTree
{
	public class Student : IComparable<Student>
	{
		public string Name { get; set; }
		public string TestName { get; set; }
		public DateTime TestDate { get; set; }
		public int Rating { get; set; }

		public Student(string name, string testName, DateTime testDate, int rating)
		{
			Name = name;
			TestName = testName;
			TestDate = testDate;
			Rating = rating;
		}

		public int CompareTo(Student other)
		{
			return Rating - other.Rating;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				throw new ArgumentNullException(nameof(obj));

			if (!(obj is Student))
				return false;

			Student student = (Student)obj;

			return Equals(student);
		}

		public bool Equals(Student other)
		{
			if (!(other is Student))
				return false;

			if (other == null)
				throw new ArgumentNullException(nameof(other));

			return other.Name == Name
				&& other.Rating == Rating
				&& other.TestDate == TestDate
				&& other.TestName == TestName;
		}
	}
}