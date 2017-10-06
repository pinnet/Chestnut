using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class User : MonoBehaviour {


    private  string _name;
     
    public  string FirstName {
        get { return _name; }
        set { _name = value; }
    }
   

}
