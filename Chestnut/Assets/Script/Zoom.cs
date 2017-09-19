using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
    [SerializeField]
    public float zoom = 56;
    // Use this for initialization
    Camera cam;
    void Start () {
	 cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
       if (Input.GetAxis("Mouse ScrollWheel") > 0) zoom ++ ;
       if (Input.GetAxis("Mouse ScrollWheel") < 0) zoom -- ;
       zoom = Mathf.Clamp(zoom,15,80);
       cam.fieldOfView = zoom;
    }
}
