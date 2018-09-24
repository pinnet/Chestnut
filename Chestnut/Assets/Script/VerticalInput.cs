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

public class VerticalInput : MonoBehaviour {

    [SerializeField]
    public int RotationSpeed = 50;
    [SerializeField]
    float x;
    [SerializeField]
    Vector3 axis;
    [SerializeField]
    public int MouseRotationSpeed = 100;
    ChangeView view;
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
    private void Start()
    {
        
        view = GameObject.FindObjectOfType<ChangeView>();
    }
    // Update is called once per frame
    void Update () {
       
        if (Input.GetMouseButton(2) || _dragOn)
        {

            x = Input.GetAxis("Mouse Y");
            x = x * (MouseRotationSpeed * Time.deltaTime);

        }
        else
        {
           
            x = Input.GetAxis("Vertical");
            x = x * (RotationSpeed * Time.deltaTime);
        }

        axis = transform.rotation.eulerAngles;
        if (x > 0f)
        {

            if (axis.x > 88f)
            {
                x = x - 1f;
                view.PerspectiveMode = false;        
            }

        }
        else if (x < 0f)
        {
            view.PerspectiveMode = true;
            if (axis.x < 0.1f || axis.x > 300f) x = x +1f;
        }
        
        transform.Rotate(x, 0f, 0f);
        

    }
}
