using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {
    protected GameObject _previousHit;
    [SerializeField]
    Vector2 cursorHotspot = new Vector2();
    [SerializeField]
    Texture2D cursorTexture = null;
    protected MoveManager _moveManager;
 
    // Use this for initialization
    void Start () {
        _moveManager = GetComponent<MoveManager>();
        Cursor.SetCursor(cursorTexture,cursorHotspot, CursorMode.Auto);
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
                    if (!parentSquare) return;
                    Quad q = parentSquare.GetComponentInChildren<Quad>();
                    Piece p = parentSquare.GetComponentInChildren<Piece>();

                    if (p) {
                        
                            if (p.tag != ((_moveManager.PlayerIsWhite) ? "White" : "Black" ))
                            {
                                q.Hilight(HiliteColor.red);
                            }
                            else
                            {
                                q.Hilight(HiliteColor.green);
                            }

                      
                        Debug.Log(p.tag);
                    }
                    else
                    {

                        q.Hilight(HiliteColor.orange);
                    }
                    _previousHit = parentSquare;

                }   
            }
            
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            GameObject parentSquare = _previousHit;
            if (!parentSquare) return;
            Quad q = parentSquare.GetComponentInChildren<Quad>();
            q.Hilight(HiliteColor.none);

        }
    }
}
