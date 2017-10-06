using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    protected GameObject _previousHit;
    [SerializeField]
    Vector2 cursorHotspot = new Vector2();
    [SerializeField]
    Texture2D cursorTexture = null;
    [SerializeField]
    GameObject PauseManager;


    // Use this for initialization
    void Start () {

        Cursor.SetCursor(cursorTexture,cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseManager.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {


                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {

                    if (hitInfo.transform.gameObject.tag == "Square")
                    {
                        GameObject parentSquare = hitInfo.transform.gameObject;
                        if (!parentSquare) return;

                        Square sq = parentSquare.GetComponent<Square>();
                        Quad q = parentSquare.GetComponentInChildren<Quad>();
                        Piece p = parentSquare.GetComponentInChildren<Piece>();

                        if (p)
                        {
                            sq.SelectedPiece = p;
                            bool valid = p.isValidMove(parentSquare.name);

                            if (valid)
                            {
                                if (p.IsWhite)
                                {
                                    q.Hilight(HiliteColor.green);
                                }
                                else
                                {
                                    q.Hilight(HiliteColor.red);
                                    sq.SelectedPiece = null;
                                }

                            }
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


                if (parentSquare == null) return;

                Quad q = parentSquare.GetComponentInChildren<Quad>();
                q.Hilight(HiliteColor.none);

            }
        }
    }
}
