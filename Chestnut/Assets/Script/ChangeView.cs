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
using UnityEngine.UI;

public class ChangeView : MonoBehaviour {

    [SerializeField]
    public VerticalInput CameraArm;
    [SerializeField]
    Text text;

    private bool _perspective = true;
	public void TogglePerspective()
    {
       
       
        if (!_perspective)
        {
        
            CameraArm.gameObject.transform.eulerAngles = new Vector3(36f,0, 0);

        }
        PerspectiveMode = !PerspectiveMode;
    }
    public bool PerspectiveMode {
        get { return _perspective; }
        set { _perspective = value; SetPerspective(_perspective); }
     }

    private void SetPerspective(bool state) {

        if (!state)
        {
            Camera.main.orthographic = true;
            CameraArm.gameObject.transform.eulerAngles = new Vector3(90, 0, 0);
            Camera.main.orthographicSize = 30f;
            text.text = "P";
        }
        else
        {
            text.text = "O";

            Camera.main.orthographic = false;
        }
    }
}
