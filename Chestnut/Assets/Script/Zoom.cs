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
