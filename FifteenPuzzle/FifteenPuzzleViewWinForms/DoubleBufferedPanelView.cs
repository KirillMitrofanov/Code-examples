using System.Drawing;
using System.Windows.Forms;
using FifteenPuzzle;

namespace FifteenPuzzleViewWinForms
{
	/// <summary>
	/// Пользовательский компонент
	/// создан для использования двойной буфферизации
	/// является представлением для данной модели
	/// </summary>
	public class DoubleBufferedPanelView : Panel, IView
	{
		/// <summary>
		/// Ширина ручки линий
		/// </summary>
		private const int LINES_PEN_WIDTH = 1;
		/// <summary>
		/// Кол-во линий в сетке поля (по вертикали 5 и по горизонтали 5)
		/// </summary>
		private const int COUNT_OF_LINES = 5;
		/// <summary>
		/// Смещение для отрисовки
		/// </summary>
		private const int SHIFT = 100;
		/// <summary>
		/// Начальное смещение для цифр
		/// </summary>
		private const int INITIAL_NUMBER_SHIFT = 35;
		/// <summary>
		/// Переменная представляющая поверхность для рисования
		/// </summary>
		private Graphics _graphics;
		/// <summary>
		/// 
		/// </summary>
		private readonly MainController _controller; 

		/// <summary>
		/// Кол-во элементов в линии
		/// </summary>
		private int COUNT_OF_ELEMENTS_IN_LINE = 4;

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public DoubleBufferedPanelView(MainController parController)
		{
			DoubleBuffered = true;
			_controller = parController;
			Paint += DoubleBufferedPanelView_Paint;
		}

		/// <summary>
		/// В данном случае само рисование происходит по срабатыванию события Pain
		/// во избежании переопределения метода OnPaint используется метод Refresh()
		/// для вызова события Paint и дальнейшей перерисовки
		/// </summary>
		public void Draw()
		{
			Refresh();
		}

		private void DoubleBufferedPanelView_Paint(object sender, PaintEventArgs e)
		{
			_graphics = e.Graphics;
			DrawGrid();
			DrawNumbers();
		}


		

		/// <summary>
		/// Рисовать сетку
		/// </summary>
		private void DrawGrid()
		{
			Pen linePen = new Pen(Color.Black, LINES_PEN_WIDTH);
			DrawHorizontalLines(linePen);
			DrawVerticalLines(linePen);
		}

		/// <summary>
		/// Рисовать горизонтальные линии
		/// </summary>
		/// <param name="parLinePen"></param>
		private void DrawHorizontalLines(Pen parLinePen)
		{
			Point beginOfLine = new Point(0, 0);
			Point endOfLine = new Point(Width, 0);
			for (int i = 0; i < 5; i++)
			{
				_graphics.DrawLine(parLinePen, beginOfLine, endOfLine);
				beginOfLine.Y += SHIFT;
				endOfLine.Y += SHIFT;
			}
		}

		/// <summary>
		/// Рисовать вертикальные линии
		/// </summary>
		/// <param name="parLinePen"></param>
		private void DrawVerticalLines(Pen parLinePen)
		{
			Point beginOfLine = new Point(0, 0);
			Point endOfLine = new Point(0, Height);
			for (int i = 0; i < COUNT_OF_LINES; i++)
			{
				_graphics.DrawLine(parLinePen, beginOfLine, endOfLine);
				beginOfLine.X += SHIFT;
				endOfLine.X += SHIFT;
			}
		}

		/// <summary>
		/// Рисовать числа в сетке
		/// </summary>
		private void DrawNumbers()
		{
			Font numberFont = new Font(new FontFamily("Times new roman"), 20, FontStyle.Italic);
			Point numberLocation = new Point(INITIAL_NUMBER_SHIFT, INITIAL_NUMBER_SHIFT);
			Brush numberBrush = Brushes.Black;
			int countInLine = 0;
			foreach (int number in _controller.Field)
			{
				SetBrushColorFor(number, ref numberBrush);
				_graphics.DrawString(number.ToString(), numberFont, numberBrush, numberLocation);
				countInLine++;
				numberLocation.X += SHIFT;
				if ((countInLine % COUNT_OF_ELEMENTS_IN_LINE) == 0)
				{
					numberLocation.Y += SHIFT;
					numberLocation.X = INITIAL_NUMBER_SHIFT;
				}
			}
		}

		/// <summary>
		/// Установить цвет кисти в зависимости от выводимой цифры
		/// </summary>
		/// <param name="parNumber"></param>
		/// <param name="parNumbeBrush"></param>
		private void SetBrushColorFor(int parNumber, ref Brush parNumbeBrush)
		{
			if (parNumber == 0)
				parNumbeBrush = Brushes.White;

			else
				parNumbeBrush = Brushes.Black;
		}
	}
}


