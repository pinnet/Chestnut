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

public class Quad : MonoBehaviour {

    protected Material _hiLight;

    [SerializeField]
    protected Material defualtMat;
    [SerializeField]
    protected Material redHiLight;
    [SerializeField]
    protected Material greenHiLight;
    [SerializeField]
    protected Material orangeHiLight;
    
    public void Hilight(HiliteColor colour) {

        transform.localPosition = new Vector3(0, 0.01f, 0);
        switch (colour) {
            
            case HiliteColor.red :
                _hiLight = redHiLight;
                break;
            case HiliteColor.green :
                _hiLight = greenHiLight;
                break;
            case HiliteColor.orange :
                _hiLight = orangeHiLight;
                break;
            default :
                _hiLight = defualtMat;
                transform.localPosition = new Vector3(0, 0, 0);
                break;
        }
        GetComponent<Renderer>().material = _hiLight;

    }
}

public enum HiliteColor
{
    red,green,orange,none
}
