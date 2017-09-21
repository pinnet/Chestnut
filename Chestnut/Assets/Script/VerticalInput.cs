using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalInput : MonoBehaviour {

    [SerializeField]
    public int RotationSpeed = 50;
    [SerializeField]
    float x;
    [SerializeField]
    Vector3 axis;
    [SerializeField]
    public int MouseRotationSpeed = 100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        axis = transform.rotation.eulerAngles;
        if (Input.GetMouseButton(1))
        {

            x = Input.GetAxis("Mouse Y");
            x = x * (MouseRotationSpeed * Time.deltaTime);

        }
        else
        {
           
            x = Input.GetAxis("Vertical");
            x = x * (RotationSpeed * Time.deltaTime);
        }
        
        if (x > 0f)
        {

            if (axis.x > 89f) x = 0;

        }

        if (x < 0f)
        {
            if (axis.x < 1.0f) x = 0;
        }
        
        transform.Rotate(x, 0, 0);
        

    }
}
