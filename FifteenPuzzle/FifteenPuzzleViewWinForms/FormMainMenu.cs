using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FifteenPuzzle;

namespace FifteenPuzzleViewWinForms
{
	/// <summary>
	/// Часть класса формы необходимой для реализации меню
	/// </summary>
	public partial class FormMainMenu : Form
	{
		/// <summary>
		/// Переменная формы игры
		/// </summary>
		private FormGame _formGame;
		/// <summary>
		/// Переменная - контроллер
		/// </summary>
		private MainController _controller;

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public FormMainMenu()
		{
			InitializeComponent();
			_controller = new MainController();
			
			_formGame = new FormGame(this, _controller);
			_formGame.GamePaused += _formGame_GamePaused;
		}

		private void _formGame_GamePaused(object sender, EventArgs e)
		{
			buttonNewGame.Text = "Continue";
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void buttonAbout_Click(object sender, EventArgs e)
		{
			ShowAbout();
		}

		/// <summary>
		/// Показать информацию о приложении
		/// </summary>
		private void ShowAbout()
		{
			MessageBox.Show("Fifteen puzzle classic\nby K. Mitrofanov", 
				"version 1.0.0", 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information);
		}

		private void buttonNewGame_Click(object sender, EventArgs e)
		{
			ContinueGame();
		}

		/// <summary>
		/// Продолжить игру из главного меню
		/// </summary>
		private void ContinueGame()
		{
			_formGame.Show();
			Hide();
		}

		private void buttonTopScores_Click(object sender, EventArgs e)
		{
			ShowTopScores();
		}

		/// <summary>
		/// Отобразить таблицу рекордов
		/// </summary>
		private void ShowTopScores()
		{
			FormTopScores formTopScores = new FormTopScores(_controller);
			formTopScores.ShowDialog();
		}

		private void FormMainMenu_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
