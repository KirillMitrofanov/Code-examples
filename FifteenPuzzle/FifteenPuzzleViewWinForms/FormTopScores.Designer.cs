namespace FifteenPuzzleViewWinForms
{
	partial class FormTopScores
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTopScores));
			this.labelScoresEmpty = new System.Windows.Forms.Label();
			this.buttonMenu = new System.Windows.Forms.Button();
			this.listBoxScores = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// labelScoresEmpty
			// 
			this.labelScoresEmpty.AutoSize = true;
			this.labelScoresEmpty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScoresEmpty.Location = new System.Drawing.Point(38, 286);
			this.labelScoresEmpty.Name = "labelScoresEmpty";
			this.labelScoresEmpty.Size = new System.Drawing.Size(202, 19);
			this.labelScoresEmpty.TabIndex = 1;
			this.labelScoresEmpty.Text = "Score table is empty for now!";
			// 
			// buttonMenu
			// 
			this.buttonMenu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonMenu.DialogResult = System.Windows.Forms.DialogResult.Retry;
			this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMenu.Location = new System.Drawing.Point(31, 308);
			this.buttonMenu.Name = "buttonMenu";
			this.buttonMenu.Size = new System.Drawing.Size(215, 37);
			this.buttonMenu.TabIndex = 2;
			this.buttonMenu.Text = "Menu";
			this.buttonMenu.UseVisualStyleBackColor = true;
			// 
			// listBoxScores
			// 
			this.listBoxScores.FormattingEnabled = true;
			this.listBoxScores.Location = new System.Drawing.Point(0, 0);
			this.listBoxScores.Name = "listBoxScores";
			this.listBoxScores.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.listBoxScores.Size = new System.Drawing.Size(273, 277);
			this.listBoxScores.TabIndex = 0;
			// 
			// FormTopScores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(273, 352);
			this.Controls.Add(this.listBoxScores);
			this.Controls.Add(this.buttonMenu);
			this.Controls.Add(this.labelScoresEmpty);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormTopScores";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Top scores";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTopScores_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelScoresEmpty;
		private System.Windows.Forms.Button buttonMenu;
		private System.Windows.Forms.ListBox listBoxScores;
	}
}