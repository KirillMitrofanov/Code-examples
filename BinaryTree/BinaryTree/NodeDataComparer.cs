using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
	public class DataComparer<TData> : IComparer<TData> where TData: IComparable<TData>
	{
		private readonly OrderType _order;
		private readonly IComparer<TData> _comparer;
		private readonly Func<TData, TData, int> _funcComparer;
		private readonly Comparison<TData> _comparisonComparer;

		public OrderType Order { get { return _order; } }
		public IComparer<TData> Comparer { get { return _comparer; } }
		public Func<TData, TData, int> FuncComparer { get { return _funcComparer; } }
		public Comparison<TData> ComprasionComparer { get { return _comparisonComparer; } }

		public DataComparer(OrderType order)
		{
			_order = order;
		}
		public DataComparer(IComparer<TData> comparer, OrderType order)
		{
			_comparer = comparer;
			_order = order;
		}
		public DataComparer(Func<TData, TData, int> funcComparer, OrderType order)
		{
			_funcComparer = funcComparer;
			_order = order;
		}
		public DataComparer(Comparison<TData> comparisonComparer, OrderType order)
		{
			_comparisonComparer = comparisonComparer;
			_order = order;
		}

		public int Compare(TData x, TData y)
		{
			if (_comparer != null)
				return _comparer.Compare(x, y);
			if (_comparisonComparer != null)
				return _comparisonComparer(x, y);
			if (_funcComparer != null)
				return _funcComparer(x, y);

			if (_order == OrderType.Inverse)
			{
				if (y.CompareTo(x) == 0)
					return -1;
				return y.CompareTo(x);
			}

			return x.CompareTo(y);
		}
	}
}
