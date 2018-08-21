using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linedoku_CP_Solver.Types;
using Linedoku_CP_Solver;

namespace Linedoku_CP_Solver_GUI {
	class BlockData {

		public PieceTypes Type { get; set; }

		public int PositionX { get; private set; }

		public int PositionY { get; private set; }

		public int TotalMoves { get; set; }

		public BlockData(PieceTypes type, int posX, int posY, int totalmoves = -1) {
			Type = type;
			PositionX = posX;
			PositionY = posY;
			if (totalmoves != -1) TotalMoves = totalmoves;
		}

		public Piece generatePiece() {
			return LabBuilder.Build(Type, ConsoleColor.Black, TotalMoves, PositionX, PositionY);
		}

	}
}