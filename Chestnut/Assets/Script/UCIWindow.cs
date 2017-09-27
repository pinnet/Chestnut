using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCIWindow : MonoBehaviour {


    Animator ani;

    public void HideConsole(bool yes)
    {

        ani.SetBool("HideConsole",yes);

    }
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            ani.SetBool("HideConsole", false);
        }
    }
}
