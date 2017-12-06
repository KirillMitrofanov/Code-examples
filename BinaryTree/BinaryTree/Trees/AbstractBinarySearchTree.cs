using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
	public abstract class AbstractBinarySearchTree<TItem> :  
		IEnumerable<TItem> where TItem: IComparable<TItem>
	{
		private readonly IComparer<TItem> _nodeDataComparer;
		protected IComparer<TItem> NodeDataComparer { get { return _nodeDataComparer; } }
		public Node<TItem> Root { get; set; }

		public AbstractBinarySearchTree()
		{
		}

		public AbstractBinarySearchTree(IEnumerable<TItem> collection)
		{
			if (collection == null)
				throw new ArgumentNullException(nameof(collection));

			foreach (TItem item in collection)
				Add(item);
		}

		public AbstractBinarySearchTree(IComparer<TItem> nodeDataComparer)
		{
			if (nodeDataComparer == null)
				throw new ArgumentNullException(nameof(nodeDataComparer));

			_nodeDataComparer = nodeDataComparer;
		}

		public AbstractBinarySearchTree(IEnumerable<TItem> collection, IComparer<TItem> nodeDataComparer)
		{
			if (collection == null)
				throw new ArgumentNullException(nameof(collection));

			if (nodeDataComparer == null)
				throw new ArgumentNullException(nameof(nodeDataComparer));

			_nodeDataComparer = nodeDataComparer;

			foreach (TItem item in collection)
				Add(item);
		}

		public abstract void Add(TItem value);
		public abstract bool Remove(TItem value);
		public abstract Node<TItem> Search(TItem value);

		public int Compare(TItem first, TItem second)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));

			if (second == null)
				throw new ArgumentNullException(nameof(second));

			if (NodeDataComparer != null)
				return NodeDataComparer.Compare(first, second);
			return first.CompareTo(second);
		}

		public abstract Node<TItem> GetRight(Node<TItem> node);

		public Node<TItem> GetRight()
		{
			return GetRight(Root);
		}
		public abstract Node<TItem> GetLeft(Node<TItem> node);

		public Node<TItem> GetLeft()
		{
			return GetLeft(Root);
		}
		
		public Node<TItem> GetMax(Node<TItem> node)
		{
			if (node == null)
				throw new ArgumentNullException(nameof(node));

			if (NodeDataComparer is DataComparer<TItem>)
			{
				if (((DataComparer<TItem>)NodeDataComparer).Order == OrderType.Direct)
					return GetRight(node);
				return GetLeft(node);
			}

			return GetRight(node);
		}

		public Node<TItem> GetMin(Node<TItem> node)
		{
			if (node == null)
				throw new ArgumentNullException(nameof(node));

			if (NodeDataComparer is DataComparer<TItem>)
			{
				if (((DataComparer<TItem>)NodeDataComparer).Order == OrderType.Direct)
					return GetLeft(node);
				return GetRight(node);
			}

			return GetLeft(node);
		}

		public abstract IEnumerator<TItem> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
