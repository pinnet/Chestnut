﻿/*************************************************************************
 *
 *  dannyarnold.com 2017
 *  All Rights Reserved.
 * 
 * NOTICE:  All information contained herein is, and remains
 * the property of dannyarnold.com and its suppliers,
 * if any.  The intellectual and technical concepts contained
 * herein are proprietary to dannyarnold.com
 * and its suppliers and may be covered by U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from dannyarnold.com.
 *
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE.txt', which is part of this source code package.
 *
 */



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
