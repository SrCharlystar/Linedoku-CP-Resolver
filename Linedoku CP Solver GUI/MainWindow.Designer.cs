namespace Linedoku_CP_Solver_GUI {
	partial class MainWindow {
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent() {
			this.boardXComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.boardYComboBox = new System.Windows.Forms.ComboBox();
			this.buttonSetBoard = new System.Windows.Forms.Button();
			this.boardDimensionsGroupBox = new System.Windows.Forms.GroupBox();
			this.MainGroupBox = new System.Windows.Forms.GroupBox();
			this.MovesLabel = new System.Windows.Forms.Label();
			this.MovesNumericUpdown = new System.Windows.Forms.NumericUpDown();
			this.statusLabel = new System.Windows.Forms.Label();
			this.RunButton = new System.Windows.Forms.Button();
			this.MainBoard = new System.Windows.Forms.TableLayoutPanel();
			this.boardDimensionsGroupBox.SuspendLayout();
			this.MainGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MovesNumericUpdown)).BeginInit();
			this.SuspendLayout();
			// 
			// boardXComboBox
			// 
			this.boardXComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.boardXComboBox.FormattingEnabled = true;
			this.boardXComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
			this.boardXComboBox.Location = new System.Drawing.Point(6, 28);
			this.boardXComboBox.MaxDropDownItems = 10;
			this.boardXComboBox.Name = "boardXComboBox";
			this.boardXComboBox.Size = new System.Drawing.Size(50, 21);
			this.boardXComboBox.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(62, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "x";
			// 
			// boardYComboBox
			// 
			this.boardYComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.boardYComboBox.FormattingEnabled = true;
			this.boardYComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
			this.boardYComboBox.Location = new System.Drawing.Point(80, 28);
			this.boardYComboBox.Name = "boardYComboBox";
			this.boardYComboBox.Size = new System.Drawing.Size(50, 21);
			this.boardYComboBox.TabIndex = 4;
			// 
			// buttonSetBoard
			// 
			this.buttonSetBoard.Location = new System.Drawing.Point(136, 26);
			this.buttonSetBoard.Name = "buttonSetBoard";
			this.buttonSetBoard.Size = new System.Drawing.Size(75, 23);
			this.buttonSetBoard.TabIndex = 5;
			this.buttonSetBoard.Text = "Set board";
			this.buttonSetBoard.UseVisualStyleBackColor = true;
			this.buttonSetBoard.Click += new System.EventHandler(this.UpdateBoardButtonClick);
			// 
			// boardDimensionsGroupBox
			// 
			this.boardDimensionsGroupBox.Controls.Add(this.boardXComboBox);
			this.boardDimensionsGroupBox.Controls.Add(this.buttonSetBoard);
			this.boardDimensionsGroupBox.Controls.Add(this.label2);
			this.boardDimensionsGroupBox.Controls.Add(this.boardYComboBox);
			this.boardDimensionsGroupBox.Location = new System.Drawing.Point(355, 12);
			this.boardDimensionsGroupBox.Name = "boardDimensionsGroupBox";
			this.boardDimensionsGroupBox.Size = new System.Drawing.Size(217, 67);
			this.boardDimensionsGroupBox.TabIndex = 6;
			this.boardDimensionsGroupBox.TabStop = false;
			this.boardDimensionsGroupBox.Text = "Board Dimensions";
			// 
			// MainGroupBox
			// 
			this.MainGroupBox.Controls.Add(this.MovesLabel);
			this.MainGroupBox.Controls.Add(this.MovesNumericUpdown);
			this.MainGroupBox.Controls.Add(this.statusLabel);
			this.MainGroupBox.Controls.Add(this.RunButton);
			this.MainGroupBox.Location = new System.Drawing.Point(355, 85);
			this.MainGroupBox.Name = "MainGroupBox";
			this.MainGroupBox.Size = new System.Drawing.Size(217, 105);
			this.MainGroupBox.TabIndex = 7;
			this.MainGroupBox.TabStop = false;
			this.MainGroupBox.Text = "Options";
			// 
			// MovesLabel
			// 
			this.MovesLabel.AutoSize = true;
			this.MovesLabel.Enabled = false;
			this.MovesLabel.Location = new System.Drawing.Point(15, 30);
			this.MovesLabel.Name = "MovesLabel";
			this.MovesLabel.Size = new System.Drawing.Size(87, 13);
			this.MovesLabel.TabIndex = 6;
			this.MovesLabel.Text = "Available moves:";
			// 
			// MovesNumericUpdown
			// 
			this.MovesNumericUpdown.Enabled = false;
			this.MovesNumericUpdown.Location = new System.Drawing.Point(123, 28);
			this.MovesNumericUpdown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.MovesNumericUpdown.Name = "MovesNumericUpdown";
			this.MovesNumericUpdown.Size = new System.Drawing.Size(86, 20);
			this.MovesNumericUpdown.TabIndex = 5;
			this.MovesNumericUpdown.ValueChanged += new System.EventHandler(this.MovesNumericUpdown_ValueChanged);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(136, 75);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 13);
			this.statusLabel.TabIndex = 1;
			// 
			// RunButton
			// 
			this.RunButton.Enabled = false;
			this.RunButton.Location = new System.Drawing.Point(6, 70);
			this.RunButton.Name = "RunButton";
			this.RunButton.Size = new System.Drawing.Size(124, 23);
			this.RunButton.TabIndex = 0;
			this.RunButton.Text = "Run algorithm";
			this.RunButton.UseVisualStyleBackColor = true;
			this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
			// 
			// MainBoard
			// 
			this.MainBoard.ColumnCount = 3;
			this.MainBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.MainBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.MainBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.MainBoard.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
			this.MainBoard.Location = new System.Drawing.Point(12, 12);
			this.MainBoard.MaximumSize = new System.Drawing.Size(337, 337);
			this.MainBoard.Name = "MainBoard";
			this.MainBoard.RowCount = 3;
			this.MainBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.MainBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.MainBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.MainBoard.Size = new System.Drawing.Size(337, 337);
			this.MainBoard.TabIndex = 8;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.MainBoard);
			this.Controls.Add(this.MainGroupBox);
			this.Controls.Add(this.boardDimensionsGroupBox);
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "MainWindow";
			this.Text = "Linedoku CP Solver";
			this.boardDimensionsGroupBox.ResumeLayout(false);
			this.boardDimensionsGroupBox.PerformLayout();
			this.MainGroupBox.ResumeLayout(false);
			this.MainGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MovesNumericUpdown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ComboBox boardXComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox boardYComboBox;
		private System.Windows.Forms.Button buttonSetBoard;
		private System.Windows.Forms.GroupBox boardDimensionsGroupBox;
		private System.Windows.Forms.GroupBox MainGroupBox;
		private System.Windows.Forms.Button RunButton;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.TableLayoutPanel MainBoard;
		private System.Windows.Forms.Label MovesLabel;
		private System.Windows.Forms.NumericUpDown MovesNumericUpdown;
	}
}

