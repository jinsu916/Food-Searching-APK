using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public sealed class ResturantSearch : MonoBehaviour
{
    public Text test;
    public Button list_button;
    public Image map_point;
    public List<string> seqlist = new List<string>();
    public List<Resturant> reslist = new List<Resturant>();//전체 데이타
    public List<Resturant> reslist3 = new List<Resturant>();//주변 데이타

    public string XmlString { get; private set; }
    public string XmlString2 { get; private set; }
    XmlDocument doc;




    public void SearchResturant()
    {
        reslist.Clear();
        TextAsset asset = Resources.Load("restaurant") as TextAsset;
        string str = asset.text;
        StringReader streader = new StringReader(str);
        doc = new XmlDocument();

        doc.Load(streader);
        //==============================================

        XmlNode node = doc.SelectSingleNode("ServiceResult");
        Resturant resturant = null;

        foreach (XmlNode el in node.SelectNodes("msgBody"))
        {
            resturant = Resturant.MakeResturant(el);
            reslist.Add(resturant);
            seqlist.Add(resturant.Addr);
        }
    }

    public void GetNames(List<string> juso, List<Mappoint> mp, string dcode)
    {
        Debug.Log(dcode);
        foreach (string addr in juso)
        {
            string[] token = addr.Split('(');
            foreach (Resturant res in reslist)
            {
                if (res.Addr.Trim() == token[0].Trim() && res.DCodeNm.Trim() == dcode.Trim())
                {
                    reslist3.Add(res);
                }
            }
        }
        foreach (Resturant res in reslist3)
        {
            CreatButton(res.Name, res);
        }
        foreach (Mappoint point in mp)
        {
            Image map_pin = Instantiate(map_point, transform.position + new Vector3(point.Position_X, point.Position_Y, 0), transform.rotation);
            map_pin.GetComponent<RectTransform>().localScale = new Vector3(0.12f, 0.15f, 0);
        }
    }
    public void CreatButton(string name, Resturant res)
    {
        Button sunwo = Instantiate(list_button, transform.position, transform.rotation);
        sunwo.GetComponentInChildren<Text>().text = name;
        sunwo.GetComponentInChildren<Text>().fontSize += 50;
        sunwo.GetComponent<RectTransform>().localScale = new Vector3(0.19f, 0.5f, 0);
        sunwo.GetComponent<ButtonGetCon>().Info2 = res;
        sunwo.GetComponent<ButtonGetCon>().Textname = name;
    }
    #region 데이터 찾는 함수

    #endregion
}


