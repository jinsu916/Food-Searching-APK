using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class Mappoint : MonoBehaviour
{
    public float Position_X { get; set; }
    public float Position_Y { get; set; }
    public Mappoint(float x, float y)
    {
        Position_X = x;
        Position_Y = y;
    }
}
public class GpsSearch : MonoBehaviour
{
    public List<GPS> gpslist = new List<GPS>();
    public List<Mappoint> mplist = new List<Mappoint>();
    //public Image User_point;
    public double mygps_lat;
    public double mygps_lot;
    public string XmlString { get; private set; }
    public List<string> gp_addrlist = new List<string>();
    XmlDocument doc;
    public Text gps1;


    public void SearchGps(List<string> addrlist)
    {
        try
        {
            //float fx = User_point.rectTransform.position.x;
            //float fy = User_point.rectTransform.position.y;

            var gps_s = GameObject.Find("cam").GetComponent<GPSloc>();
            mygps_lat = gps_s.Longi;
            mygps_lot = gps_s.Lat;

            //mygps_lat = 127.445419;
            //mygps_lot = 36.33609;
            /* float fx = User_point.rectTransform.position.x;
             float fy = User_point.rectTransform.position.y;*/

            gps1.text = "위도: " + mygps_lat + "\n" + "경도: " + mygps_lot;
            gpslist.Clear();

            foreach (string addr in addrlist)
            {
                XmlString = Find(addr);
                doc = new XmlDocument();
                doc.LoadXml(XmlString);
                //doc.Save("Search.xml");

                //==============================================

                GPS gps = null;
                foreach (XmlNode el in doc.SelectNodes("result"))
                {
                    gps = GPS.MakeGps(el);
                    gpslist.Add(gps);
                }
            }

            foreach (GPS gpad in gpslist)
            {                
                if (mygps_lat - 0.03d <= double.Parse(gpad.Position_X)
                    && mygps_lat + 0.01d >= double.Parse(gpad.Position_X)
                    && mygps_lot - 0.35d <= double.Parse(gpad.Position_Y)
                    && mygps_lot + 0.01d >= double.Parse(gpad.Position_Y))
                {
                    gp_addrlist.Add(gpad.Juso);
                    // Debug.Log(gpad.Position_X);
                    //gps1.text += "경도: " + gpad.Position_X + "\n";
                    Mappoint mp = new Mappoint(float.Parse((mygps_lat - double.Parse(gpad.Position_X)).ToString())*7000, float.Parse((mygps_lot - double.Parse(gpad.Position_Y)).ToString())*7000);
                    Debug.Log(mp.Position_X);
                    Debug.Log(mp.Position_Y);
                    mplist.Add(mp);
                    
                }
            }
        }
        catch(Exception)
        {
            Debug.Log("ㅋ");
        }

    }
    public string Find(string juso)
    {
        try
        {
            string msg = "http://apis.vworld.kr/new2coord.do?q=" + juso + "&apiKey=C2972184-5B16-34AB-9718-AC02390CCD22&domain=http://www.naver.com";

            var request = (HttpWebRequest)WebRequest.Create(msg);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response = null;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            // Console.WriteLine(results);
           
            return results;
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
            return null;
        }
    }

}
