using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeView : MonoBehaviour {

    [SerializeField]
    public VerticalInput CameraArm;
    [SerializeField]
    Text text;

    private bool _perspective = true;
	public void TogglePerspective()
    {
       
       
        if (_perspective)
        {
            text.text = "P";
            
        }
        else {
            text.text = "O";

            CameraArm.gameObject.transform.eulerAngles = new Vector3(36f,0, 0);

        }
        PerspectiveMode = !PerspectiveMode;
    }
    public bool PerspectiveMode {
        get { return _perspective; }
        set { _perspective = value; SetPerspective(_perspective); }
     }

    private void SetPerspective(bool state) {

        if (!state)
        {
            Camera.main.orthographic = true;
            CameraArm.gameObject.transform.eulerAngles = new Vector3(90, 0, 0);
            Camera.main.orthographicSize = 30f;
        }
        else
        {
            //
            Camera.main.orthographic = false;
        }
    }
}
