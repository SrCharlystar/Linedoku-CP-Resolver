using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linedoku_CP_Solver.Types {
	class Piece_Fillable : Piece{
		/// <summary>
		/// Generator used to fill this piece
		/// </summary>
		private Piece_Generator parent = null;
		internal Piece_Generator Parent {
			get { return parent; }
			set { parent = value;}
		}

		/// <summary>
		/// Constructor for class
		/// </summary>
		internal Piece_Fillable() {
			Type = PieceTypes.Fillable;
		}

	}
}