using System;
using System.ComponentModel;
using System.Windows.Forms;
using FifteenPuzzle;

namespace FifteenPuzzleViewWinForms
{
	/// <summary>
	/// Часть класса формы, отображающийся в конце игры, в случае,
	/// если пользователь набрал достаточное кол-во очков 
	/// для попадания в таблицу рекордов
	/// </summary>
	public partial class FormEndOfGame : Form
	{
		/// <summary>
		/// Переменная - контроллер
		/// </summary>
		private MainController _controller;

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public FormEndOfGame(MainController parController)
		{
			InitializeComponent();
			_controller = parController;
			SetResultLable();
		}

		/// <summary>
		/// Установить текст сообщения отображающего результат игры
		/// </summary>
		private void SetResultLable()
		{
			labelResult.Text = $"You won! Your score {_controller.Steps}";
		}

		private void textBoxNickname_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(maskedTextBoxNickname.Text))
			{
				e.Cancel = true;
				errorProviderMain.SetError(maskedTextBoxNickname, "Nickanme cann't be whitespace!");
			}
			else
			{
				errorProviderMain.Clear();
			}
		}

		private void buttonMainMenu_Click(object sender, EventArgs e)
		{
			_controller.FormTopScoresWith(maskedTextBoxNickname.Text.Trim());
			ScoresSerializer.SerializeScoresTo(_controller.TopScores, "TopScores.bin");
		}

	}
}
