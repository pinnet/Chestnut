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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        axis = transform.rotation.eulerAngles;      

        x = Input.GetAxis("Vertical");

        if (x > 0f){

            if (axis.x > 89f) x = 0;

        }

        if (x < 0f){
            if (axis.x < 1.0f) x = 0f;
        }


        x = x * (RotationSpeed * Time.deltaTime);

        transform.Rotate(x, 0, 0);


    }
}
