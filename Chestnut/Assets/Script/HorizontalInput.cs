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

public class HorizontalInput : MonoBehaviour {

    [SerializeField]
    public int RotationSpeed = 50;
    [SerializeField]
    public int MouseRotationSpeed = 100;
   
    // Use this for initialization
    protected bool _dragOn = false;


    public void OnDragStart()
    {
        _dragOn = true;  // (Input.mousePosition.y < 50);
       
    }
    public void OnDragEnd()
    {
        _dragOn = false;
       
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

          
            if (Input.GetMouseButton(2) || _dragOn)
            {
               
                    float y = Input.GetAxis("Mouse X");
                    y = y * (MouseRotationSpeed * Time.deltaTime);
                    transform.Rotate(0, y, 0);
                

            }
           else if (Input.anyKeyDown)
           {
               float y = Input.GetAxis("Horizontal");
               y = y * (RotationSpeed * Time.deltaTime);
               transform.Rotate(0, y, 0);
           }
    }

    public void RotateToWhite(bool isWhite) {

        if(isWhite) transform.eulerAngles = new Vector3(0,0f,0);
        else transform.eulerAngles = new Vector3(0, 180f, 0);
    }
}
