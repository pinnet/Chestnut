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
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour{


    [SerializeField]
    Button Play;

    GameObject pauseCanvas;
    Canvas serverCanvas;

    void Start()
    {
       
        pauseCanvas = GameObject.Find("Pause Canvas");
        serverCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        serverCanvas.enabled = true;
        //Play.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        serverCanvas.enabled = pauseCanvas.activeSelf;
       
        //Time.timeScale = (pauseCanvas.enabled) ? 0 : 1;
    }

    public void Quit()
    {
//#if UNITY_EDITOR
//        EditorApplication.isPlaying = false;
//#else
        Application.Quit();
//#endif
    }
}
