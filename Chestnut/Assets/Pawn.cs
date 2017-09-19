using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public string CurrentPosition
    {
        get { return GetCurrentPosition(); }
    }

    private void Start()
    {
       
    }



    private string GetCurrentPosition() {

        return gameObject.transform.parent.name;
    }
}
