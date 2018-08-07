using Linedoku_CP_Solver.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linedoku_CP_Solver {
	public class LabBuilder {
		static int id = 0;
		/// <summary>
		/// Returns desired Piece object
		/// </summary>
		/// <param name="Type">Type of piece</param>
		/// <param name="color">Color for this piece. Only used in case of GUI output. Only in case block is generator</param>
		/// <param name="moves">Total moves, only if case block is a generator</param>
		public static Piece Build(PieceTypes Type, ConsoleColor color = ConsoleColor.Black, int moves = -1, int x = -1, int y = -1) {
			switch (Type) {
				case PieceTypes.SolidBlock:
					return new Piece_SolidBlock();
				case PieceTypes.Generator:
					id++;
					return new Piece_Generator(moves, id, x, y);
				case PieceTypes.Fillable:
					return new Piece_Fillable();
				default:
					throw new Exception("Error fetching Piece type");
			}
		}

	}
}