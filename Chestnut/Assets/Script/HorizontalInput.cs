using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalInput : MonoBehaviour {

    [SerializeField]
    public int RotationSpeed = 5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float y = Input.GetAxis("Horizontal");
        y = y * (RotationSpeed * Time.deltaTime);
        transform.Rotate(0, y, 0);
    }

}
