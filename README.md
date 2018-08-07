# Linedoku CP Solver
C# application to find a valid path in Linedoku Cross-Path game.
This is a alpha, not perfect version, just to test how backtracking algorithms are not efficient on finding large problem paths.

## How to run
Compile source code or (download latest release)[https://github.com/SrCharlystar/Linedoku-CP-Solver/releases] and run it.
Application will guide you while creating and filling level.  
Please note that in level representations, # represents a solid block, N a not-filled fillable block and a number a generator or a fillable block filled with that generator. (Number is not the number of moves of the generator, it is a unique identificator for the generator).

## How it works
This application uses backtracking to find a valid path for the given level. All blocks will be filled with same row/column generators until level is completely filled, then level will be checked. If it is a valid solution, algorithm will stop, and what algorithm got will be shown to the user.