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

public class UCIConsole : MonoBehaviour {
    
    [SerializeField]
    Text con;

    protected string _stdin ="";
    protected string _stdout = "";


    public string STDIN
    {
        set { _stdin = value; Refresh(); }
    }
    [SerializeField]
    public string STDOUT {
        get { string ret = _stdout + "\n"; _stdout = ""; return ret; }

    }

	// Use this for initialization
	void Start () {

        _stdout = "Chestnut Version 1.0";
        
        con.text += STDOUT;	
	}
	
	void Refresh() {

        _stdout += _stdin;
        _stdin = "";
        con.text += STDOUT;
    }
}
