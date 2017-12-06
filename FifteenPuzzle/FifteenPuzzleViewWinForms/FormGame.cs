using System;
using System.Drawing;
using System.Windows.Forms;
using FifteenPuzzle;

namespace FifteenPuzzleViewWinForms
{
	/// <summary>
	/// Часть класса формы необходимой для работы с игровым полем
	/// </summary>
	public partial class FormGame : Form
	{
		/// <summary>
		/// Экземпляр представления для данного приложения
		/// </summary>
		private DoubleBufferedPanelView _panelView;
		/// <summary>
		/// Экземпляр формы главного меню, 
		/// необходим для реализации паузы
		/// </summary>
		private FormMainMenu _formMainMenu;
		/// <summary>
		/// 
		/// </summary>
		private MainController _controller; 
		/// <summary>
		/// Событие вызываемое переходом в меню во время игры
		/// </summary>
		public event EventHandler GamePaused;

		/// <summary>
		/// Конструктор формы по умолчанию
		/// </summary>
		public FormGame(FormMainMenu parFormMainMenu, MainController parController)
		{
			InitializeComponent();
			_controller = parController;
			AddDoubleBufferedPanelView();
			_controller.AddView(_panelView);
			_formMainMenu = parFormMainMenu;
		}

		/// <summary>
		/// Добавить DoubleBufferedPanel на форму
		/// </summary>
		private void AddDoubleBufferedPanelView()
		{
			_panelView = new DoubleBufferedPanelView(_controller);

			_panelView.Location = new System.Drawing.Point(5, 34);
			_panelView.Name = "_panelView";
			_panelView.Size = new System.Drawing.Size(401, 401);
			_panelView.TabIndex = 2;
			_panelView.BackColor = Color.White;

			_panelView.MouseClick += PanelGameField_MouseClick;

			Controls.Add(_panelView);
		}

		private void PanelGameField_MouseClick(object sender, MouseEventArgs e)
		{
			int j = e.X / 100;
			int i = e.Y / 100;

			if(_controller.TryMove(j, i))
			{
				_panelView.Draw();
				labelSteps.Text = $"Steps: {_controller.Steps}";
			}

			if (_controller.IsInitialState())
				DisplayGameResults(); 
		}

		/// <summary>
		/// Отобразить результаты игры
		/// </summary>
		private void DisplayGameResults()
		{
			if (_controller.IsScoreInTop())
				RegisterScore();
			else
				MessageBox.Show("","", 
					MessageBoxButtons.OK, 
					MessageBoxIcon.Information);
		}

		/// <summary>
		/// Отобразить результаты игры
		/// </summary>
		private void RegisterScore()
		{
			FormEndOfGame formEndOfgame = new FormEndOfGame(_controller);
			if (formEndOfgame.ShowDialog() == DialogResult.Retry)
				_controller.StartNewGame();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
					== DialogResult.Yes)
				Application.Exit();
		}

		private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_controller.StartNewGame();
			labelSteps.Text = $"Steps: {_controller.Steps.ToString()}";
			_panelView.Draw();
		}

		private void menuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenMainMenu();
		}

		/// <summary>
		/// Отобразить главное меню во время игры
		/// </summary>
		private void OpenMainMenu()
		{
			Hide();
			_formMainMenu.Show();
			GamePaused?.Invoke(this, new EventArgs());
		}
	}
}
