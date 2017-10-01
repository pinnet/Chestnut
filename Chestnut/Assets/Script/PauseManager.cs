using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour{

   
    
    

    Canvas pauseCanvas;
    Canvas serverCanvas;

    void Start()
    {
        pauseCanvas = GetComponent<Canvas>();
        pauseCanvas.enabled = false;

        serverCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        serverCanvas.enabled = false;
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
        pauseCanvas.enabled = !pauseCanvas.enabled;
        serverCanvas.enabled = pauseCanvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
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
