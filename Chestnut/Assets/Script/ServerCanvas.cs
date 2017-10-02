using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerCanvas : MonoBehaviour {

        private static ServerCanvas _instance;

    public static ServerCanvas Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject server = new GameObject("Server Canvas");
                server.AddComponent<ServerCanvas>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

}
