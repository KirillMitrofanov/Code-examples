using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
	public class RecursiveBinarySearchTree<TItem> : 
		AbstractBinarySearchTree<TItem>, 
		IEnumerable<TItem> where TItem: IComparable<TItem>
	{
		public RecursiveBinarySearchTree()
		{ }
		public RecursiveBinarySearchTree(IEnumerable<TItem> collection) 
			: base(collection) { }
		public RecursiveBinarySearchTree(IEnumerable<TItem> collection, IComparer<TItem> nodeDataComparer) 
			: base(collection, nodeDataComparer) { }
		public RecursiveBinarySearchTree(IComparer<TItem> nodeDataComparer) 
			: base(nodeDataComparer) { }

		public override void Add(TItem value)
		{
			if (!(value is ValueType))
				if (value == null)
					throw new ArgumentNullException(nameof(value));

			if (Root == null)
			{
				Root = new Node<TItem>(value);
				return;
			}

			Node<TItem> node = Root;
			Add(value, ref node);
			Root = node;
		}
		private void Add(TItem value, ref Node<TItem> node)
		{
			if (node == null)
			{
				node = new Node<TItem>(value);
				return;
			}
			if (Compare(value, node.Data) < 0)
			{
				Node<TItem> next = node.Left;
				Add(value, ref next);
				node.Left = next;
			}
			else
			{
				Node<TItem> next = node.Right;
				Add(value, ref next);
				node.Right = next;
			}
		}

		public override bool Remove(TItem value)
		{
			if (!(value is ValueType))
				if (value == null)
					throw new ArgumentNullException(nameof(value));

			Node<TItem> node = Root;
			bool isRemoved = Remove(value, ref node);
			Root = node;
			return isRemoved;
		}
		private bool Remove(TItem value, ref Node<TItem> curent)
		{
			if (curent == null)
				return false;

			if (Compare(value, curent.Data) > 0)
			{
				Node<TItem> next = curent.Right;
				bool isRemoved = Remove(value, ref next);
				curent.Right = next;
				return isRemoved;
			}
			if (Compare(value, curent.Data) < 0)
			{
				Node<TItem> next = curent.Left;
				bool isRemoved = Remove(value, ref next);
				curent.Left = next;
				return isRemoved;
			}
			if (Compare(value, curent.Data) == 0)
			{
				InnerRemove(value, ref curent);
				return true;
			}
			return false;
		}
		private void InnerRemove(TItem value, ref Node<TItem> curent)
		{
			if (curent.Left == null && curent.Right == null)
				curent = null;

			else if (curent.Left == null)
				curent = curent.Right;

			else if (curent.Right == null)
				curent = curent.Left;

			else
			{
				if (curent.Right.Left == null)
					curent = curent.Right;
				else
				{
					Node<TItem> newRoot = GetLeft(curent.Right);
					Node<TItem> newRightSubTree = curent.Right;
					Remove(newRoot.Data, ref newRightSubTree);
					newRoot.Right = newRightSubTree;
					newRoot.Left = curent.Left;
					curent = newRoot;
				}
			}
		}

		public override Node<TItem> Search(TItem value)
		{
			if (!(value is ValueType))
				if (value == null)
					throw new ArgumentNullException(nameof(value));

			return Search(Root, value);
		}
		private Node<TItem> Search(Node<TItem> node, TItem value)
		{
			if (Compare(value, node.Data) == 0)
				return node;

			if (Compare(value, node.Data) > 0)
				return Search(node.Right, value);
			return Search(node.Left, value);
		}

		public override Node<TItem> GetLeft(Node<TItem> node)
		{
			if (node == null)
				throw new ArgumentNullException(nameof(node));

			if (node.Left != null)
				return GetLeft(node.Left);

			return node;
		}
		public override Node<TItem> GetRight(Node<TItem> node)
		{
			if (node == null)
				throw new ArgumentNullException(nameof(node));

			if (node.Right != null)
				return GetRight(node.Right);

			return node;
		}

		public override IEnumerator<TItem> GetEnumerator()
		{
			return InfixTraverse(Root).GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerable<TItem> InfixTraverse(Node<TItem> node)
		{
			if (node == null)
				yield break;
				
			if (node.Left != null)
				foreach (TItem data in InfixTraverse(node.Left))
					yield return data;

			yield return node.Data;

			if (node.Right != null)
				foreach (TItem data in InfixTraverse(node.Right))
					yield return data;
		}

		public IEnumerable<TItem> GetReversedEnumerator()
		{
			Node<TItem> node = Root;
			Stack<TItem> stack = new Stack<TItem>();

			foreach (var item in this)
				stack.Push(item);

			foreach (var item in stack)
				yield return item;
		}
	}
}
