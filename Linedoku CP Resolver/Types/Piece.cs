using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linedoku_CP_Resolver.Types {

	public enum PieceTypes { SolidBlock = 0, Generator = 1, Fillable = 2}

	public class Piece {
		
		public PieceTypes Type { get; internal set; }
	}
}