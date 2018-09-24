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
using UnityEngine.SceneManagement;

public class LobbyLoader : MonoBehaviour {
    
    [SerializeField]
    Slider AsyncSlider;



    AsyncOperation operation;

    public void NextScene() {


        if (operation != null)
        operation.allowSceneActivation = true;

    }
	// Use this for initialization
	void Start () {
        StartCoroutine(AsyncLoad(1));
	}
    private void Update()
    {
       // if (operation.isDone) PlayButton.enabled = true;
    }

    IEnumerator AsyncLoad(int index) {

        operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            
            AsyncSlider.value = progress;
           
            yield return null;
        }
            
        
    }
}
