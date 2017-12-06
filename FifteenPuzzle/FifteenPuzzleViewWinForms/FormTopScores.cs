using System.Windows.Forms;
using FifteenPuzzle;

namespace FifteenPuzzleViewWinForms
{
	/// <summary>
	/// Часть класс формы необходимой для отображения спика рекордов
	/// </summary>
	public partial class FormTopScores : Form
	{
		/// <summary>
		/// Переменная - контроллер
		/// </summary>
		private MainController _controller;
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		/// <param name="parTopScores"></param>
		public FormTopScores(MainController parController)
		{
			InitializeComponent();
			_controller = parController;
			AddScoresToListBox();
			SetComponentsVisibility();
		}
		/// <summary>
		/// Добавить рекорды в лист бокс
		/// </summary>
		private void AddScoresToListBox()
		{
			foreach (var score in _controller.TopScores)
				listBoxScores.Items.Add(score);
		}
		/// <summary>
		/// Установить видимоть компонентов формы
		/// в зависимости от наличия рекордов
		/// </summary>
		private void SetComponentsVisibility()
		{
			if (listBoxScores.Items.Count == 0)
			{
				labelScoresEmpty.Visible = true;
				listBoxScores.Visible = false;
			}
			else
			{
				labelScoresEmpty.Visible = false;
			}
		}

		private void FormTopScores_FormClosed(object sender, FormClosedEventArgs e)
		{
			DialogResult = DialogResult.Retry;
		}
	}
}
