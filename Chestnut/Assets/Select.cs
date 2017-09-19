using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {
    protected GameObject PreviousHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
           

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                
                if (hitInfo.transform.gameObject.tag == "Square")
                {


                    GameObject parentSquare = (hitInfo.transform.gameObject);

                    parentSquare.GetComponentInChildren<Quad>().Hilight(true);

                    PreviousHit = parentSquare;

                }   
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {


                    GameObject parentSquare = PreviousHit;

                    parentSquare.GetComponentInChildren<Quad>().Hilight(false);

                 
            

        }
    }
}
