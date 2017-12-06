namespace FifteenPuzzleViewWinForms
{
	partial class FormMainMenu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
			this.buttonNewGame = new System.Windows.Forms.Button();
			this.buttonTopScores = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.buttonAbout = new System.Windows.Forms.Button();
			this.labelFifteenPuzzle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonNewGame
			// 
			this.buttonNewGame.BackColor = System.Drawing.Color.White;
			this.buttonNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonNewGame.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonNewGame.Location = new System.Drawing.Point(18, 52);
			this.buttonNewGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonNewGame.Name = "buttonNewGame";
			this.buttonNewGame.Size = new System.Drawing.Size(265, 49);
			this.buttonNewGame.TabIndex = 0;
			this.buttonNewGame.Text = "New game";
			this.buttonNewGame.UseVisualStyleBackColor = false;
			this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
			// 
			// buttonTopScores
			// 
			this.buttonTopScores.BackColor = System.Drawing.Color.White;
			this.buttonTopScores.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonTopScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonTopScores.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonTopScores.Location = new System.Drawing.Point(18, 109);
			this.buttonTopScores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonTopScores.Name = "buttonTopScores";
			this.buttonTopScores.Size = new System.Drawing.Size(265, 49);
			this.buttonTopScores.TabIndex = 1;
			this.buttonTopScores.Text = "Top Scores";
			this.buttonTopScores.UseVisualStyleBackColor = false;
			this.buttonTopScores.Click += new System.EventHandler(this.buttonTopScores_Click);
			// 
			// buttonExit
			// 
			this.buttonExit.BackColor = System.Drawing.Color.White;
			this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonExit.ForeColor = System.Drawing.Color.Red;
			this.buttonExit.Location = new System.Drawing.Point(18, 301);
			this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(265, 49);
			this.buttonExit.TabIndex = 3;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = false;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// buttonAbout
			// 
			this.buttonAbout.BackColor = System.Drawing.Color.White;
			this.buttonAbout.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAbout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAbout.Location = new System.Drawing.Point(18, 166);
			this.buttonAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonAbout.Name = "buttonAbout";
			this.buttonAbout.Size = new System.Drawing.Size(264, 49);
			this.buttonAbout.TabIndex = 2;
			this.buttonAbout.Text = "About";
			this.buttonAbout.UseVisualStyleBackColor = false;
			this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
			// 
			// labelFifteenPuzzle
			// 
			this.labelFifteenPuzzle.AutoSize = true;
			this.labelFifteenPuzzle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFifteenPuzzle.Location = new System.Drawing.Point(14, 12);
			this.labelFifteenPuzzle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFifteenPuzzle.Name = "labelFifteenPuzzle";
			this.labelFifteenPuzzle.Size = new System.Drawing.Size(96, 19);
			this.labelFifteenPuzzle.TabIndex = 4;
			this.labelFifteenPuzzle.Text = "fifteen puzzle";
			// 
			// FormMainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(301, 366);
			this.Controls.Add(this.labelFifteenPuzzle);
			this.Controls.Add(this.buttonAbout);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.buttonTopScores);
			this.Controls.Add(this.buttonNewGame);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMainMenu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainMenu_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonTopScores;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Button buttonAbout;
		private System.Windows.Forms.Button buttonNewGame;
		private System.Windows.Forms.Label labelFifteenPuzzle;
	}
}