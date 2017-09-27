using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override bool[,] BuildMoveMatrix()
    {
       
        bool[,] _matrix = new bool[8, 8];
        
        int rank = CurrentPosition.Rank;
        int file = CurrentPosition.File;
        int validRank = 0;


        if (IsWhite)
        {
            validRank = rank + 1;
        }
        else
        {
            validRank = rank - 1;
        }

        if (validRank <= 8 && validRank >= 0)
            if (_pieceMatrix[validRank, file])
            {

                _matrix[validRank, file] = true;
            }

        if (_numberOfMoves == 0)
        {
            if (IsWhite)
            {
                validRank = rank + 2;
            }
            else
            {
                validRank = rank - 2;
            }

            if (validRank <= 8 && validRank >= 0)
                if (_pieceMatrix[validRank, file])
                {

                    _matrix[validRank, file] = true;
                }
        }


        return _matrix;
    }
}
