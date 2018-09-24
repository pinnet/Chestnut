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

public class CapturedPieces : MonoBehaviour {

    protected float position = 0; 
    [SerializeField]
    float moveDistance = 4f;
    public void add(Piece piece)
    {
        
        piece.transform.parent = transform;
         
        piece.transform.localPosition = new Vector3(position += moveDistance, 0, 0);
        if (piece is Knight) {

            piece.transform.Rotate(new Vector3(0, 90, 0));
        }

    }
}
