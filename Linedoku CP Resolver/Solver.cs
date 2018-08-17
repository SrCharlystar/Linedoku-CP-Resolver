using Linedoku_CP_Solver.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linedoku_CP_Solver {
	/// <summary>
	/// Resolver class. Used in order to create and solve Linedoku maze.
	/// 
	/// Created by SrCharlystar, 2018
	/// https://github.com/SrCharlystar/
	/// </summary>
	public class Solver {
		/// <summary>
		/// Labyrinth matrix. This will contain the main labyrinth to be resolved.
		/// </summary>
		private Piece[,] lab;

		/// <summary>
		/// This attribute will be true only if a valid solution has already been found.
		/// </summary>
		private Boolean solutionFound = false;

		/// <summary>
		/// Where valid path will be stored
		/// </summary>
		public Piece[,] solution { get; private set; }
		
		/// <summary>
		/// Constructor for Labyrinth class.
		/// </summary>
		public Solver(Piece[,] maze) {
			if (maze == null)
				throw new Exception("Please provide a valid labyrinth.");
			lab = maze;
			for (int i = 0; i < lab.GetLength(0); i++) {
				for (int j = 0; j < lab.GetLength(1); j++) {
					if (lab[i, j] == null) {
						throw new Exception("Maze is not fully set. Check coordinates (" + i + ", " + j + ")");
					}
				}
			}
		}

		/// <summary>
		/// Public method used to run algorithm
		/// </summary>
		public void Solve(Piece[,] maze) {
			run();
		}

		/// <summary>
		/// Run algorithm
		/// </summary>
		private void run() {
			if (solutionFound)
				return;
			if (validSolutionFound()) {
				solutionFound = true;
				return;
			}
			//Execute algorithm
			var generadores = getAllGenerators();
			for (int i = 0; i < lab.GetLength(0); i++) {
				for (int j = 0; j < lab.GetLength(1); j++) {
					if (lab[i, j].Type == PieceTypes.Fillable && ((Piece_Fillable)lab[i, j]).Parent == null) {
						var pieza = (Piece_Fillable)lab[i, j];
						for (int k = 0; k<generadores.Length; k++) { //Para cada generador si esta libre y está en su misma fila o columna
							if (generadores[k].AvailableMoves > 0 && (generadores[k].X == i || generadores[k].Y == j)) {
								pieza.Parent = generadores[k];
								generadores[k].AvailableMoves--;
								run();
								if (solutionFound)
									return;
								generadores[k].AvailableMoves++;
								pieza.Parent = null;
							}
						}
					}
				}
			}

		}

		/// <summary>
		/// Check if given (x, y) coordinates are contained into actual maze.
		/// </summary>
		/// <param name="i2">X position</param>
		/// <param name="j2">Y position</param>
		/// <returns>True in case (x, y) coordinates contained into matrix limits, otherwise false</returns>
		private bool isPositionLegal(int i2, int j2) {
			if (i2 >= 0 && j2 >= 0 && i2 < lab.GetLength(0) && j2 < lab.GetLength(1))
				return true;
			return false;
		}
		
		/// <summary>
		/// Search and return all generators
		/// </summary>
		/// <returns>All generators within lab</returns>
		private Piece_Generator[] getAllGenerators() {
			IList<Piece_Generator> temp = new List<Piece_Generator>();
			for (int i = 0; i < lab.GetLength(0); i++) {
				for (int j = 0; j < lab.GetLength(1); j++) {
					if (lab[i, j].Type == PieceTypes.Generator) {
						temp.Add((Piece_Generator)lab[i, j]);
					}
				}
			}
			return temp.ToArray();
		}

		/// <summary>
		/// Check if actual maze state is a valid solution
		/// This will get all generators within maze. Then will move upward, downward, to the left and to the right, counting
		/// how many moves generator has done. If total moves do not match with the generator available moves, then it means this is not a
		/// valid solution
		/// </summary>
		/// <returns>True in case solution is found, false otherwise</returns>
		private bool validSolutionFound() {
			if (!isFullMazeFilled())
				return false;
			//Check if actually a valid solution is found
			var generadores = getAllGenerators();
			int[] movimientosX = { 1, -1, 0, 0 };
			int[] movimientosY = { 0, 0, 1, -1 };
			for (int i = 0; i < generadores.Length; i++) {
				int movimientos = 0;
				for (int j = 0; j < movimientosX.Length; j++) {
					int x = generadores[i].X + movimientosX[j];
					int y = generadores[i].Y + movimientosY[j];
					if (isPositionLegal(x, y) && lab[x, y].Type == PieceTypes.Fillable) {
						var pieza = (Piece_Fillable)lab[x, y];
						while (pieza != null && pieza.Parent == generadores[i]) {
							movimientos++;
							x += movimientosX[j];
							y += movimientosY[j];
							if (isPositionLegal(x, y))
								pieza = lab[x, y] as Piece_Fillable;
							else
								break;
						}
					}
				}
				if (generadores[i].Moves != movimientos)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Check if maze is completely filled
		/// This will check if all Fillable blocks have any parent
		/// </summary>
		/// <returns>True in case labyrinth is completely filled, false otherwise</returns>
		private bool isFullMazeFilled() {
			for (int i = 0; i < lab.GetLength(0); i++) {
				for (int j = 0; j < lab.GetLength(1); j++) {
					if (lab[i, j].Type == PieceTypes.Fillable && ((Piece_Fillable)lab[i, j]).Parent == null) {
						return false;
					}
				}
			}
			return true;
		}
		
		/// <summary>
		/// Gets lab representation
		/// </summary>
		/// <returns>Lab representation</returns>
		public override string ToString() {
			string output = "";
			for (int i = 0; i < lab.GetLength(0); i++) {
				for (int j = 0; j < lab.GetLength(1); j++) {
					switch (lab[i, j].Type) {
						case PieceTypes.Fillable:
							if(((Piece_Fillable)lab[i, j]).Parent == null)
								output += " N |";
							else
								output += " " + ((Piece_Fillable)lab[i, j]).Parent.GeneratorID + " |";
							break;
						case PieceTypes.Generator:
							output += " " + ((Piece_Generator)lab[i, j]).GeneratorID + " |";
							break;
						case PieceTypes.SolidBlock:
							output += " # |";
							break;
						default:
							throw new Exception("Error occured when trying to fetch Piece Type on Resolver.ToString()");
					}
				}
				output += "\n";
			}
			return output;
		}
		
		/// <summary>
		/// FOR TESTING PURPOSES ONLY, BEGINNER LEVEL 2
		/// </summary>
		private void testfill() {
			//	2 | · | #
			//	· | # | ·
			//	· | · | 3

			//Row 1:     2 | · | #
			lab[0, 0] = LabBuilder.Build(PieceTypes.Generator, ConsoleColor.Blue, 2, 0, 0);
			lab[1, 0] = LabBuilder.Build(PieceTypes.Fillable);
			lab[2, 0] = LabBuilder.Build(PieceTypes.Fillable);
			//Row 2:     · | # | ·
			lab[0, 1] = LabBuilder.Build(PieceTypes.Fillable);
			lab[1, 1] = LabBuilder.Build(PieceTypes.SolidBlock);
			lab[2, 1] = LabBuilder.Build(PieceTypes.Fillable);
			//Row 3:     · | · | 3
			lab[0, 2] = LabBuilder.Build(PieceTypes.SolidBlock);
			lab[1, 2] = LabBuilder.Build(PieceTypes.Fillable);
			lab[2, 2] = LabBuilder.Build(PieceTypes.Generator, ConsoleColor.Green, 3, 2, 2);
		}


	}
}