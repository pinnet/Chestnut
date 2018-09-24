/*************************************************************************
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

public class King : Piece {




    public override bool[,] BuildMoveMatrix()
    {
       
        bool[,] moveMatrix = new bool[8, 8];
       
        int rank = CurrentPosition.Rank;
        int file = CurrentPosition.File;
       


        for (int i = -1; i < 2; i++)
            for (int a = -1; a < 2; a++){

               int  f = i + file;
               int  r = a + rank;

                if ((r < 8 && r >= 0) && (f <8 && f >=0))
                    if (_pieceMatrix[r, f]) {
                        moveMatrix[r, f] = true;
                    }

                
            }


        return moveMatrix;
    }
}
