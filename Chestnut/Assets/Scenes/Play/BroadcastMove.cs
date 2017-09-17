using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BroadcastMove : MonoBehaviour {
    [DllImport("__Internal")]
    private static extern void Hello();
    // Use this for initialization


    public void broadcast() {

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Hello();
        }

    }

   
}
