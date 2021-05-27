using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSTEXT : MonoBehaviour
{
    public Text coor;

    private void Update()
    {
        coor.text = "LAT:" + GPSloc.Instance.Lat.ToString() + "           LON:" + GPSloc.Instance.Longi.ToString(); 
    }
}
