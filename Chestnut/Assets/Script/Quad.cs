using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

    protected Material _hiLight;

    [SerializeField]
    protected Material defualtMat;
    [SerializeField]
    protected Material redHiLight;
    [SerializeField]
    protected Material greenHiLight;
    [SerializeField]
    protected Material orangeHiLight;
    
    public void Hilight(HiliteColor colour) {

        transform.localPosition = new Vector3(0, 0.01f, 0);
        switch (colour) {
            
            case HiliteColor.red :
                _hiLight = redHiLight;
                break;
            case HiliteColor.green :
                _hiLight = greenHiLight;
                break;
            case HiliteColor.orange :
                _hiLight = orangeHiLight;
                break;
            default :
                _hiLight = defualtMat;
                transform.localPosition = new Vector3(0, 0, 0);
                break;
        }
        GetComponent<Renderer>().material = _hiLight;

    }
}

public enum HiliteColor
{
    red,green,orange,none
}
