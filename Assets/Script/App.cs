using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class App : MonoBehaviour
{
    public void AppControl(string dcode)
    {
        var rs = GameObject.Find("Canvas").GetComponent<ResturantSearch>();
        var gps_s = GameObject.Find("Canvas").GetComponent<GpsSearch>();

            rs.SearchResturant();

            gps_s.SearchGps(rs.seqlist);

            rs.GetNames(gps_s.gp_addrlist, gps_s.mplist, dcode);

    }
}
