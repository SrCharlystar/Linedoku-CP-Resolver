using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linedoku_CP_Resolver;
using Linedoku_CP_Resolver.Types;

namespace Linedoku_CP_Solver_Console {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to Linedoku Cross-Path resolver. This program will help you finding one correct path in this game.");
			Console.WriteLine("If you find any bugs, please let me know. https://github.com/SrCharlystar \n");
			Piece[,] lab = createLab();
			Console.WriteLine("Lab successfully created. Please re-check your desired labyrinth is the one which follows:");
			Resolver res = new Resolver(lab);
			Console.WriteLine(res.ToString());
			Console.WriteLine("If your labyrinth is not correct, please restart this application and create it again. If it is correct, press enter to start solving.");
			Console.ReadLine();
			Console.WriteLine("Trying to solve labyrinth...");
			res.Solve(lab);
			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
		}

		private static Piece[,] createLab() {
			Console.WriteLine("Let's start creating your labyrinth. At this moment all levels have same width and height, but I ask both because this application supports MxN with M != N labyrinth dimensions.");
			Console.Write("Labyrinth width: ");
			int x = Convert.ToInt32(Console.ReadLine());
			Console.Write("Labyrinth height: ");
			int y = Convert.ToInt32(Console.ReadLine());
			Piece[,] lab = new Piece[x, y];
			Console.WriteLine("OK. Lets start filling it. Please type:\n" +
						"'g' if block is a Generator (The coloured ones)\n" +
						"'f' if block if fillable (If you can colour it using a generator)\n" +
						"'b' if block is solid (If it is a black obstacle)\n");
			for (int i = 0; i < x; i++) {
				for (int j = 0; j < y; j++) {
					Console.WriteLine("Block ({0}, {1})" , i, j);
					bool retry = false;
					do {
						retry = false;
						switch (Console.ReadLine()) {
							case "g":
								Console.WriteLine("You need to provide extra details for generators:");
								Console.Write("Generator available moves: ");
								int moves = Convert.ToInt32(Console.ReadLine());
								lab[i, j] = LabBuilder.Build(PieceTypes.Generator, ConsoleColor.Blue, moves, i, j);
								break;
							case "f":
								lab[i, j] = LabBuilder.Build(PieceTypes.Fillable);
								break;
							case "b":
								lab[i, j] = LabBuilder.Build(PieceTypes.SolidBlock);
								break;
							default:
								Console.WriteLine("Block type not recognized. Please retry.");
								retry = true;
								break;
						}
					} while (retry);
				}
			}
			return lab;
		}



	}
}