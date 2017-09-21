using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalInput : MonoBehaviour {

    [SerializeField]
    public int RotationSpeed = 50;
    [SerializeField]
    public int MouseRotationSpeed = 100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
           
        if (Input.GetMouseButton(1))
        {
               
            float y = Input.GetAxis("Mouse X");
            y = y * (MouseRotationSpeed * Time.deltaTime);
            transform.Rotate(0, y, 0);
 
        }
        else
        {
            float y = Input.GetAxis("Horizontal");
            y = y * (RotationSpeed * Time.deltaTime);
            transform.Rotate(0, y, 0);
        }
    }
    public void RotateToWhite(bool isWhite) {

        if(isWhite) transform.eulerAngles = new Vector3(0,0f,0);
        else transform.eulerAngles = new Vector3(0, 180f, 0);
    }
}
