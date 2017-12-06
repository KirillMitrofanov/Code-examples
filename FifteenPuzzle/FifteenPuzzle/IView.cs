namespace FifteenPuzzle
{
	/// <summary>
	/// Интерфейс показывающий какие члены должен содержать элемент,
	/// посредством которого возможно отображение модели
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Отрисовка модели
		/// </summary>
		void Draw();
	}
}
