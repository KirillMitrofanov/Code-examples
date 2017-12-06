namespace BinarySearchTree
{
	public class Node<TData>
	{
		private readonly TData _data;

		public TData Data { get { return _data; } }
		public Node<TData> Left  { get; set; }
		public Node<TData> Right { get; set; }

		public Node (TData data)
		{
			_data = data;
		}
	}
}
