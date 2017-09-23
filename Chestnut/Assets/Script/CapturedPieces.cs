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
