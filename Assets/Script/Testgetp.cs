using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testgetp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetParent(GameObject.Find("underbar").transform);
    }


}
