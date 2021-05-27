using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    public GameObject screen = null;
    public GameObject screen2 = null;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.Find("Canvas");
        screen2 = screen.transform.Find("Map").gameObject;
        this.transform.SetParent(screen2.transform);
    }
}
