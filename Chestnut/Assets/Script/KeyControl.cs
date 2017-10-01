using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if !UNITY_EDITOR && UNITY_WEBGL
WebGLInput.captureAllKeyboardInput = false;
#endif
    }

    // Update is called once per frame
    void Update () {
		
	}
}
