namespace FifteenPuzzleViewWinForms
{
	partial class FormEndOfGame
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEndOfGame));
			this.buttonMainMenu = new System.Windows.Forms.Button();
			this.errorProviderMain = new System.Windows.Forms.ErrorProvider(this.components);
			this.labelCongratulations = new System.Windows.Forms.Label();
			this.labelResult = new System.Windows.Forms.Label();
			this.labelTypeNickname = new System.Windows.Forms.Label();
			this.maskedTextBoxNickname = new System.Windows.Forms.MaskedTextBox();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderMain)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonMainMenu
			// 
			this.buttonMainMenu.DialogResult = System.Windows.Forms.DialogResult.Retry;
			this.buttonMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMainMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMainMenu.Location = new System.Drawing.Point(90, 131);
			this.buttonMainMenu.Name = "buttonMainMenu";
			this.buttonMainMenu.Size = new System.Drawing.Size(165, 25);
			this.buttonMainMenu.TabIndex = 1;
			this.buttonMainMenu.Text = "OK";
			this.buttonMainMenu.UseVisualStyleBackColor = true;
			this.buttonMainMenu.Click += new System.EventHandler(this.buttonMainMenu_Click);
			// 
			// errorProviderMain
			// 
			this.errorProviderMain.BlinkRate = 100;
			this.errorProviderMain.ContainerControl = this;
			// 
			// labelCongratulations
			// 
			this.labelCongratulations.AutoSize = true;
			this.labelCongratulations.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCongratulations.Location = new System.Drawing.Point(110, 18);
			this.labelCongratulations.Name = "labelCongratulations";
			this.labelCongratulations.Size = new System.Drawing.Size(120, 19);
			this.labelCongratulations.TabIndex = 2;
			this.labelCongratulations.Text = "Congratulations!";
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelResult.Location = new System.Drawing.Point(75, 44);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(145, 19);
			this.labelResult.TabIndex = 3;
			this.labelResult.Text = "You won! Your score \r\n";
			// 
			// labelTypeNickname
			// 
			this.labelTypeNickname.AutoSize = true;
			this.labelTypeNickname.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTypeNickname.Location = new System.Drawing.Point(94, 70);
			this.labelTypeNickname.Name = "labelTypeNickname";
			this.labelTypeNickname.Size = new System.Drawing.Size(149, 19);
			this.labelTypeNickname.TabIndex = 4;
			this.labelTypeNickname.Text = "Type your nickname!";
			// 
			// maskedTextBoxNickname
			// 
			this.maskedTextBoxNickname.Culture = new System.Globalization.CultureInfo("en-US");
			this.maskedTextBoxNickname.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.maskedTextBoxNickname.Location = new System.Drawing.Point(90, 100);
			this.maskedTextBoxNickname.Mask = "AAAAAAAAAA";
			this.maskedTextBoxNickname.Name = "maskedTextBoxNickname";
			this.maskedTextBoxNickname.Size = new System.Drawing.Size(165, 26);
			this.maskedTextBoxNickname.TabIndex = 5;
			this.maskedTextBoxNickname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// FormEndOfGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(341, 168);
			this.Controls.Add(this.maskedTextBoxNickname);
			this.Controls.Add(this.labelTypeNickname);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.labelCongratulations);
			this.Controls.Add(this.buttonMainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEndOfGame";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.errorProviderMain)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonMainMenu;
		private System.Windows.Forms.ErrorProvider errorProviderMain;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.Label labelCongratulations;
		private System.Windows.Forms.Label labelTypeNickname;
		private System.Windows.Forms.MaskedTextBox maskedTextBoxNickname;
	}
}