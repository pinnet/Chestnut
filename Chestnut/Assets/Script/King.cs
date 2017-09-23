using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece {




    public override bool[,] BuildMoveMatrix()
    {
        bool[,] _matrix = new bool[8, 8];
        bool[,] _pieceMatrix = BuildPieceMatrix();
        int rank = CurrentPosition.Rank;
        int file = CurrentPosition.File;
       


        for (int i = -1; i < 2; i++)
            for (int a = -1; a < 2; a++){

               int  f = i + file;
               int  r = a + rank;

                if ((r <= 8 && r >= 0) && (f <=8 && f >=0))
                    if (_pieceMatrix[r, f]) {
                        _matrix[r, f] = true;
                    }

                
            }


        return _matrix;
    }
}
