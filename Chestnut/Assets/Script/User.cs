﻿/*************************************************************************
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

public abstract class User : MonoBehaviour {


    private  string _name;
     
    public  string FirstName {
        get { return _name; }
        set { _name = value; }
    }
   

}
