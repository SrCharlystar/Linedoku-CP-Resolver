using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linedoku_CP_Resolver.Types {
	class Piece_SolidBlock : Piece {
		//Color for this block is always black.
		//This block does not need any movement method since it is only a Solid block ¯\_(ツ)_/¯

		internal Piece_SolidBlock() {
			Type = PieceTypes.SolidBlock;
		}
	}
}