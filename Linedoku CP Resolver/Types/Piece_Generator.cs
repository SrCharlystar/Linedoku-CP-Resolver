using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linedoku_CP_Resolver.Types {
	class Piece_Generator :Piece {
		/// <summary>
		/// Total moves for this block
		/// </summary>
		internal int Moves { get; private set; }

		/// <summary>
		/// Available moves left for this generator
		/// </summary>
		internal int AvailableMoves { get; set; }

		/// <summary>
		/// Color representing this generator
		/// </summary>
		internal ConsoleColor Color { get; private set; }

		/// <summary>
		/// Unique ID that represents this generator
		/// </summary>
		internal int GeneratorID { get; private set;}

		/// <summary>
		/// X coordinate, where Generator is located
		/// </summary>
		internal int X { get; private set; }

		/// <summary>
		/// Y coordinate, where Geneartor is located
		/// </summary>
		internal int Y { get; private set; }
		
		/// <summary>
		/// Constructor for this class
		/// </summary>
		/// <param name="moves">Number of total moves for this generator</param>
		/// <param name="ID">Unique IDentificator, GUI and ToString() representative only</param>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		internal Piece_Generator(int moves, int ID, int x, int y) {
			if (moves > 0 || X < 0 || Y < 0) {
				Moves = moves;
				AvailableMoves = moves;
				X = x;
				Y = y;
			} else
				throw new Exception("Parameter error on Piece_Generator.");
			GeneratorID = ID;
			Type = PieceTypes.Generator;
		}
	}
}