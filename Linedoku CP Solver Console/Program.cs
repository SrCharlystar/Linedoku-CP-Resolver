using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linedoku_CP_Solver;
using Linedoku_CP_Solver.Types;

namespace Linedoku_CP_Solver_Console {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to Linedoku Cross-Path resolver. This program will help you finding one correct path in this game.");
			Console.WriteLine("If you find any bugs, please let me know. https://github.com/SrCharlystar \n");
			Piece[,] lab = createLab();
			Console.WriteLine("Lab successfully created. Please re-check your desired labyrinth is the one which follows:");
			Solver res = new Solver(lab);
			Console.WriteLine(res.ToString());
			Console.WriteLine("If your labyrinth is not correct, please restart this application and create it again. If it is correct, press enter to start solving.");
			Console.ReadLine();
			Console.WriteLine("Trying to solve labyrinth...");
			long startMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			res.Solve(lab);
			long endMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			Console.WriteLine("Execution time: " + (endMillis-startMillis) + "ms");
			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
		}

		private static Piece[,] createLab() {
			Console.WriteLine("Let's start creating your labyrinth.");
			Console.Write("Labyrinth width: ");
			int y = readInt();
			Console.Write("Labyrinth height: ");
			int x = readInt();
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
								int moves = readInt();
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

		private static int readInt() {
			try {
				return Convert.ToInt32(Console.ReadLine());
			} catch (Exception) {
				Console.WriteLine("Invalid input. Please type a number: ");
				return readInt();
			}
		}



	}
}