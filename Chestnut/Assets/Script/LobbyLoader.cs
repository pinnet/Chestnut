using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyLoader : MonoBehaviour {
    
    [SerializeField]
    Slider AsyncSlider;


    float lastProgress = 0;
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
        //if (operation.isDone) PlayButton.enabled = true;
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
