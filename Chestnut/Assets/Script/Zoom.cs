using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
    [SerializeField]
    public float zoom = 56;
    protected bool _stopZoom = false;

    // Use this for initialization
    Camera cam;
    void Start () {
	 cam = GetComponent<Camera>();
	}
    protected bool _dragOn = false;
    public void OnDragStart()
    {
        _dragOn = true;  // (Input.mousePosition.y < 50);

    }
    public void OnDragEnd()
    {
        _dragOn = false;

    }
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButton(1) || _dragOn)
        {
            float y = Input.GetAxis("Mouse Y");
            if (y > 0) zoom++;
            if (y < 0) zoom--;
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) zoom++;
            if (Input.GetAxis("Mouse ScrollWheel") < 0) zoom--;
        }
       zoom = Mathf.Clamp(zoom,15,80);
       cam.fieldOfView = zoom;
    }
    public void Stop()
    {

        CancelInvoke();

    }
    public void TriggerIn()
    {

        CancelInvoke();
        InvokeRepeating("In", 0, 0.05f);
    }

    public void TriggerOut()
    {
        CancelInvoke();
        InvokeRepeating("Out", 0, 0.05f);
    }
    private void In()
    {
           zoom--;
            zoom = Mathf.Clamp(zoom, 15, 80);
            cam.fieldOfView = zoom;
      
    }

    private void Out()
    {
        
            zoom++;
            zoom = Mathf.Clamp(zoom, 15, 80);
            cam.fieldOfView = zoom;
      
    }
   
}
