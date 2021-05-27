using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGetCon : MonoBehaviour
{
    public Resturant Info2;
    public GameObject screen = null;
    public GameObject screen2 = null;
    public Text info;
    public string Textname;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetParent(GameObject.Find("Content").transform);
        screen = GameObject.Find("Canvas");
        screen2 = screen.transform.Find("Screen").gameObject;
        info = screen2.GetComponentInChildren<Text>();
    }
    public void Print_info()
    {
        var rs = GameObject.Find("Canvas").GetComponent<ResturantSearch>();
        screen2.SetActive(true);
        
        info.text = string.Empty;
            info.text = "식당이름: " + Info2.Name + "\n"
                      + "주소: "     + Info2.Addr + "\n"
                      + "영업시간: " + Info2.OpenTime + "~" + Info2.CloseTime + "\n"
                      + "메뉴\n";
        for(int i = 0; i<10; i++)
        {
            info.text += (i + 1).ToString() + ". " + Info2.Title[i] + "\n" + "   " + Info2.Price[i] + "\n\n";
            if (Info2.Title[i] == "정보없음" || Info2.Price[i] == "정보없음")
            {
                break;
            }
        }
       /* foreach (Resturant res2 in rs.reslist)
        {
            if (res2.Name.Trim() == Textname.Trim())
            {
                for (int i = 0; i < rs.reslist.Count; i++)
                {
                    info.text += res2.Title[i] + "  가격 : " + res2.Price[i] + "\n";
                }
            }
        }*/
    }
 
}
