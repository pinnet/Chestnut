using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolly : MonoBehaviour {

    [SerializeField]
    public int RotationSpeed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        float x = Input.GetAxis("Vertical");
       

        x = x * (RotationSpeed * Time.deltaTime);
       

        transform.Rotate(x, 0, 0); 


    }
}
