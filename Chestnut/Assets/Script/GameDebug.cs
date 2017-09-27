using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameDebug : MonoBehaviour {

    public string[] integers;

    public Vector3[] vectors;

    public Transform[] objects;


    protected Board GameBoard;
    protected int[,] Layout;

    private void Start()
    {
        GameBoard = GetComponent<Board>();
    }

    private void Update()
    {
        if (GameBoard.Upated)
        {
            GameBoard.Upated = false;

            Layout = GameBoard.Layout;

            Debug.Log(Layout);





        }
    }

}
