using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
	public class IterativeBinarySearchTree<TItem> : 
		AbstractBinarySearchTree<TItem>, 
		IEnumerable<TItem> where TItem: IComparable<TItem>
	{
		public IterativeBinarySearchTree()
		{ }
		public IterativeBinarySearchTree(IEnumerable<TItem> collection) 
			: base(collection) { }
		public IterativeBinarySearchTree(IComparer<TItem> nodeDataComparer) 
			: base(nodeDataComparer) { }
		public IterativeBinarySearchTree(IEnumerable<TItem> collection, IComparer<TItem> nodeDataComparer) 
			: base(collection, nodeDataComparer) { }

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

			Node<TItem> current = Root;
			while (!IsInserted(current, value))
			{
				if (Compare(value, current.Data) < 0)
					current = current.Left;
				else
					current = current.Right;
			}
		}
		private bool IsInserted(Node<TItem> node, TItem value)
		{
			if (Compare(value, node.Data) < 0 && node.Left == null)
			{
				node.Left = new Node<TItem>(value);
				return true;
			}

			if (Compare(value, node.Data) >= 0 && node.Right == null)
			{
				node.Right = new Node<TItem>(value);
				return true;
			}

			return false;
		}

		public override Node<TItem> Search(TItem value)
		{
			if (!(value is ValueType))
				if (value == null)
					throw new ArgumentNullException(nameof(value));

			if (Root == null || Compare(value, Root.Data) == 0)
				return Root;

			Node<TItem> searched = Root;
			while (searched != null)
			{
				if (Compare(value, searched.Data) < 0)
					searched = searched.Left;
				else if ((Compare(value, searched.Data) > 0))
					searched = searched.Right;
				else
					return searched;
			}

			return searched;
		}

		public override bool Remove(TItem value)
		{
			if (!(value is ValueType))
				if (value == null)
					throw new ArgumentNullException(nameof(value));

			if (Root == null)
				return false;

			Node<TItem> node = Root;
			bool isRemoved = Remove(value, ref node);
			Root = node;
			return isRemoved;
		}

		private bool Remove(TItem value, ref Node<TItem> node)
		{
			Node<TItem> curent = node;
			Node<TItem> parent = null;

			while (Compare(value, curent.Data) != 0)
			{
				parent = curent;
				if (Compare(value, curent.Data) < 0)
					curent = curent.Left;
				else
					curent = curent.Right;

				if (curent == null)
					return false;
			}

			if (parent == null)
				DeleteIfParentIsNull(ref node);

			else if (curent.Left == null && curent.Right == null)
				DeleteIfBothChildIsNull(ref parent, ref curent);

			else if (curent.Left == null)
				DeleteIfLeftChildIsNull(ref parent, ref curent);

			else if (curent.Right == null)
				DeleteIfRightChildIsNull(ref parent, ref curent);

			else if (curent.Right.Left == null)
				DeleteIfLeftOfRightChildIsNull(ref parent, ref curent);

			else
				DeleteIfRightChildIsTree(value,ref parent, ref curent);

			return true;
		}
		private void DeleteIfParentIsNull(ref Node<TItem> node)
		{
			if (node.Right == null && node.Left == null)
			{
				node = null;
				return;
			}
			if (node.Right == null)
				node = node.Left;
			else
			{
				Node<TItem> newRoot = GetLeft(node.Right);
				Node<TItem> newRightSubTree = node.Right;
				Remove(newRoot.Data, ref newRightSubTree);
				newRoot.Right = newRightSubTree;
				newRoot.Left = node.Left;
				node = newRoot; 
			}
		}
		private void DeleteIfBothChildIsNull(ref Node<TItem> parent, ref Node<TItem> curent)
		{
			if (curent == parent.Left)
				parent.Left = null;
			else
				parent.Right = null;
		}
		private void DeleteIfLeftChildIsNull(ref Node<TItem> parent, ref Node<TItem> curent)
		{
			if (curent == parent.Left)
				parent.Left = curent.Right;
			else
				parent.Right = curent.Right;
		}
		private void DeleteIfRightChildIsNull(ref Node<TItem> parent, ref Node<TItem> curent)
		{
			if (curent == parent.Left)
				parent.Left = curent.Left;
			else
				parent.Right = curent.Left;
		}
		private void DeleteIfLeftOfRightChildIsNull(ref Node<TItem> parent, ref Node<TItem> curent)
		{
			if (curent == parent.Left)
				parent.Left = curent.Right;
			else
				parent.Right = curent.Right;
		}
		private void DeleteIfRightChildIsTree(TItem value, ref Node<TItem> parent, ref Node<TItem> curent)
		{
			Node<TItem> newRoot = GetLeft(curent.Right);
			Node<TItem> newRightSubTree = curent.Right;
			Remove(newRoot.Data, ref newRightSubTree);
			newRoot.Right = newRightSubTree;
			newRoot.Left = curent.Left;

			if (curent == parent.Left)
				parent.Left = newRoot;
			else
				parent.Right = newRoot;
		}

		public override Node<TItem> GetRight(Node<TItem> node)
		{
			if (node == null)
				throw new ArgumentNullException(nameof(node));

			Node<TItem> theRight = node;
			while (theRight.Right != null)
				theRight = theRight.Right;

			return theRight;
		}
		public override Node<TItem> GetLeft(Node<TItem> node)
		{
			if (node == null)
				throw new ArgumentNullException(nameof(node));

			Node<TItem> theLeft = node;
			while (theLeft.Left != null)
				theLeft = theLeft.Left;

			return theLeft;
		}

		public override IEnumerator<TItem> GetEnumerator()
		{
			return InfixTraverse(Root).GetEnumerator();
		}
		private IEnumerable<TItem> InfixTraverse(Node<TItem> node)
		{
			Stack<Node<TItem>> stack = new Stack<Node<TItem>>();
			while (node != null || !(stack.Count == 0))
			{
				if (!(stack.Count == 0))
				{
					node = stack.Pop();
					yield return node.Data;
					if (node.Right != null)
						node = node.Right;
					else
						node = null;
				}
				while (node != null)
				{
					stack.Push(node);
					node = node.Left;
				}
			}
		}

		public IEnumerable<TItem> GetReversedEnumerator()
		{
			Stack<TItem> stack = new Stack<TItem>();
			foreach (TItem item in this)
				stack.Push(item);

			foreach (TItem item in stack)
				yield return item;
		}
	}
}