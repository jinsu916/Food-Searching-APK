using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public string Position_X { get; private set; }
    public string Position_Y { get; private set; }
    public string Juso { get; private set; }

    public GPS(string x, string y, string juso)
    {
        Position_X = x;
        Position_Y = y;
        Juso = juso;
    }
    static public GPS MakeGps(XmlNode xn)
    {
        //초기화 (값을 잘 넣기위함)
        //초기화를 안해주면 안에 가비지값이 있기때문에 값을 넣는 과정이 힘듬
        string x = string.Empty;
        string y = string.Empty;
        string juso = string.Empty;


        XmlNode x_node = xn.SelectSingleNode("EPSG_4326_X");
        x = ConvertString(x_node.InnerText);

        XmlNode y_node = xn.SelectSingleNode("EPSG_4326_Y");
        y = ConvertString(y_node.InnerText);

        XmlNode juso_node = xn.SelectSingleNode("JUSO");
        juso = ConvertString(juso_node.InnerText);

        return new GPS(x, y, juso);
    }

    static private string ConvertString(string str)
    {
        int sindex = 0;
        int eindex = 0;
        while (true)
        {
            sindex = str.IndexOf("<![CDATA[");
            if (sindex == -1)
            {
                break;
            }
            eindex = str.IndexOf("]]>");
            str = str.Remove(sindex, eindex - sindex + 1);
        }
        return str;
    }
}

