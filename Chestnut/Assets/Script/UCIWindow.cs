using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCIWindow : MonoBehaviour {

    private bool _hidden = true;
    Animator ani;

    public void ToggleConsole()
    {
        _hidden = !_hidden;
        ani.SetBool("HideConsole", _hidden);

    }

    private void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("HideConsole", _hidden);
    }
    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            ToggleConsole();
        }
    }
}
