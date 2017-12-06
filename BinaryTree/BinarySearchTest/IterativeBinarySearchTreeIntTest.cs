using System;
using System.Collections.Generic;
using BinarySearchTree;
using NUnit.Framework;

namespace BinarySearchTreeTest
{
	[TestFixture]
	public class IterativeBinarySearchTreeIntTest
	{
		[Test]
		[TestCaseSource(nameof(TestCasesCreateTreeFromCollection))]
		public IEnumerable<int> CreateTreeFromCollectionTest(List<int> items)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items);
			List<int> result = new List<int>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesCreateTreeFromCollection()
		{
			yield return new TestCaseData(new List<int> { 1 }).Returns(new List<int> { 1 });
			yield return new TestCaseData(new List<int> { 2, 1 }).Returns(new List<int> { 1, 2 });
			yield return new TestCaseData(new List<int> { 1, 2, 3 }).Returns(new List<int> { 1, 2, 3});
			yield return new TestCaseData(new List<int> { 2, 1, 3 }).Returns(new List<int> { 1, 2, 3 });
			yield return new TestCaseData(new List<int> { 0, 0, 0, 0, 0 }).Returns(new List<int> { 0, 0, 0, 0, 0 });
			yield return new TestCaseData(new List<int> { 7, 6, 5, 4, 3, 2, 1 }).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 7, 5 }).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
			yield return new TestCaseData(new List<int> { 4, 4, 4, 2, 2, 0, 0, 1, 1}).Returns(new List<int> { 0, 0, 1, 1, 2, 2, 4, 4, 4 });
			yield return new TestCaseData(new List<int>()).Returns(new List <int>());

			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesCreateTreeFromCollectionWithComparer))]
		public IEnumerable<int> CreateTreeFromCollectionWithComparerTest(List<int> items, IComparer<int> comparer)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items, comparer);
			List<int> result = new List<int>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesCreateTreeFromCollectionWithComparer()
		{
			yield return new TestCaseData(new List<int>(), new DataComparer<int>(OrderType.Inverse)).
				Returns(new List<int>());
			yield return new TestCaseData(new List<int> { 0, 0, 0, 0, 0 }, new DataComparer<int>(OrderType.Inverse)).
				Returns(new List<int> { 0, 0, 0, 0, 0 });
			yield return new TestCaseData(new List<int> { 1, 2, 3 }, new DataComparer<int>(OrderType.Inverse)).
				Returns(new List<int> { 3, 2, 1 });
			yield return new TestCaseData(new List<int> { 2, 1, 3 }, new DataComparer<int>(OrderType.Inverse)).
				Returns(new List<int> { 3, 2, 1 });
			yield return new TestCaseData(new List<int> { 7, 6, 5, 4, 3, 2, 1 }, new DataComparer<int>(OrderType.Inverse)).
				Returns(new List<int> { 7, 6, 5, 4, 3, 2, 1 });
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).
				Returns(new List<int> { 7, 6, 5, 4, 3, 2, 1 });
			yield return new TestCaseData(new List<int> { 4, 4, 4, 2, 2, 0, 0, 1, 1 }, new DataComparer<int>(OrderType.Inverse)).
				Returns(new List<int> { 4, 4, 4, 2, 2, 1, 1, 0, 0 });

			yield return new TestCaseData(new List<int>(), new DataComparer<int>(OrderType.Direct)).
				Returns(new List<int>());
			yield return new TestCaseData(new List<int> { 0, 0, 0, 0, 0 }, new DataComparer<int>(OrderType.Direct)).
				Returns(new List<int> { 0, 0, 0, 0, 0 });
			yield return new TestCaseData(new List<int> { 1, 2, 3 }, new DataComparer<int>(OrderType.Direct)).
				Returns(new List<int> { 1, 2, 3 });
			yield return new TestCaseData(new List<int> { 2, 1, 3 }, new DataComparer<int>(OrderType.Direct)).
				Returns(new List<int> { 1, 2, 3 });
			yield return new TestCaseData(new List<int> { 7, 6, 5, 4, 3, 2, 1 }, new DataComparer<int>(OrderType.Direct)).
				Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 7, 5 }, new DataComparer<int>(OrderType.Direct)).
				Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7});
			yield return new TestCaseData(new List<int> { 4, 4, 4, 2, 2, 0, 0, 1, 1 }, new DataComparer<int>(OrderType.Direct)).
				Returns(new List<int> { 0, 0, 1, 1, 2, 2, 4, 4, 4 });

			yield return new TestCaseData(null, new DataComparer<int>(OrderType.Inverse)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesAddData))]
		public IEnumerable<int> AddTest(List<int> items, int item)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items);
			tree.Add(item);

			List<int> result = new List<int>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesAddData()
		{
			yield return new TestCaseData(new List <int> { 1 }, 1).Returns(new List<int> { 1, 1 });
			yield return new TestCaseData(new List<int> { 1, 2 }, 0).Returns(new List<int> { 0, 1, 2 });
			yield return new TestCaseData(new List<int> { 1, 2 }, 2).Returns(new List<int> { 1, 2, 2 });
			yield return new TestCaseData(new List<int> { 1, 2 }, 3).Returns(new List <int> { 1, 2, 3 });
			yield return new TestCaseData(new List<int>(), 0).Returns(new List<int> { 0 }); 

			yield return new TestCaseData(null, 0).Throws(typeof(ArgumentNullException)); 
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetRight))]
		public int TestGetRight(List<int> items, IComparer<int> comparator)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items, comparator);
			return tree.GetRight().Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetRight()
		{
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).Returns(1);
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Direct)).Returns(7);

			yield return new TestCaseData(null, new DataComparer<int>(OrderType.Inverse)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetMax))]
		public int TestGetMax(List<int> items, IComparer<int> comparator)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items, comparator);
			return tree.GetMax(tree.Root).Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetMax()
		{
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Direct)).Returns(7);
			yield return new TestCaseData(new List<int> { 2, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Direct)).Returns(7);

			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).Returns(7);
			yield return new TestCaseData(new List<int> { 2, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).Returns(7);

			yield return new TestCaseData(null, new DataComparer<int>(OrderType.Direct)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetLeft))]
		public int TestGetLeft(List<int> items, IComparer<int> comparator)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items, comparator);
			return tree.GetLeft().Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetLeft()
		{
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Direct)).Returns(1);
			yield return new TestCaseData(new List<int> { 2, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Direct)).Returns(2);

			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).Returns(7);
			yield return new TestCaseData(new List<int> { 2, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).Returns(7);

			yield return new TestCaseData(null, new DataComparer<int>(OrderType.Direct)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetMin))]
		public int TestGetMin(List<int> items, IComparer<int> comparator)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items, comparator);
			return tree.GetMin(tree.Root).Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetMin()
		{
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Direct)).Returns(1);
			yield return new TestCaseData(new List<int> { 2, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Direct)).Returns(2);

			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).Returns(1);
			yield return new TestCaseData(new List<int> { 2, 4, 3, 6, 4, 7, 5 }, new DataComparer<int>(OrderType.Inverse)).Returns(2);

			yield return new TestCaseData(null, new DataComparer<int>(OrderType.Direct)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesReversedEnumerator))]
		public IEnumerable<int> TestReverseTraverse(List<int> items)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items);
			List<int> result = new List<int>();

			foreach (var item in tree.GetReversedEnumerator())
				result.Add(item);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesReversedEnumerator()
		{
			yield return new TestCaseData(new List<int> { 2, 1, 4, 3, 6, 4, 7, 5 }).Returns(new List<int> { 7, 6, 5, 4, 4, 3, 2, 1 });
			yield return new TestCaseData(new List<int> { 4, 2, 1, 4, 3, 6, 4, 7, 5 }).Returns(new List<int> { 7, 6, 5, 4, 4, 4, 3, 2, 1 });

			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesRemove))]
		public bool TestRemove(List<int> items, int value)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items);

			return tree.Remove(value);
		}

		private static IEnumerable<TestCaseData> TestCasesRemove()
		{
			yield return new TestCaseData(new List<int> { 1 }, 1).Returns(true);
			yield return new TestCaseData(new List<int> { 1, 2 }, 2).Returns(true);
			yield return new TestCaseData(new List<int> { 3, 1, 2 }, 2).Returns(true);
			yield return new TestCaseData(new List<int> { 4, 2, 1, 4, 3, 6, 4, 7, 5 }, 3).Returns(true);

			yield return new TestCaseData(new List<int>(), 3).Returns(false);
			yield return new TestCaseData(new List<int> { 1, 2 }, 3).Returns(false);
			yield return new TestCaseData(null, 1).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesSearch))]
		public int TestSearch(List<int> items, int value)
		{
			IterativeBinarySearchTree<int> tree = new IterativeBinarySearchTree<int>(items);
			return tree.Search(value).Data;
		}

		private static IEnumerable<TestCaseData> TestCasesSearch()
		{
			yield return new TestCaseData(new List<int> { 1 }, 1).Returns(1);
			yield return new TestCaseData(new List<int> { 1, 2 }, 2).Returns(2);
			yield return new TestCaseData(new List<int> { 3, 1, 2 }, 2).Returns(2);
			yield return new TestCaseData(new List<int> { 4, 2, 1, 4, 3, 6, 4, 7, 5 }, 3).Returns(3);

			yield return new TestCaseData(null, 1).Throws(typeof(ArgumentNullException));
		}
	}
}

