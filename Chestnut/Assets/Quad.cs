using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {


    [SerializeField]
    protected Material defualtMat;
    [SerializeField]
    protected Material hiLight;

    public void Hilight(bool isHilight) {

        if (isHilight) { GetComponent<Renderer>().material = hiLight; }
        else { GetComponent<Renderer>().material = defualtMat; }
    }
}
