using System;
using System.Collections.Generic;
using BinarySearchTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace BinarySearchTreeTest
{
	[TestClass]
	public class IterativeBinarySearchTreeStringTest
	{
		[Test]
		[TestCaseSource(nameof(TestCasesCreateTreeFromCollection))]
		public IEnumerable<string> CreateTreeFromCollectionTest(List<string> items)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items);
			List<string> result = new List<string>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesCreateTreeFromCollection()
		{
			yield return new TestCaseData(new List<string> { "1" }).Returns(new List<string> { "1" });
			yield return new TestCaseData(new List<string> { "2", "1" }).Returns(new List<string> { "1", "2" });
			yield return new TestCaseData(new List<string> { "1", "2", "3" }).Returns(new List<string> { "1", "2", "3" });
			yield return new TestCaseData(new List<string> { "2", "1", "3" }).Returns(new List<string> { "1", "2", "3" });
			yield return new TestCaseData(new List<string> { "0", "0", "0", "0", "0" }).Returns(new List<string> { "0", "0", "0", "0", "0" });
			yield return new TestCaseData(new List<string> { "7", "6", "5", "4", "3", "2", "1" }).Returns(new List<string> { "1", "2", "3", "4", "5", "6", "7" });
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "7", "5" }).Returns(new List<string> { "1", "2", "3", "4", "5", "6", "7" });
			yield return new TestCaseData(new List<string> { "4", "4", "4", "2", "2", "0", "0", "1", "1" }).Returns(new List<string> { "0", "0", "1", "1", "2", "2", "4", "4", "4" });
			yield return new TestCaseData(new List<string>()).Returns(new List<string>());

			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesCreateTreeFromCollectionWithComparer))]
		public IEnumerable<string> CreateTreeFromCollectionWithComparerTest(List<string> items, IComparer<string> comparer)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items, comparer);
			List<string> result = new List<string>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesCreateTreeFromCollectionWithComparer()
		{
			yield return new TestCaseData(new List<string>(), new DataComparer<string>(OrderType.Inverse)).
				Returns(new List<string>());
			yield return new TestCaseData(new List<string> { "0", "0", "0", "0", "0" }, new DataComparer<string>(OrderType.Inverse)).
				Returns(new List<string> { "0", "0", "0", "0", "0" });
			yield return new TestCaseData(new List<string> { "1", "2", "3" }, new DataComparer<string>(OrderType.Inverse)).
				Returns(new List<string> { "3", "2", "1" });
			yield return new TestCaseData(new List<string> { "2", "1", "3" }, new DataComparer<string>(OrderType.Inverse)).
				Returns(new List<string> { "3", "2", "1" });
			yield return new TestCaseData(new List<string> { "7", "6", "5", "4", "3", "2", "1" }, new DataComparer<string>(OrderType.Inverse)).
				Returns(new List<string> { "7", "6", "5", "4", "3", "2", "1" });
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).
				Returns(new List<string> { "7", "6", "5", "4", "3", "2", "1" });
			yield return new TestCaseData(new List<string> { "4", "4", "4", "2", "2", "0", "0", "1", "1" }, new DataComparer<string>(OrderType.Inverse)).
				Returns(new List<string> { "4", "4", "4", "2", "2", "1", "1", "0", "0" });

			yield return new TestCaseData(new List<string>(), new DataComparer<string>(OrderType.Direct)).
				Returns(new List<string>());
			yield return new TestCaseData(new List<string> { "0", "0", "0", "0", "0" }, new DataComparer<string>(OrderType.Direct)).
				Returns(new List<string> { "0", "0", "0", "0", "0" });
			yield return new TestCaseData(new List<string> { "1", "2", "3" }, new DataComparer<string>(OrderType.Direct)).
				Returns(new List<string> { "1", "2", "3" });
			yield return new TestCaseData(new List<string> { "2", "1", "3" }, new DataComparer<string>(OrderType.Direct)).
				Returns(new List<string> { "1", "2", "3" });
			yield return new TestCaseData(new List<string> { "7", "6", "5", "4", "3", "2", "1" }, new DataComparer<string>(OrderType.Direct)).
				Returns(new List<string> { "1", "2", "3", "4", "5", "6", "7" });
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "7", "5" }, new DataComparer<string>(OrderType.Direct)).
				Returns(new List<string> { "1", "2", "3", "4", "5", "6", "7" });
			yield return new TestCaseData(new List<string> { "4", "4", "4", "2", "2", "0", "0", "1", "1" }, new DataComparer<string>(OrderType.Direct)).
				Returns(new List<string> { "0", "0", "1", "1", "2", "2", "4", "4", "4" });

			yield return new TestCaseData(null, new DataComparer<string>(OrderType.Inverse)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesAddData))]
		public IEnumerable<string> AddTest(List<string> items, string item)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items);
			tree.Add(item);

			List<string> result = new List<string>();

			foreach (var data in tree)
				result.Add(data);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesAddData()
		{
			yield return new TestCaseData(new List<string> { "1" }, "1").Returns(new List<string> { "1", "1" });
			yield return new TestCaseData(new List<string> { "1", "2" }, "0").Returns(new List<string> { "0", "1", "2" });
			yield return new TestCaseData(new List<string> { "1", "2" }, "2").Returns(new List<string> { "1", "2", "2" });
			yield return new TestCaseData(new List<string> { "1", "2" }, "3").Returns(new List<string> { "1", "2", "3" });
			yield return new TestCaseData(new List<string>(), "0").Returns(new List<string> { "0" });

			yield return new TestCaseData(null, "0").Throws(typeof(ArgumentNullException));
		}
		
		[Test]
		[TestCaseSource(nameof(TestCasesGetRight))]
		public string TestGetRight(List<string> items, IComparer<string> comparator)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items, comparator);
			return tree.GetRight().Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetRight()
		{
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).Returns("1");
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Direct)).Returns("7");

			yield return new TestCaseData(null, new DataComparer<string>(OrderType.Inverse)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetMax))]
		public string TestGetMax(List<string> items, IComparer<string> comparator)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items, comparator);
			return tree.GetMax(tree.Root).Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetMax()
		{
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Direct)).Returns("7");
			yield return new TestCaseData(new List<string> { "2", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Direct)).Returns("7");

			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).Returns("7");
			yield return new TestCaseData(new List<string> { "2", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).Returns("7");

			yield return new TestCaseData(null, new DataComparer<string>(OrderType.Direct)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetLeft))]
		public string TestGetLeft(List<string> items, IComparer<string> comparator)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items, comparator);
			return tree.GetLeft().Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetLeft()
		{
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Direct)).Returns("1");
			yield return new TestCaseData(new List<string> { "2", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Direct)).Returns("2");

			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).Returns("7");
			yield return new TestCaseData(new List<string> { "2", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).Returns("7");

			yield return new TestCaseData(null, new DataComparer<string>(OrderType.Direct)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesGetMin))]
		public string TestGetMin(List<string> items, IComparer<string> comparator)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items, comparator);
			return tree.GetMin(tree.Root).Data;
		}

		private static IEnumerable<TestCaseData> TestCasesGetMin()
		{
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Direct)).Returns("1");
			yield return new TestCaseData(new List<string> { "2", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Direct)).Returns("2");

			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).Returns("1");
			yield return new TestCaseData(new List<string> { "2", "4", "3", "6", "4", "7", "5" }, new DataComparer<string>(OrderType.Inverse)).Returns("2");

			yield return new TestCaseData(null, new DataComparer<string>(OrderType.Direct)).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesReversedEnumerator))]
		public IEnumerable<string> TestReverseTraverse(List<string> items)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items);
			List<string> result = new List<string>();

			foreach (var item in tree.GetReversedEnumerator())
				result.Add(item);

			return result;
		}

		private static IEnumerable<TestCaseData> TestCasesReversedEnumerator()
		{
			yield return new TestCaseData(new List<string> { "2", "1", "4", "3", "6", "4", "7", "5" }).Returns(new List<string> { "7", "6", "5", "4", "4", "3", "2", "1" });
			yield return new TestCaseData(new List<string> { "4", "2", "1", "4", "3", "6", "4", "7", "5" }).Returns(new List<string> { "7", "6", "5", "4", "4", "4", "3", "2", "1" });

			yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesRemove))]
		public bool TestRemove(List<string> items, string value)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items);

			return tree.Remove(value);
		}

		private static IEnumerable<TestCaseData> TestCasesRemove()
		{
			yield return new TestCaseData(new List<string> { "1" }, "1").Returns(true);
			yield return new TestCaseData(new List<string> { "1", "2" }, "2").Returns(true);
			yield return new TestCaseData(new List<string> { "3", "1", "2" }, "2").Returns(true);
			yield return new TestCaseData(new List<string> { "4", "2", "1", "4", "3", "6", "4", "7", "5" }, "3").Returns(true);

			yield return new TestCaseData(new List<string>(), "3").Returns(false);
			yield return new TestCaseData(new List<string> { "1", "2" }, "3").Returns(false);
			yield return new TestCaseData(null, "1").Throws(typeof(ArgumentNullException));
		}

		[Test]
		[TestCaseSource(nameof(TestCasesSearch))]
		public string TestSearch(List<string> items, string value)
		{
			IterativeBinarySearchTree<string> tree = new IterativeBinarySearchTree<string>(items);
			return tree.Search(value).Data;
		}

		private static IEnumerable<TestCaseData> TestCasesSearch()
		{
			yield return new TestCaseData(new List<string> { "1" }, "1").Returns("1");
			yield return new TestCaseData(new List<string> { "1", "2" }, "2").Returns("2");
			yield return new TestCaseData(new List<string> { "3", "1", "2" }, "2").Returns("2");
			yield return new TestCaseData(new List<string> { "4", "2", "1", "4", "3", "6", "4", "7", "5" }, "3").Returns("3");

			yield return new TestCaseData(null, "1").Throws(typeof(ArgumentNullException));
		}

	}
}
