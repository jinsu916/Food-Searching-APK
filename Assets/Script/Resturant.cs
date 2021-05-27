using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;



public class Etc
{
    #region 프로퍼티
    public string Price { get; private set; } //음식 가격
    public string Title { get; private set; }//음식 이름
    #endregion

    public Etc(string price, string title)
    {
        Price = price;
        Title = title;
    }
}

public class Resturant : MonoBehaviour
{
    /*
    // public List<Etc> reslist2 = new List<Etc>();
    #region 프로퍼티
    public string Seq { get; private set; }
    public string Name { get; private set; }//식당 이름
    public string Addr { get; private set; }//식당 주소
    public string OpenTime { get; private set; }//개점 시간
    public string CloseTime { get; private set; }//폐점 시간
    public string Room { get; private set; }//방 개수
    public string Table1 { get; private set; }//테이블개수 1
    public string[] Price { get; private set; } //음식 가격
    public string[] Title { get; private set; }//음식 이름
    #endregion

    #region 생성자
    public Resturant(string seq, string name, string addr, string opentime, string closetime, string room, string table1, string[] price, string[] title)
    {
        Seq = seq;
        Name = name;
        Addr = addr;
        OpenTime = opentime;
        CloseTime = closetime;
        Room = room;
        Table1 = table1;
        Price = price;
        Title = title;
    }
    #endregion

    #region 파서
    static public Etc MakeResturant_etc(XmlNode xn)
    {
        string price = string.Empty;
        string title = string.Empty;

        XmlNode price_node = xn.SelectSingleNode("price");
        price = ConvertString(price_node.InnerText);

        XmlNode title_node = xn.SelectSingleNode("title");
        title = ConvertString(title_node.InnerText);

        return new Etc(price, title);
    }


    static public Resturant MakeResturant(XmlNode xn, XmlNode d)
    {
        //초기화 (값을 잘 넣기위함)
        //초기화를 안해주면 안에 가비지값이 있기때문에 값을 넣는 과정이 힘듬
        // var rs = GameObject.Find("Canvas").GetComponent<ResturantSearch>();
        List<Etc> etclist = new List<Etc>();
        string seq = string.Empty;
        string name = string.Empty;
        string addr = string.Empty;
        string opentime = string.Empty;
        string closetime = string.Empty;
        string room = string.Empty;
        string table1 = string.Empty;
        string[] price = new string[10];
        string[] title = new string[10];
        Etc etc;
        XmlNode seq_node = xn.SelectSingleNode("foodSeq");
        seq = ConvertString(seq_node.InnerText);

        XmlNode name_node = xn.SelectSingleNode("name");
        name = ConvertString(name_node.InnerText);

        XmlNode addr_node = xn.SelectSingleNode("addr1");
        addr = ConvertString(addr_node.InnerText);

        XmlNode opentime_node = xn.SelectSingleNode("openTime");
        opentime = ConvertString(opentime_node.InnerText);

        XmlNode closetime_node = xn.SelectSingleNode("closeTime");
        closetime = ConvertString(closetime_node.InnerText);

        XmlNode room_node = xn.SelectSingleNode("room");
        room = ConvertString(room_node.InnerText);

        XmlNode table1_node = xn.SelectSingleNode("table2");
        table1 = ConvertString(table1_node.InnerText);

        int i = 0;
        foreach (XmlNode el2 in d.SelectNodes("FoodMenuEtcList"))
        {
            etc = MakeResturant_etc(el2);
            title[i] = etc.Title;
            price[i] = etc.Price;
            etclist.Add(etc);
            i++;
        }
        for (int i1 = 9; i1 >= 0; i1--)
        {
            if (title[i1] == null)
            {
                title[i1] = "정보없음";
            }
        }
        for (int i2 = 9; i2 >= 0; i2--)
        {
            if (price[i2] == null)
            {
                price[i2] = "정보없음";
            }
        }
        return new Resturant(seq, name, addr, opentime, closetime, room, table1, price, title);
    }

    static private string ConvertString(string str) //<>없애줌
    {
        int sindex = 0;
        int eindex = 0;
        while (true)
        {
            sindex = str.IndexOf('<');
            if (sindex == -1)
            {
                break;
            }
            eindex = str.IndexOf('>');
            str = str.Remove(sindex, eindex - sindex + 1);
        }
        return str;
    }
    #endregion*/
    // public List<Etc> reslist2 = new List<Etc>();
    #region 프로퍼티
    public string DCodeNm { get; private set; } //식당 분류 => 한식, 중식, 양식, 일식
    public string Seq { get; private set; }
    public string Name { get; private set; }//식당 이름
    public string Addr { get; private set; }//식당 주소
    public string OpenTime { get; private set; }//개점 시간
    public string CloseTime { get; private set; }//폐점 시간
    public string Table1 { get; private set; }//테이블개수 1
    public string[] Price { get; private set; } //음식 가격
    public string[] Title { get; private set; }//음식 이름
    #endregion

    #region 생성자
    public Resturant(string dcodenm, string seq, string name, string addr, string opentime, string closetime, string table1, string[] price, string[] title)
    {
        DCodeNm = dcodenm;
        Seq = seq;
        Name = name;
        Addr = addr;
        OpenTime = opentime;
        CloseTime = closetime;
        Table1 = table1;
        Price = price;
        Title = title;
    }
    #endregion

    #region 파서


    static public Resturant MakeResturant(XmlNode xn)
    {
        string dcodenm = string.Empty;
        string seq = string.Empty;
        string name = string.Empty;
        string addr = string.Empty;
        string opentime = string.Empty;
        string closetime = string.Empty;
        string table1 = string.Empty;
        string price_d = string.Empty;
        string title_d = string.Empty;

        string[] price = new string[10];
        string[] title = new string[10];

        XmlNode dcodenm_node = xn.SelectSingleNode("dCodeNm");
        dcodenm = ConvertString(dcodenm_node.InnerText);

        XmlNode seq_node = xn.SelectSingleNode("foodSeq");
        seq = ConvertString(seq_node.InnerText);

        XmlNode name_node = xn.SelectSingleNode("name");
        name = ConvertString(name_node.InnerText);

        XmlNode addr_node = xn.SelectSingleNode("addr1");
        addr = ConvertString(addr_node.InnerText);

        XmlNode opentime_node = xn.SelectSingleNode("openTime");
        opentime = ConvertString(opentime_node.InnerText);

        XmlNode closetime_node = xn.SelectSingleNode("closeTime");
        closetime = ConvertString(closetime_node.InnerText);

        XmlNode table1_node = xn.SelectSingleNode("table2");
        table1 = ConvertString(table1_node.InnerText);

        XmlNode el = xn.SelectSingleNode("foodMenuEtcListAll");

        int i = 0;
        foreach (XmlNode el2 in el.SelectNodes("FoodMenuEtcList"))
        {
            XmlNode price_d_node = el2.SelectSingleNode("price");
            price_d = ConvertString(price_d_node.InnerText);

            XmlNode title_d_node = el2.SelectSingleNode("title");
            title_d = ConvertString(title_d_node.InnerText);

            price[i] = price_d;
            title[i] = title_d;
            i++;
        }
        for (int i1 = 9; i1 >= 0; i1--)
        {
            if (title[i1] == null)
            {
                title[i1] = "정보없음";
            }
        }
        for (int i2 = 9; i2 >= 0; i2--)
        {
            if (price[i2] == null)
            {
                price[i2] = "정보없음";
            }
        }
        return new Resturant(dcodenm, seq, name, addr, opentime, closetime, table1, price, title);
    }

    static private string ConvertString(string str) //<>없애줌
    {
        int sindex = 0;
        int eindex = 0;
        while (true)
        {
            sindex = str.IndexOf('<');
            if (sindex == -1)
            {
                break;
            }
            eindex = str.IndexOf('>');
            str = str.Remove(sindex, eindex - sindex + 1);
        }
        return str;
    }
    #endregion

}
