using Linedoku_CP_Solver;
using Linedoku_CP_Solver.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Linedoku_CP_Solver_GUI {
	public partial class MainWindow : Form {

		private Label selectedLabel;

		public MainWindow() {
			InitializeComponent();
			boardXComboBox.SelectedIndex = 0;
			boardYComboBox.SelectedIndex = 0;
		}

		/// <summary>
		/// Fired on "Set board" button
		/// </summary>
		private void UpdateBoardButtonClick(object sender, EventArgs e) {
			int x = Int32.Parse((string)boardXComboBox.SelectedItem);
			int y = Int32.Parse((string)boardYComboBox.SelectedItem);
			setBoard(x, y);
			RunButton.Enabled = true;
		}

		/// <summary>
		/// Set / Update board
		/// </summary>
		/// <param name="x">Width</param>
		/// <param name="y">Height</param>
		private void setBoard(int x, int y) {
			MainBoard.Controls.Clear();
			MainBoard.ColumnStyles.Clear();
			MainBoard.RowStyles.Clear();
			MainBoard.RowCount = x;
			MainBoard.ColumnCount = y;
			for (int i = 0; i < x; i++) {
				MainBoard.RowStyles.Add(new RowStyle(SizeType.Absolute, (MainBoard.Size.Width / x)));
				for (int j = 0; j < y; j++) {
					MainBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, (MainBoard.Size.Height / y)));
					Label l = createLabel(i, j);
					MainBoard.Controls.Add(l, i, j);
				}
			}
		}

		/// <summary>
		/// Generate a label with correct parameters for the given board coordinates
		/// </summary>
		/// <param name="i">X Coordinate</param>
		/// <param name="j">Y coordinate</param>
		/// <returns>Desired label</returns>
		private Label createLabel(int i, int j) {
			Label l = new Label(); //Label creating
			l.Height = l.Width; //Make it a square
			l.Text = "F"; //Text to show
			l.BackColor = Color.Green;
			l.Click += L_Click;
			l.TextAlign = ContentAlignment.MiddleCenter;
			l.Tag = new BlockData(PieceTypes.Fillable, i, j);
			return l;
		}

		private void L_Click(object sender, EventArgs e) {
			changeBlockType((Label)sender);
		}

		/// <summary>
		/// Set moves to this piece
		/// </summary>
		/// <param name="label">Label containing block info</param>
		/// <param name="v">Moves to set</param>
		private void addMoves(Label label, int v) {
			((BlockData)label.Tag).TotalMoves = v;
			label.Text = "G (" + ((BlockData)label.Tag).TotalMoves + ")";
		}

		/// <summary>
		/// Given a label, change its tag and text
		/// </summary>
		/// <param name="lbl">Label to edit</param>
		private void changeBlockType(Label lbl) {
			MovesLabel.Enabled = false;
			MovesNumericUpdown.Enabled = false;
			switch (((BlockData)lbl.Tag).Type) {
				case PieceTypes.Fillable:
					((BlockData)lbl.Tag).Type = PieceTypes.Generator;
					((BlockData)lbl.Tag).TotalMoves = 0;
					MovesLabel.Enabled = true;
					MovesNumericUpdown.Enabled = true;
					selectedLabel = lbl;
					lbl.Text = "G (0)";
					lbl.BackColor = Color.Aqua;
					break;
				case PieceTypes.Generator:
					((BlockData)lbl.Tag).Type = PieceTypes.SolidBlock;
					lbl.Text = "B";
					lbl.BackColor = Color.DarkCyan;
					break;
				case PieceTypes.SolidBlock:
					((BlockData)lbl.Tag).Type = PieceTypes.Fillable;
					lbl.Text = "F";
					lbl.BackColor = Color.Green;
					break;
			}
		}

		/// <summary>
		/// Run algorithm
		/// </summary>
		private void RunButton_Click(object sender, EventArgs e) {
			//Convert WinForms to Piece[,]
			Piece[,] lab = new Piece[MainBoard.RowCount, MainBoard.ColumnCount];
			for (int i = 0; i < MainBoard.RowCount; i++) {
				for (int j = 0; j < MainBoard.ColumnCount; j++) {
					Label l = (Label)MainBoard.GetControlFromPosition(j, i);
					BlockData bd = (BlockData)l.Tag;
					lab[i, j] = bd.generatePiece();
				}
			}
			//Set and run
			Solver sol = new Solver(lab);
			sol.Solve();
			statusLabel.Text = "Running...";
			//Show
			MessageBox.Show(sol.ToString());
			statusLabel.Text = "Done";
		}

		private void MovesNumericUpdown_ValueChanged(object sender, EventArgs e) {
			addMoves(selectedLabel, (int)((NumericUpDown)sender).Value);
		}


	}
}