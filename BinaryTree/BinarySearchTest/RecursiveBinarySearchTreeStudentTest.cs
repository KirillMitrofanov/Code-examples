using System;
using System.Collections.Generic;
using BinarySearchTree;
using NUnit.Framework;

namespace BinarySearchTreeTest
{
	[TestFixture]
	public class RecursiveBinarySearchTreeStudentTest
	{
		Student first = new Student("Дмитрий", "Math", DateTime.Today, 1);
		Student second = new Student("Тёма", "Math", DateTime.Today, 2);
		Student third = new Student("Даниил", "Math", DateTime.Today, 3);
		Student fourth = new Student("Саня", "Math", DateTime.Today, 4);
		Student fifth = new Student("Кирилл", "Math", DateTime.Today, 5);

		[Test]
		[TestCaseSource(nameof(TestCasesCreateTreeFromCollection))]
		public IEnumerable<Student> CreateTreeFromCollectionTest(List<Student> items)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items);
			List<Student> result = new List<Student>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private IEnumerable<TestCaseData> TestCasesCreateTreeFromCollection()
		{
			yield return new TestCaseData(new List<Student> { first })
				.Returns(new List<Student> { first });
			yield return new TestCaseData(new List<Student> { second })
				.Returns(new List<Student> { second });
			yield return new TestCaseData(new List<Student> { third })
				.Returns(new List<Student> { third });
			yield return new TestCaseData(new List<Student> { fourth })
				.Returns(new List<Student> { fourth });
			yield return new TestCaseData(new List<Student> { fifth })
				.Returns(new List<Student> { fifth });

			yield return new TestCaseData(new List<Student> { second, first })
				.Returns(new List<Student> { first, second });
			yield return new TestCaseData(new List<Student> { first, second, third })
				.Returns(new List<Student> { first, second, third });
			yield return new TestCaseData(new List<Student> { second, first, third })
				.Returns(new List<Student> { first, second, third });
			yield return new TestCaseData(new List<Student> { first, first, first, first, first })
				.Returns(new List<Student> { first, first, first, first, first });
			yield return new TestCaseData(new List<Student> { fifth, fourth, third, second, first })
				.Returns(new List<Student> { first, second, third, fourth, fifth });
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fifth })
				.Returns(new List<Student> { first, second, third, fourth, fifth });
			yield return new TestCaseData(new List<Student> { fourth, fourth, fourth, second, second, first, first, first, first })
				.Returns(new List<Student> { first, first, first, first, second, second, fourth, fourth, fourth });
			yield return new TestCaseData(new List<Student>()).Returns(new List<Student>());

			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesCreateTreeFromCollectionWithComparer))]
		public IEnumerable<Student> CreateTreeFromCollectionWithComparerTest(List<Student> items, IComparer<Student> comparer)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items, comparer);
			List<Student> result = new List<Student>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private IEnumerable<TestCaseData> TestCasesCreateTreeFromCollectionWithComparer()
		{
			yield return new TestCaseData(new List<Student>(), new DataComparer<Student>(OrderType.Inverse)).
				Returns(new List<Student>());
			yield return new TestCaseData(new List<Student> { first, first, first, first, first }, 
				new DataComparer<Student>(OrderType.Inverse)).
				Returns(new List<Student> { first, first, first, first, first });
			yield return new TestCaseData(new List<Student> { first, second, third },
				new DataComparer<Student>(OrderType.Inverse)).
				Returns(new List<Student> { third, second, first });
			yield return new TestCaseData(new List<Student> { second, first, third }, 
				new DataComparer<Student>(OrderType.Inverse)).
				Returns(new List<Student> { third, second, first });
			yield return new TestCaseData(new List<Student> { fifth, fourth, third, second, first }, 
				new DataComparer<Student>(OrderType.Inverse)).
				Returns(new List<Student> { fifth, fourth, third, second, first });
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fifth }, 
				new DataComparer<Student>(OrderType.Inverse)).
				Returns(new List<Student> { fifth, fourth, third, second, first });
			yield return new TestCaseData(new List<Student> { fourth, fourth, fourth, second, second, first, first, first, first }, new DataComparer<Student>(OrderType.Inverse)).
				Returns(new List<Student> { fourth, fourth, fourth, second, second, first, first, first, first });

			yield return new TestCaseData(new List<Student>(), 
				new DataComparer<Student>(OrderType.Direct)).
				Returns(new List<Student>());
			yield return new TestCaseData(new List<Student> { first, first, first, first, first }, 
				new DataComparer<Student>(OrderType.Direct)).
				Returns(new List<Student> { first, first, first, first, first });
			yield return new TestCaseData(new List<Student> { first, second, third }, 
				new DataComparer<Student>(OrderType.Direct)).
				Returns(new List<Student> { first, second, third });
			yield return new TestCaseData(new List<Student> { second, first, third }, 
				new DataComparer<Student>(OrderType.Direct)).
				Returns(new List<Student> { first, second, third });
			yield return new TestCaseData(new List<Student> { fifth, fourth, third, second, first }, 
				new DataComparer<Student>(OrderType.Direct)).
				Returns(new List<Student> { first, second, third, fourth, fifth });
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fifth }, 
				new DataComparer<Student>(OrderType.Direct)).
				Returns(new List<Student> { first, second, third, fourth, fifth });
			yield return new TestCaseData(new List<Student> { fourth, fourth, fourth, second, second, first, first, first, first },
				new DataComparer<Student>(OrderType.Direct)).
				Returns(new List<Student> { first, first, first, first, second, second, fourth, fourth, fourth });

			yield return new TestCaseData(null, new DataComparer<Student>(OrderType.Inverse)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesAddData))]
		public IEnumerable<Student> AddTest(List<Student> items, Student item)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items) {item};

			List<Student> result = new List<Student>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private IEnumerable<TestCaseData> TestCasesAddData()
		{
			yield return new TestCaseData(new List<Student> { first }, first)
				.Returns(new List<Student> { first, first });
			yield return new TestCaseData(new List<Student> { first, second }, first)
				.Returns(new List<Student> { first, first, second });
			yield return new TestCaseData(new List<Student> { first, second }, second)
				.Returns(new List<Student> { first, second, second });
			yield return new TestCaseData(new List<Student> { first, second }, third)
				.Returns(new List<Student> { first, second, third });
			yield return new TestCaseData(new List<Student>(), first)
				.Returns(new List<Student> { first });

			yield return new TestCaseData(null, first).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetRight))]
		public Student TestGetRight(List<Student> items, IComparer<Student> comparator)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items, comparator);
			return tree.GetRight().Data;
		}

		private IEnumerable<TestCaseData> TestCasesGetRight()
		{
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Inverse)).Returns(first);
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Direct)).Returns(fifth);

			yield return new TestCaseData(null, new DataComparer<Student>(OrderType.Inverse)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetMax))]
		public Student TestGetMax(List<Student> items, IComparer<Student> comparator)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items, comparator);
			return tree.GetMax(tree.Root).Data;
		}

		private IEnumerable<TestCaseData> TestCasesGetMax()
		{
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Direct)).Returns(fifth);
			yield return new TestCaseData(new List<Student> { second, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Direct)).Returns(fifth);

			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Inverse)).Returns(fifth);
			yield return new TestCaseData(new List<Student> { second, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Inverse)).Returns(fifth);

			yield return new TestCaseData(null, new DataComparer<Student>(OrderType.Direct))
				.Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetLeft))]
		public Student TestGetLeft(List<Student> items, IComparer<Student> comparator)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items, comparator);
			return tree.GetLeft().Data;
		}

		private IEnumerable<TestCaseData> TestCasesGetLeft()
		{
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Direct)).Returns(first);
			yield return new TestCaseData(new List<Student> { second, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Direct)).Returns(second);

			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Inverse)).Returns(fifth);
			yield return new TestCaseData(new List<Student> { second, fourth, third, fourth, fifth },
				new DataComparer<Student>(OrderType.Inverse)).Returns(fifth);

			yield return new TestCaseData(null, new DataComparer<Student>(OrderType.Direct))
				.Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetMin))]
		public Student TestGetMin(List<Student> items, IComparer<Student> comparator)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items, comparator);
			return tree.GetMin(tree.Root).Data;
		}

		private IEnumerable<TestCaseData> TestCasesGetMin()
		{
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth }, 
				new DataComparer<Student>(OrderType.Direct)).Returns(first);
			yield return new TestCaseData(new List<Student> { second, fourth, third, fourth, fifth }, 
				new DataComparer<Student>(OrderType.Direct)).Returns(second);

			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth }, 
				new DataComparer<Student>(OrderType.Inverse)).Returns(first);
			yield return new TestCaseData(new List<Student> { second, fourth, third, fourth, fifth }, 
				new DataComparer<Student>(OrderType.Inverse)).Returns(second);

			yield return new TestCaseData(null, new DataComparer<Student>(OrderType.Direct))
				.Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesReversedEnumerator))]
		public IEnumerable<Student> TestReverseTraverse(List<Student> items)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items);
			List<Student> result = new List<Student>();

			foreach (var item in tree.GetReversedEnumerator())
				result.Add(item);

			return result;
		}

		private IEnumerable<TestCaseData> TestCasesReversedEnumerator()
		{
			yield return new TestCaseData(new List<Student> { second, first, fourth, third, fourth, fifth }).Returns(new List<Student> { fifth, fourth, fourth, third, second, first });
			yield return new TestCaseData(new List<Student> { fourth, second, first, fourth, third, fourth, fifth }).Returns(new List<Student> { fifth, fourth, fourth, fourth, third, second, first });

			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesRemove))]
		public bool TestRemove(List<Student> items, Student value)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items);

			return tree.Remove(value);
		}

		private IEnumerable<TestCaseData> TestCasesRemove()
		{
			yield return new TestCaseData(new List<Student> { first }, first).Returns(true);
			yield return new TestCaseData(new List<Student> { first, second }, second).Returns(true);
			yield return new TestCaseData(new List<Student> { third, first, second }, second).Returns(true);
			yield return new TestCaseData(new List<Student> { fourth, second, first, fourth, third, fourth, fifth }, third).Returns(true);

			yield return new TestCaseData(new List<Student>(), third).Returns(false);
			yield return new TestCaseData(new List<Student> { first, second }, third).Returns(false);
			yield return new TestCaseData(null, first).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesSearch))]
		public Student TestSearch(List<Student> items, Student value)
		{
			RecursiveBinarySearchTree<Student> tree = new RecursiveBinarySearchTree<Student>(items);
			return tree.Search(value).Data;
		}

		private IEnumerable<TestCaseData> TestCasesSearch()
		{
			yield return new TestCaseData(new List<Student> { first }, first).Returns(first);
			yield return new TestCaseData(new List<Student> { first, second }, second).Returns(second);
			yield return new TestCaseData(new List<Student> { third, first, second }, second).Returns(second);
			yield return new TestCaseData(new List<Student> { fourth, second, first, fourth, third, fourth, fifth }, third).Returns(third);

			yield return new TestCaseData(null, first).Throws(typeof(ArgumentNullException));
		}
	}
}


