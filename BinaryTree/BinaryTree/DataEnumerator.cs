using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
	public class ReversedEnumerator<TItem> : IEnumerator<TItem> where TItem : IComparable<TItem>
	{
		private Stack<TItem> _dataStack;
		private TItem _currentData;
		private IEnumerator<TItem> enumerator;

		public ReversedEnumerator(AbstractBinarySearchTree<TItem> dataCollection)
		{
			_dataStack = new Stack<TItem>();

			foreach (TItem data in dataCollection)
				_dataStack.Push(data);

			enumerator = _dataStack.GetEnumerator();
		}

		public bool MoveNext()
		{
			if (enumerator.MoveNext())
			{
				_currentData = enumerator.Current;
				return true;
			}
 
			return false;
		}

		public void Reset()
		{
			enumerator.Reset();
		}

		public TItem Current
		{
			get { return _currentData; }
		}

		object IEnumerator.Current
		{
			get { return Current; }
		}

		#region IDisposable Support
		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
					_dataStack = null;

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
		#endregion
	}
}
